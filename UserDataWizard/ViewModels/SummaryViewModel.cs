using UserDataWizard.Helpers;

namespace UserDataWizard.ViewModels
{
  class SummaryViewModel : PageViewModel
  {
    public string FirstName => MainWindowViewModel.User.FirstName;
    public string LastName => MainWindowViewModel.User.LastName;
    public string Address => MainWindowViewModel.User.Street;
    public string AddressPostCode => MainWindowViewModel.User.PostCode;
    public string AddressCity => MainWindowViewModel.User.City;
    public string AddressCountry => MainWindowViewModel.User.Country;
    public string PhoneNumber => MainWindowViewModel.User.PhoneNumber;
    public override string UserInfo { get; set; }
    public override bool IsCorrectValidate()
    {
      throw new System.NotImplementedException();
    }
  }
}