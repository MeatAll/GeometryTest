using System;
using System.Windows;
using System.Windows.Input;

namespace GeometryApp;

public partial class MainWindow : Window
{
    public event EventHandler<Point> MouseClicked;
    public event EventHandler CancelKeyDown;
    public MainWindow() => InitializeComponent();
    private void ItemsControlClickHandler(object sender, MouseButtonEventArgs e) => MouseClicked?.Invoke(this, e.GetPosition((IInputElement)sender));
    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
            CancelKeyDown?.Invoke(this, e);
    }
}