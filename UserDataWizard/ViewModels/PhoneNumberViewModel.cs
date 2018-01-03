using System.Text.RegularExpressions;
using UserDataWizard.Helpers;
using static UserDataWizard.ViewModels.MainWindowViewModel;

namespace UserDataWizard.ViewModels
{
  class PhoneNumberViewModel : PageViewModel
  {
    public override string UserInfo
    {
      get => User.PhoneNumber;
      set
      {
        User.PhoneNumber = value;
        CheckCorrectionAndUpdate();
      }
    }

    public override bool ValidateField(int fieldType = 0)
    {
      var phoneNumberPattern = new Regex(@"^(?<!\w)(\(?(\+|00)?48\)?)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{3}(?!\w)?");
      return RegexValidation(User.PhoneNumber, phoneNumberPattern);
    }
  }
}