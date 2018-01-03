using System;
using UserDataWizard.Helpers;

namespace UserDataWizard.ViewModels
{
  class WelcomeViewModel : PageViewModel
  {
    public override string UserInfo { get; set; }

    protected override bool ValidateField(int fieldType = 0)
    {
      throw new NotImplementedException();
    }
  }
}