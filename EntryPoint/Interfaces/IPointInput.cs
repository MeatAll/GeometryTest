using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GeometryApp.Interfaces;

#nullable enable
public interface IPointInput
{
    Task<Point[]?> PickPointsAsync(IReadOnlyList<string> tooltips, IProgress<string> tooltip, CancellationToken ct = default);
    void ReportClick(Point point);
    void Cancel();
}
