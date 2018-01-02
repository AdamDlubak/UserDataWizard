namespace PersonDataWizard.ViewModel
{
  class SummaryViewModel : PageViewModel
  {
    public string FirstName => MainWindowViewModel.User.FirstName;
    public string LastName => MainWindowViewModel.User.LastName;
    public string Address => MainWindowViewModel.User.AddressStreet;
    public string AddressPostCode => MainWindowViewModel.User.AddressPostCode;
    public string AddressCity => MainWindowViewModel.User.AddressCity;
    public string AddressCountry => MainWindowViewModel.User.AddressCountry;
    public string PhoneNumber => MainWindowViewModel.User.PhoneNumber;
    public override string UserInfo { get; set; }
    public override bool IsCorrectValidate()
    {
      throw new System.NotImplementedException();
    }
  }
}