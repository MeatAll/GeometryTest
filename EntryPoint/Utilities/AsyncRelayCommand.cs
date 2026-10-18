using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GeometryApp.Utilities;

public class AsyncRelayCommand(Func<Task> execute, Func<bool> canExecute = null) : ICommand
{
    private bool _isExecuting;
    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
    public bool CanExecute(object parameter) => !_isExecuting && (canExecute?.Invoke() ?? true);
    public async void Execute(object parameter)
    {
        if (!CanExecute(parameter)) return;

        _isExecuting = true;

        CommandManager.InvalidateRequerySuggested();

        try
        {
            await execute();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            _isExecuting = false;

            CommandManager.InvalidateRequerySuggested();
        }
    }
}
