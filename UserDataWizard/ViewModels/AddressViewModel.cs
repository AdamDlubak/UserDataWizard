using System.Text.RegularExpressions;
using UserDataWizard.Helpers;
using static UserDataWizard.ViewModels.MainWindowViewModel;

namespace UserDataWizard.ViewModels
{
  class AddressViewModel : PageViewModel
  {
    private bool _countryCorrection;
    private bool _postCodeCorrection;
    private bool _cityCorrection;
    private bool _addressCorrection;
    public static bool _isCorrect;


    public override string UserInfo
    {
      get => User.Street;
      set
      {
        User.Street = value;
        CheckCorrectionAndUpdate(1, "UserInfoCity");
      }
    }

    public string UserInfoPostCode
    {
      get => User.PostCode;
      set
      {
        User.PostCode = value;
        CheckCorrectionAndUpdate(2, "UserInfoPostCode");
      }
    }

    public string UserInfoCity
    {
      get => User.City;
      set
      {
        User.City = value;
        CheckCorrectionAndUpdate(3, "UserInfoCity");
      }
    }

    public string UserInfoCountry
    {
      get => User.Country;
      set
      {
        User.Country = value;
        CheckCorrectionAndUpdate(4, "UserInfoCountry");
      }
    }


    private bool CheckCityCorrection()
    {
      return LengthValidation(User.City, 2, 100);
    }

    private bool CheckCountryCorrection()
    {
      return LengthValidation(User.Country, 2, 100);
    }

    private bool CheckPostCodeCorrection()
    {
      Regex phoneNumberPattern = new Regex(@"^[0-9]{2}-[0-9]{3}$");
      if (User.PostCode == null)
      {
        ErrorDescription = "*Post Code field cannot be empty!";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return false;
      }
      if (phoneNumberPattern.IsMatch(User.PostCode))
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

    private bool CheckAddressStreetCorrection()
    {
      Regex AddressPattern = new Regex(@"^[\p{L}]{2,} [0-9]{1,}\s?(\/\s?[0-9]{1,})?$");
      if (User.Street == null)
      {
        ErrorDescription = "*Address Street field cannot be empty!";
        OnPropertyChanged("ErrorDescription");
        OnPropertyChanged("IsCorrect");
        return false;
      }
      if (AddressPattern.IsMatch(User.Street))
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


    public override bool ValidateField(int fieldType = 0)
    {
      switch (fieldType)
      {
        case 1:
          _addressCorrection = CheckAddressStreetCorrection();
          break;
        case 2:
          _postCodeCorrection = CheckPostCodeCorrection();
          break;
        case 3:
          _cityCorrection = CheckCityCorrection();
          break;
        case 4:
          _countryCorrection = CheckCountryCorrection();
          break;
        default:
          // Throw Exception
          break;
      }

      return _countryCorrection && _postCodeCorrection && _cityCorrection && _addressCorrection;
    }
  }
}