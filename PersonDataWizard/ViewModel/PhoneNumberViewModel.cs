﻿using System;

namespace PersonDataWizard.ViewModel
{
  class PhoneNumberViewModel : PageViewModel
  {
    public override string UserInfo
    {
      get => MainWindowViewModel.User.PhoneNumber;
      set
      {
        MainWindowViewModel.User.PhoneNumber = value;
        MainWindowViewModel.IsNextEnable = MainWindowViewModel.User.FirstName != String.Empty;
        OnPropertyChanged("UserInfo");
      }
    }
  }


}
