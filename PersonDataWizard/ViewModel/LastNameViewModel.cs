using System;

namespace PersonDataWizard.ViewModel
{
  class LastNameViewModel : PageViewModel
  {
    public override string UserInfo
    {
      get => MainWindowViewModel.User.LastName;
      set
      {
        MainWindowViewModel.User.LastName = value;
        MainWindowViewModel.IsNextEnable = MainWindowViewModel.User.FirstName != String.Empty;
        OnPropertyChanged("UserInfo");
      }
    }
  }


}
