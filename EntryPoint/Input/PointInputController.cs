using GeometryApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GeometryApp.Input;

#nullable enable
internal class PointInputController : IPointInput
{
    private TaskCompletionSource<Point>? _pendingClick;
    private CancellationTokenSource? _cts;
    public void ReportClick(Point point) => _pendingClick?.TrySetResult(point);
    public void Cancel() => _cts?.Cancel();
    public async Task<Point[]?> PickPointsAsync(IReadOnlyList<string> prompts, IProgress<string> tooltip, CancellationToken ct = default)
    {
        using var linked = CancellationTokenSource.CreateLinkedTokenSource(ct);

        _cts = linked;

        try
        {
            var points = new Point[prompts.Count];

            for (var i = 0; i < prompts.Count; i++)
            {
                tooltip.Report(prompts[i]);

                points[i] = await WaitForClickAsync(linked.Token);
            }
            return points;
        }
        catch (OperationCanceledException)
        {
            return null;
        }
        finally
        {
            _pendingClick = null;

            _cts = null;

            tooltip.Report(string.Empty);
        }
    }
    private async Task<Point> WaitForClickAsync(CancellationToken ct)
    {
        var tcs = new TaskCompletionSource<Point>(TaskCreationOptions.RunContinuationsAsynchronously);

        _pendingClick = tcs;

        try
        {
            using var registration = ct.Register(() => tcs.TrySetCanceled(ct));

            return await tcs.Task;
        }
        finally
        {
            _pendingClick = null;
        }
    }
}