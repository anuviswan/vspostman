using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VsPostman
{
    public class SimpleCommand : ICommand
    {
        private Action _actionToExecute;
        private Func<bool> _canExecute;
        public event EventHandler CanExecuteChanged;

        public SimpleCommand(Action execute) : this(execute, null) { }
        
        public SimpleCommand(Action execute,Func<bool> canExecute)
        {
            _canExecute = canExecute;
            _actionToExecute = execute;
        }
        public bool CanExecute(object parameter)=> _canExecute == null || _canExecute();
        public void Execute(object parameter) => _actionToExecute.Invoke();
        
    }
}
