using System;
using System.Text.RegularExpressions;
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
      // Four different types of phone number, the last one include polish phone numbers.
      Regex phoneNumberPatternOne = new Regex(@"^((\+){0,1}91(\s){0,1}(\-){0,1}(\s){0,1}){0,1}9[0-9](\s){0,1}(\-){0,1}(\s){0,1}[1-9]{1}[0-9]{7}$");
      Regex phoneNumberPatternTwo = new Regex(@"^((\\+91-?)|0)?[0-9]{10}$");
      Regex phoneNumberPatternThree = new Regex(@"^((\\+|00)(\\d{1,3})[\\s-]?)?(\\d{10})$");
      Regex phoneNumberPatternFour = new Regex(@"^(?<!\w)(\(?(\+|00)?48\)?)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{3}(?!\w)?");
      if (phoneNumberPatternOne.IsMatch(MainWindowViewModel.User.PhoneNumber)
        || phoneNumberPatternTwo.IsMatch(MainWindowViewModel.User.PhoneNumber)
        || phoneNumberPatternThree.IsMatch(MainWindowViewModel.User.PhoneNumber)
        || phoneNumberPatternFour.IsMatch(MainWindowViewModel.User.PhoneNumber))
      {
        ErrorDescription = "";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return true;
      }
      ErrorDescription = "*Invalid Phone Number! \n Only digits and '+' character is available.";
      OnPropertyChanged("ErrorDescription");
      OnPropertyChanged("IsCorrect");
      return false;
    }
  }


}
