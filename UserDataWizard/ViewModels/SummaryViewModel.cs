using UserDataWizard.Helpers;
using static UserDataWizard.ViewModels.MainWindowViewModel;

namespace UserDataWizard.ViewModels
{
  class SummaryViewModel : PageViewModel
  {
    public string FirstName => User.FirstName;
    public string LastName => User.LastName;
    public string AddressStreet => User.Street;
    public string AddressPostCode => User.PostCode;
    public string AddressCity => User.City;
    public string AddressCountry => User.Country;
    public string PhoneNumber => User.PhoneNumber;
    public override string UserInfo { get; set; }
    protected override bool ValidateField(int fieldType = 0)
    {
      throw new System.NotImplementedException();
    }
  }
}