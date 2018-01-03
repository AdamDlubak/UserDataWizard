using System;
using System.Windows;
using UserDataWizard.Helpers;

namespace UserDataWizard.ViewModels
{
  class FirstNameViewModel : PageViewModel
  {
    public String ErrorDescription { get; set; }

    private bool _isCorrect;

    public Visibility IsCorrect => _isCorrect ? Visibility.Collapsed : Visibility.Visible;

    public override string UserInfo
    {
      get => MainWindowViewModel.User.FirstName;
      set
      {
        MainWindowViewModel.User.FirstName = value;
        _isCorrect = CheckCorrection();
      }
    }

    public override bool IsCorrectValidate()
    {
      if (MainWindowViewModel.User.FirstName == String.Empty)
      {
        ErrorDescription = "This field cannot be empty!";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return false;
      }
      if (MainWindowViewModel.User.FirstName.Length > 2 && MainWindowViewModel.User.FirstName.Length <= 50)
      {
        ErrorDescription = "";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return true;
      }
      ErrorDescription = MainWindowViewModel.User.FirstName.Length > 50
        ? "This field is too long! (max. 50 charakters)"
        : "This field is too short! (min. 3 charakters)";
      OnPropertyChanged("ErrorDescription");
      OnPropertyChanged("IsCorrect");
      return false;
    }
  }
}