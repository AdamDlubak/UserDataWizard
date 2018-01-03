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
      var postCodePattern = new Regex(@"^[0-9]{2}-[0-9]{3}$");
      const string errorEmptyDescription = "*Post Code field cannot be empty!";
      const string errorDescription = "*Invalid Post Code field! \n(Correct example: 98-330)";

      return RegexValidation(User.PostCode, postCodePattern, errorEmptyDescription, errorDescription);
    }

    private bool CheckAddressStreetCorrection()
    {
      var addressPattern = new Regex(@"^[\p{L}]{2,} [0-9]{1,}\s?(\/\s?[0-9]{1,})?$");
      const string errorEmptyDescription = "*Address Street field cannot be empty!";
      const string errorDescription = "*Invalid Street Address field! \n(Correct example: Wschodnia 1/12)";

      return RegexValidation(User.Street, addressPattern, errorEmptyDescription, errorDescription);
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