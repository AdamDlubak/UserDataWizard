using System;
using System.Windows.Input;

namespace UserDataWizard.Helpers
{
  public class RelayCommand : ICommand
  {
    // Action to be performed when this command is executed
    private Action<object> executionAction;

    // Predicate to determine if the command is valid for execution
    private Predicate<object> canExecutePredicate;


    // Initializes a new instance of the DelegateCommand class.
    // The command will always be valid for execution.
    public RelayCommand(Action<object> execute)
      : this(execute, null)
    {
    }

    // Initializes a new instance of the DelegateCommand class.
    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    {
      executionAction = execute ?? throw new ArgumentNullException("execute");
      canExecutePredicate = canExecute;
    }

    // Raised when CanExecute is changed
    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    // Executes the delegate backing this DelegateCommand
    public bool CanExecute(object parameter)
    {
      return canExecutePredicate == null ? true : canExecutePredicate(parameter);
    }


    // Executes the delegate backing this DelegateCommand
    public void Execute(object parameter)
    {
      if (!CanExecute(parameter))
      {
        throw new InvalidOperationException(
          "The command is not valid for execution, check the CanExecute method before attempting to execute.");
      }
      executionAction(parameter);
    }
  }
}