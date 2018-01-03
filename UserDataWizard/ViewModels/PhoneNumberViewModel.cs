using System;
using System.Text.RegularExpressions;
using System.Windows;
using PersonDataWizard.Helpers;

namespace PersonDataWizard.ViewModels
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
      Regex phoneNumberPattern = new Regex(@"^(?<!\w)(\(?(\+|00)?48\)?)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{3}(?!\w)?");
      if (phoneNumberPattern.IsMatch(MainWindowViewModel.User.PhoneNumber))
      {
        ErrorDescription = "";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return true;
      }
      ErrorDescription = "*Invalid Phone Number! \n Only digits and '+' character are available.";
      OnPropertyChanged("ErrorDescription");
      OnPropertyChanged("IsCorrect");
      return false;
    }
  }


}
