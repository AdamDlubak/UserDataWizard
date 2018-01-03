using UserDataWizard.Helpers;
using static UserDataWizard.ViewModels.MainWindowViewModel;

namespace UserDataWizard.ViewModels
{
  class LastNameViewModel : PageViewModel
  {

    public override string UserInfo
    {
      get => User.LastName;
      set
      {
        User.LastName = value;
        PageValidation.LastName = CheckCorrectionAndUpdate();
      }
    }

    protected override bool ValidateField(int fieldType = 0)
    {
      return LengthValidation(User.LastName, 2, 50, "Last name");
    }
  }
}