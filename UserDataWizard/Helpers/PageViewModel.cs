using System.Text.RegularExpressions;
using System.Windows;
using static UserDataWizard.ViewModels.MainWindowViewModel;

namespace UserDataWizard.Helpers
{
  public abstract class PageViewModel : ViewModelBase
  {
    private bool _isCorrect;
    public abstract string UserInfo { get; set; }
    public string ErrorDescription { get; set; }
    protected abstract bool ValidateField(int fieldType = 0);

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

    public virtual bool LengthValidation(string field, int minCharacters, int maxCharacters, string fieldName)
    {
      if (field == string.Empty)
      {
        OnChangeError("*" + fieldName + " cannot be empty!");
        return false;
      }
      if (field.Length > minCharacters && field.Length <= maxCharacters)
      {
        OnChangeError("");
        return true;
      }
      OnChangeError(field.Length > maxCharacters
        ? "*" + fieldName + " is too long! (max. " + maxCharacters + " characters)"
        : "*" + fieldName + " is too short! (min. " + minCharacters + 1 + " characters)");
      return false;
    }

    public virtual bool RegexValidation(string field, Regex regex, string errorEmptyDescription, string errorDescription)
    {
      if (field == null)
      {
        OnChangeError(errorEmptyDescription);
        return false;
      }
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