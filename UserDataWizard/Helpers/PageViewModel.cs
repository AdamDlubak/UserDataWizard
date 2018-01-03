using System.Text.RegularExpressions;
using System.Windows;
using static UserDataWizard.ViewModels.MainWindowViewModel;

namespace UserDataWizard.Helpers
{
  public abstract class PageViewModel : ViewModelBase
  {
    public abstract string UserInfo { get; set; }
    public string ErrorDescription { get; set; }

    public abstract bool ValidateField(int fieldType = 0);
    private bool _isCorrect;


    public Visibility IsCorrect => _isCorrect ? Visibility.Collapsed : Visibility.Visible;

    public virtual bool CheckCorrectionAndUpdate(int fieldType = 0, string propertyChange = "UserInfo")
    {
      _isCorrect = ValidateField(fieldType);

      IsNextEnable = _isCorrect;

      OnPropertyChanged(propertyChange);
      return _isCorrect;
    }

    public virtual void OnChangeError(string description)
    {
      ErrorDescription = description;
      OnPropertyChanged("ErrorDescription");
      OnPropertyChanged("ShowError");
    }

    public virtual bool LengthValidation(string field, int minCharacters, int maxCharacters)
    {
      if (field == string.Empty)
      {
        OnChangeError("*This field cannot be empty!");
        return false;
      }
      if (field.Length > minCharacters && field.Length <= maxCharacters)
      {
        OnChangeError("");
        return true;
      }
      OnChangeError(field.Length > maxCharacters
        ? "*This field is too long! (max. " + maxCharacters + " charakters)"
        : "*This field is too short! (min. " + minCharacters + 1 + " charakters)");
      return false;
    }

    public virtual bool RegexValidation(string field, Regex regex, string errorDescription)
    {
      if (regex.IsMatch(field))
      {
        OnChangeError("");
        return true;
      }
      OnChangeError(errorDescription);
      return false;
    }
  }
}