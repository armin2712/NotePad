using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.Window.Support
{
    /// <summary>
    /// Provides an Object for Command 
    /// Binding 
    /// </summary>
    public class BaseCommand : object,
        ICommand
    {
        /// <summary>
        /// Triggers if there's a change on CanExecute
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add
            {
                System.Windows.Input.CommandManager
                    .RequerySuggested += value;
            }
            remove
            {
                System.Windows.Input.CommandManager 
                    .RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Returns True if the Command is allowed
        /// </summary>
        /// <param name="parameter">Additional information
        /// for binding</param>

        public bool CanExecute(object? parameter)
        {
            return _CanExecute
                == null ? true : _CanExecute(parameter!);
        }

        /// <summary>
        /// Runs the Method that's in this Object
        /// </summary>
        /// <param name="parameter">Additional information
        /// for binding</param>
        public void Execute(object? parameter)
        {
            _Execute(parameter!);
        }

        /// <summary>
        /// Provides the Method, that checks if the Command
        /// can be executed
        /// </summary>
        private Predicate<object> _CanExecute = null!;

        /// <summary>
        /// Provides the Method for Executing
        /// </summary>
        private Action<object> _Execute = null!;

        /// <summary>
        ///Starts new Command
        /// </summary>
        /// <param name="execute">Method that will be run</param>
        public BaseCommand(Action<object> execute)
            : this(execute, canExecute: null!)
        {

        }

        /// <summary>
        /// Starts new Command
        /// </summary>
        /// <param name="execute">The Method that will be run</param>
        /// <param name="canExecute">The Method that checks
        /// if the Command can be executed</param>
        public BaseCommand(Action<object> execute,
            Predicate<object> canExecute)
        {
            _CanExecute = canExecute;
            _Execute = execute;
        }

    }
}
