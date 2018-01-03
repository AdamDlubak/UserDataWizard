using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using PersonDataWizard.Models;
using UserDataWizard.Helpers;
using UserDataWizard.Models;

namespace UserDataWizard.ViewModels
{
  public class MainWindowViewModel : ViewModelBase
  {
    public static User User;
    public static PageValidation PageValidation;

    private PageViewModel _currentViewModel;
    private static bool _isNextEnable;
    private static bool _isCancelEnable;
    private static bool _isPreviousEnable;
    private static bool _isFinishPage;

    public ICommand PreviousCommand { get; }
    public ICommand NextCommand { get; }
    public ICommand CancelCommand { get; }

    public string NextButtonContent { get; set; }
    public static bool IsNextEnable
    {
      get => _isNextEnable;

      set
      {
        _isNextEnable = value;
        RaiseStaticPropertyChanged("NextCommand");
      }
    }
    public static bool IsCancelEnable
    {
      get => _isCancelEnable;

      set
      {
        _isCancelEnable = value;
        RaiseStaticPropertyChanged("CancelCommand");
      }
    }
    public static bool IsPreviousEnable
    {
      get => _isPreviousEnable;

      set
      {
        _isPreviousEnable = value;
        RaiseStaticPropertyChanged("PreviousCommand");
      }
    }
    public static bool IsFinishPage
    {
      get => _isFinishPage;

      set
      {
        _isFinishPage = value;
        RaiseStaticPropertyChanged("NextCommand");
      }
    }


    public PageViewModel CurrentViewModel
    {
      get => _currentViewModel;
      set
      {
        _currentViewModel = value;
        OnPropertyChanged("CurrentViewModel");
      }
    }

    public ObservableCollection<PageViewModel> Settings { get; }

    public bool IsNextCorrect(object state)
    {
      return IsNextEnable;
    }
    public bool IsPreviousCorrect(object state)
    {
      return IsPreviousEnable;
    }
    public bool IsCancelPossible(object state)
    {
      return IsCancelEnable;
    }

    public MainWindowViewModel()
    {
      PreviousCommand = new RelayCommand(o => PreviousPage(), IsPreviousCorrect);
      NextCommand = new RelayCommand(o => NextPage(), IsNextCorrect);
      CancelCommand = new RelayCommand(o => CancelApplication(), IsCancelPossible);
      Settings = new ObservableCollection<PageViewModel>
      {
        new WelcomeViewModel(),
        new FirstNameViewModel(),
        new LastNameViewModel(),
        new AddressViewModel(),
        new PhoneNumberViewModel(),
        new SummaryViewModel()
      };
      CurrentViewModel = Settings[0];
      IsPreviousEnable = true;
      IsNextEnable = true;
      IsCancelEnable = true;
      NextButtonContent = "Next";
    }

    private void PreviousPage()
    {
      if (IsFinishPage && NextButtonContent == "Finish")
      {
        IsCancelEnable = true;
        NextButtonContent = "Next";
        OnPropertyChanged("NextButtonContent");
      }
      OnPropertyChanged("IsPreviousEnable");

      CurrentViewModel = PreviousOf(Settings, CurrentViewModel);
    }
    private void NextPage()
    {
      if (IsFinishPage && NextButtonContent == "Finish")
      {
        Application.Current.Shutdown();
      }
      else if (IsFinishPage)
      {
        NextButtonContent = "Finish";
        OnPropertyChanged("NextButtonContent");
      }
      if(!IsPreviousEnable) IsPreviousEnable = true;
      CurrentViewModel = NextOf(Settings, CurrentViewModel);
    }
    private void CancelApplication()
    {
      Application.Current.Shutdown();
    }

    public static T NextOf<T>(ObservableCollection<T> list, T item)
    {
      if (User == null) User = new User();
      if (PageValidation == null) PageValidation = new PageValidation();
      return list[(list.IndexOf(item) + 1) == list.Count ? 0 : (list.IndexOf(item) + 1)];
    }
    public static T PreviousOf<T>(ObservableCollection<T> list, T item)
    {
      return list[(list.IndexOf(item) - 1) == -1 ? 0 : (list.IndexOf(item) - 1)];
    }
  }
}
