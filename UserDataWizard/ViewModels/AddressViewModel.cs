using System;
using System.Text.RegularExpressions;
using System.Windows;
using PersonDataWizard.Helpers;

namespace PersonDataWizard.ViewModels
{
  class AddressViewModel : PageViewModel
  {
    public String ErrorDescription { get; set; }
    private bool _countryCorrection;
    private bool _postCodeCorrection;
    private bool _cityCorrection;
    private bool _addressCorrection;
    public static bool _isCorrect;

    public Visibility IsCorrect => _isCorrect ? Visibility.Collapsed : Visibility.Visible;


    public override string UserInfo
    {
      get => MainWindowViewModel.User.Street;
      set
      {
        MainWindowViewModel.User.Street = value;
        _addressCorrection = IsCorrectValidate();
        if (_countryCorrection && _postCodeCorrection && _cityCorrection && _addressCorrection)
        {
          _isCorrect = true;
          MainWindowViewModel.IsPreviousEnable = true;
        }
        else _isCorrect = false;

        MainWindowViewModel.IsNextEnable = _isCorrect;
        OnPropertyChanged("UserInfoCity");
      }
    }

    public string UserInfoPostCode
    {
      get => MainWindowViewModel.User.PostCode;
      set
      {
        MainWindowViewModel.User.PostCode = value;
        _postCodeCorrection = CheckPostCodeCorrection();
        if (_countryCorrection && _postCodeCorrection && _cityCorrection && _addressCorrection)
        {
          _isCorrect = true;
          MainWindowViewModel.IsPreviousEnable = true;
        }
        else _isCorrect = false;

        MainWindowViewModel.IsNextEnable = _isCorrect;
        OnPropertyChanged("UserInfoPostCode");
      }
    }

    public string UserInfoCity
    {
      get => MainWindowViewModel.User.City;
      set
      {
        MainWindowViewModel.User.City = value;
        _cityCorrection = CheckCityCorrection();
        if (_countryCorrection && _postCodeCorrection && _cityCorrection && _addressCorrection)
        {
          _isCorrect = true;
          MainWindowViewModel.IsPreviousEnable = true;
        }
        else _isCorrect = false;

        MainWindowViewModel.IsNextEnable = _isCorrect;
        OnPropertyChanged("UserInfoCity");
      }
    }

    public string UserInfoCountry
    {
      get => MainWindowViewModel.User.Country;
      set
      {
        MainWindowViewModel.User.Country = value;
        _countryCorrection = CheckCountryCorrection();
        if (_countryCorrection && _postCodeCorrection && _cityCorrection && _addressCorrection)
        {
          _isCorrect = true;
          MainWindowViewModel.IsPreviousEnable = true;
        }
        else _isCorrect = false;

        MainWindowViewModel.IsNextEnable = _isCorrect;
        OnPropertyChanged("UserInfoCountry");
      }
    }


    private bool CheckCityCorrection()
    {
      if (MainWindowViewModel.User.City == null)
      {
        ErrorDescription = "*City field cannot be empty!";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return false;
      }
      if (MainWindowViewModel.User.City.Length > 2 && MainWindowViewModel.User.City.Length <= 100)
      {
        ErrorDescription = "";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return true;
      }
      ErrorDescription = MainWindowViewModel.User.City.Length > 100
        ? "City field is too long! (max. 100 charakters)"
        : "City field is too short! (min. 3 charakters)";
      OnPropertyChanged("ErrorDescription");
      OnPropertyChanged("IsCorrect");
      return false;
    }

    private bool CheckCountryCorrection()
    {
      if (MainWindowViewModel.User.Country == null)
      {
        ErrorDescription = "*Country field cannot be empty!";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return false;
      }
      if (MainWindowViewModel.User.Country.Length > 2 && MainWindowViewModel.User.Country.Length <= 100)
      {
        ErrorDescription = "";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return true;
      }
      ErrorDescription = MainWindowViewModel.User.Country.Length > 100
        ? "Country field is too long! (max. 100 charakters)"
        : "Country field is too short! (min. 3 charakters)";
      OnPropertyChanged("ErrorDescription");
      OnPropertyChanged("IsCorrect");
      return false;
    }

    private bool CheckPostCodeCorrection()
    {
      Regex phoneNumberPattern = new Regex(@"^[0-9]{2}-[0-9]{3}$");
      if (MainWindowViewModel.User.PostCode == null)
      {
        ErrorDescription = "*Post Code field cannot be empty!";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return false;
      }
      if (phoneNumberPattern.IsMatch(MainWindowViewModel.User.PostCode))
      {
        ErrorDescription = "";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return true;
      }
      ErrorDescription = "*Invalid Post Code field! \n(Correct example: 98-330)";
      OnPropertyChanged("ErrorDescription");
      OnPropertyChanged("IsCorrect");
      return false;
    }

    public override bool IsCorrectValidate()
    {
      Regex AddressPattern = new Regex(@"^[\p{L}]{2,} [0-9]{1,}\s?(\/\s?[0-9]{1,})?$");
      if (MainWindowViewModel.User.Street == null)
      {
        ErrorDescription = "*Address Street field cannot be empty!";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return false;
      }
      if (AddressPattern.IsMatch(MainWindowViewModel.User.Street))
      {
        ErrorDescription = "";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return true;
      }
      ErrorDescription = "*Invalid Street Address field! \n(Correct example: Wschodnia 1/12)";
      OnPropertyChanged("ErrorDescription");
      OnPropertyChanged("IsCorrect");
      return false;
    }
  }
}