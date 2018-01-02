using System;
using System.Windows;

namespace PersonDataWizard.ViewModel
{
  class PhoneNumberViewModel : PageViewModel
  {
    public String ErrorDescription { get; set; }

    private bool _isCorrect;

    public Visibility IsCorrect => _isCorrect ? Visibility.Collapsed : Visibility.Visible;

    public override string UserInfo
    {
      get => MainWindowViewModel.User.PhoneNumber;
      set
      {
        MainWindowViewModel.User.PhoneNumber = value;
        _isCorrect = CheckCorrection();

      }
    }

    public override bool IsCorrectValidate()
    {
      if (MainWindowViewModel.User.PhoneNumber == String.Empty)
      {
        ErrorDescription = "This field cannot be empty!";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return false;
      }
      if (MainWindowViewModel.User.PhoneNumber.Length > 2 && MainWindowViewModel.User.PhoneNumber.Length <= 50)
      {
        ErrorDescription = "";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return true;
      }
      ErrorDescription = MainWindowViewModel.User.PhoneNumber.Length > 50
        ? "This field is too long! (max. 50 charakters)"
        : "This field is too short! (min. 3 charakters)";
      OnPropertyChanged("ErrorDescription");
      OnPropertyChanged("IsCorrect");
      return false;
    }
  }


}
