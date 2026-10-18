using System;
using System.Windows.Input;

namespace GeometryApp.Utilities;

public class RelayCommandWithoutParameter(Action execute, Func<object, bool> canExecute = null) : ICommand
{
    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
    public bool CanExecute(object parameter) => canExecute == null || canExecute(parameter);
    public void Execute(object parameter) => execute();
}