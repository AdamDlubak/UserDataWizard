using PersonDataWizard.ViewModels;

namespace PersonDataWizard.Helpers
{
  public abstract class PageViewModel : ViewModelBase
  {
    public abstract string UserInfo { get; set; }
    public abstract bool IsCorrectValidate();

    public virtual bool CheckCorrection()
    {
      bool isCorrect = IsCorrectValidate();

      MainWindowViewModel.IsPreviousEnable = true;
      MainWindowViewModel.IsNextEnable = isCorrect;
      OnPropertyChanged("UserInfo");
      return isCorrect;
    }
  }
}