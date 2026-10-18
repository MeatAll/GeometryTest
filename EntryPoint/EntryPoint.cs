using GeometryApp.Input;
using GeometryApp.Interfaces;
using GeometryApp.Presenters;
using System;

namespace GeometryApp;

internal class EntryPoint
{
    [STAThread]
    public static void Main()
    {
        var input = new PointInputController();

        IShapeCreation[] strategies =
        [
            new LineCreationPresenter(),
            new RectangleCreationPresenter(),
            new CircleCreationPresenter(),
            new TriangleCreationPresenter(),
        ];

        var viewModel = new ViewModel(strategies, input);
        var window = new MainWindow { DataContext = viewModel };

        window.MouseClicked += (_, point) => input.ReportClick(point);
        window.CancelKeyDown += (_, _) => input.Cancel();

        window.ShowDialog();
    }
}