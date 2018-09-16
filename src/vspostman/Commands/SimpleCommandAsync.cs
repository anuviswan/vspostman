using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsPostman.Commands
{
    public class SimpleCommandAsync : ICommandAsync
    {
        private Func<Task> _execute;
        private Func<bool> _canExecute;
        public event EventHandler CanExecuteChanged;

        public SimpleCommandAsync(Func<Task> execute) : this(execute, null) { }

        public SimpleCommandAsync(Func<Task> execute, Func<bool> canExecute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();
        public async void Execute(object parameter) => await ExecuteAsync(parameter);

        public async Task ExecuteAsync(object parameter)=> await _execute();

    }
}
