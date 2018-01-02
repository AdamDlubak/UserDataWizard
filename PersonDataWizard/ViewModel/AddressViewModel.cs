using System;

namespace PersonDataWizard.ViewModel
{
  class AddressViewModel : PageViewModel
  {
    public override string UserInfo
    {
      get => MainWindowViewModel.User.Address;
      set
      {
        MainWindowViewModel.User.Address = value;
        MainWindowViewModel.IsNextEnable = MainWindowViewModel.User.FirstName != String.Empty;
        OnPropertyChanged("UserInfo");
      }
    }
  }


}
