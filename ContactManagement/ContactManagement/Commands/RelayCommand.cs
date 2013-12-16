using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Diagnostics;

namespace Contactmanagement.Commands
{
    public class RelayCommand : ICommand
    {
        #region Member Fields

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #endregion

        #region Constructors

        public RelayCommand(Action<object> execute)
            : this(null, execute)
        {
        }

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion // Constructors

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion
    }
}
