using UserDataWizard.Helpers;

namespace UserDataWizard.ViewModels
{
    class WelcomeViewModel : PageViewModel
  {
    public override string UserInfo { get; set; }
    public override bool ValidateField()
    {
      throw new System.NotImplementedException();
    }
  }
}
