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

        public event EventHandler? CanExecuteChanged;

        public StartSortCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            action();
        }
    }
}
