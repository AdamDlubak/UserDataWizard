using System;
using System.Windows;

namespace PersonDataWizard.ViewModel
{
  class AddressViewModel : PageViewModel
  {
    public String ErrorDescription { get; set; }

    private bool _isCorrect;

    public Visibility IsCorrect => _isCorrect ? Visibility.Collapsed : Visibility.Visible;

    public override string UserInfo
    {
      get => MainWindowViewModel.User.AddressStreet;
      set
      {
        MainWindowViewModel.User.AddressStreet = value;
        _isCorrect = CheckCorrection();
      }
    }
    public string UserInfoPostCode
    {
      get => MainWindowViewModel.User.AddressPostCode;
      set
      {
        MainWindowViewModel.User.AddressPostCode = value;
        _isCorrect = CheckPostCodeCorrection();
      }
    }
    public string UserInfoCity
    {
      get => MainWindowViewModel.User.AddressCity;
      set
      {
        MainWindowViewModel.User.AddressCity = value;
        _isCorrect = CheckCityCorrection();
      }
    }

    private bool CheckCityCorrection()
    {
      throw new NotImplementedException();
    }

    public string UserInfoCountry
    {
      get => MainWindowViewModel.User.AddressCountry;
      set
      {
        MainWindowViewModel.User.AddressCountry = value;
        _isCorrect = CheckCountryCorrection();
      }
    }

    private bool CheckCountryCorrection()
    {
      throw new NotImplementedException();
    }

    private bool CheckPostCodeCorrection()
    {
      throw new NotImplementedException();
    }

    public override bool IsCorrectValidate()
    {
      if (MainWindowViewModel.User.AddressStreet == String.Empty)
      {
        ErrorDescription = "This field cannot be empty!";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return false;
      }
      if (MainWindowViewModel.User.AddressStreet.Length > 2 && MainWindowViewModel.User.AddressStreet.Length <= 50)
      {
        ErrorDescription = "";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return true;
      }
      ErrorDescription = MainWindowViewModel.User.AddressStreet.Length > 50
        ? "This field is too long! (max. 50 charakters)"
        : "This field is too short! (min. 3 charakters)";
      OnPropertyChanged("ErrorDescription");
      OnPropertyChanged("IsCorrect");
      return false;
    }
  }


}
