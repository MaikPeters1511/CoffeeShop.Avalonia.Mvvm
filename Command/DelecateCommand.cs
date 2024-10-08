﻿using System.Windows.Input;

namespace Avalonia.CoffeeShop.Command;

public class DelecateCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;
    private readonly Action<object?> _execute;
    private readonly Func<object?, bool>? _canExecute;


    public DelecateCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        ArgumentNullException.ThrowIfNull(execute, nameof(execute));
        _execute = execute;
        _canExecute = canExecute;
    }

    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    public bool CanExecute(object? parameter) => _canExecute is null || _canExecute(parameter);

    public void Execute(object? parameter) => _execute(parameter);
}