namespace PersonDataWizard.ViewModel
{
  class SummaryViewModel : PageViewModel
  {
    public string FirstName => MainWindowViewModel.User.FirstName;
    public string LastName => MainWindowViewModel.User.LastName;
    public string Address => MainWindowViewModel.User.Address;
    public string PhoneNumber => MainWindowViewModel.User.PhoneNumber;
    public override string UserInfo { get; set; }
  }
}