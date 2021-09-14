using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Manager.Commmands
{
    public class RelayCommand:ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested += value;
        }
        public bool CanExecute(Object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }
        public void Execute(Object parameter)
        {
            execute(parameter);
        }
        public RelayCommand (Action<Object>execute, Func<object, bool>canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
    }
}
