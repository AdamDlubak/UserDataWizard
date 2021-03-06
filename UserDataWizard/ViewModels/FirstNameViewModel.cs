﻿using UserDataWizard.Helpers;
using static UserDataWizard.ViewModels.MainWindowViewModel;

namespace UserDataWizard.ViewModels
{
  class FirstNameViewModel : PageViewModel
  {
    public override string UserInfo
    {
      get => User.FirstName;
      set
      {
        User.FirstName = value;
        PageValidation.FirstName = CheckCorrectionAndUpdate();
      }
    }

    protected override bool ValidateField(int fieldType = 0)
    {
      return LengthValidation(User.FirstName, 2, 50, "First name");
    }
  }
}