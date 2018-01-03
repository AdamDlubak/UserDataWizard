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
        CheckCorrectionAndUpdate();
      }
    }

    public override bool ValidateField(int fieldType = 0)
    {
      return LengthValidation(User.LastName, 2, 50);
    }
  }
}