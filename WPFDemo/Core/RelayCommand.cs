using System;
using System.Windows.Input;

namespace WPFDemo.Core
{
    /// <summary>
    ///  Used to allow easy databinding from DataContext to active controls, like buttons since
    ///  you cannot bind methods directly.
    /// </summary>
    class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecture = null)
        {
            _execute = execute;
            _canExecute = canExecture;
        }

        public bool CanExecute(object parameter) 
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
