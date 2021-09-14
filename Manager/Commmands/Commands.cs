using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Manager.Commmands
{
    public class Commands : ICommand
    {
        private readonly Action _action;
        private Func<object> p;

        public Commands(Func<object> p)
        {
            this.p = p;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}
