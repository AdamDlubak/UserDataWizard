using System;
using System.Windows;

namespace PersonDataWizard.ViewModel
{
  class FirstNameViewModel : PageViewModel
  {
    public String ErrorDescription { get; set; }

    private bool _isCorrect;

    public Visibility IsCorrect
    {
      get { return _isCorrect ? Visibility.Collapsed : Visibility.Visible; }
    }

    public override string UserInfo
    {
      get => MainWindowViewModel.User.FirstName;
      set
      {
        MainWindowViewModel.User.FirstName = value;
        MainWindowViewModel.IsNextEnable = MainWindowViewModel.User.FirstName != String.Empty;
        _isCorrect = IsCorrectValidate();
        OnPropertyChanged("IsCorrect");

        MainWindowViewModel.IsPreviousEnable = true;
        MainWindowViewModel.IsNextEnable = _isCorrect;
        OnPropertyChanged("UserInfo");
      }
    }

    private bool IsCorrectValidate()
    {
      if (MainWindowViewModel.User.FirstName == String.Empty)
      {
        ErrorDescription = "This field cannot be empty!";
        OnPropertyChanged("ErrorDescription");
        return false;
      }
      if (MainWindowViewModel.User.FirstName.Length > 2 && MainWindowViewModel.User.FirstName.Length <= 50) return true;
      ErrorDescription = MainWindowViewModel.User.FirstName.Length > 50
        ? "This field is too long! (max. 50 charakters)"
        : "This field is too short! (min. 3 charakters)";
      OnPropertyChanged("ErrorDescription");
      return false;
    }
  }
}