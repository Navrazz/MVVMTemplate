using System;
using System.Windows.Input;

namespace MVVMTemplate.Extensions
{
    public class RelayCommand : ICommand
    {
        private Action<object>     execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="DelegateCommand{object}"/>.
        /// </summary>
        /// <param name="execute">Delegate to execute when Execute is called on the command.  This can be null to just hook up a CanExecute delegate.</param>
        /// <remarks><seealso cref="CanExecute"/> will always return true.</remarks>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        { }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute    = execute ?? throw new ArgumentNullException("execute");
            this.canExecute = canExecute;
        }

        #endregion

        ///<summary>
        ///Occurs when changes occur that affect whether or not the command should execute.
        ///</summary>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null ? true : this.canExecute(parameter);
        }

        ///<summary>
        ///Defines the method to be called when the command is invoked.
        ///</summary>
        ///<param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
