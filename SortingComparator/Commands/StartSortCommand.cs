using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SortingComparator.Commands
{
    public class StartSortCommand : ICommand
    {
        private Action action;
        private Func<object, bool> canExecute;

        public event EventHandler? CanExecuteChanged;

        public StartSortCommand(Action action, Func<object, bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object? parameter)
        {
            action();
        }
    }
}
