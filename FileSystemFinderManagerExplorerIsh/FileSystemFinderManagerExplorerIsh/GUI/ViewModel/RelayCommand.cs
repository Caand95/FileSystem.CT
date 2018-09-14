using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FileExplorer.GUI.ViewModel
{
    public class RelayCommand : ICommand
    {

        #region Fields
        /// <summary>
        /// Used to contain the Execute delegate
        /// </summary>
        private readonly ExecuteMethod _execute;
        /// <summary>
        /// Used to contain the CanExecute delegate
        /// </summary>
        private readonly CanExecuteMethod _canExecute;
        /// <summary>
        /// Used to contain the previous CanExecute value.
        /// This is used to determine if the <see cref="CanExecuteChanged"/> event should be thrown.
        /// </summary>
        private bool _previousCanExecuteValue = true;
        #endregion

        #region Constructors

        /// <summary>
        /// Intantiates a new RelayCommand with a delegate to be executed when the command is called.
        /// There is no check to make sure the command can be called.
        /// </summary>
        /// <param name="execute">The method to be executed when the command is called.</param>
        public RelayCommand(ExecuteMethod execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Instantiates a new RelayCommand with a delegate to be executed when the command is called, and a predicate to check if the command can be called.
        /// </summary>
        /// <param name="execute">The method to be exeucted when the command is called.</param>
        /// <param name="canExecute">The predicate to check if the command is callable.</param>
        public RelayCommand(ExecuteMethod execute, CanExecuteMethod canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand
        /// <summary>
        /// Will check to see if the method can be run.
        /// </summary>
        /// <param name="parameter">A parameter to use in the check.</param>
        /// <returns>True: The method can be run. False: The method cannot be run.</returns>
        public bool CanExecute(object parameter = null)
        {
            _previousCanExecuteValue = _canExecute == null ? true : _canExecute(parameter);
            return _previousCanExecuteValue;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Executes the method specified in the contructor.
        /// </summary>
        /// <param name="parameter">A parameter to pass to the method.</param>
        public void Execute(object parameter = null)
        {
            _execute(parameter);
            if (_previousCanExecuteValue != CanExecute(parameter) && this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, null);
            }
        }
        #endregion

        #region Delegates

        public delegate void ExecuteMethod(object parameter);
        public delegate bool CanExecuteMethod(object parameter);

        #endregion

        public void RaiseCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}
