using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PersonDataWizard.Model;

namespace PersonDataWizard.ViewModel
{
  public class MainWindowViewModel : ViewModelBase
  {
    private PageViewModel _currentViewModel;

    private static bool _isNextEnable;
    private static bool _isCancelEnable;
    private static bool _isPreviousEnable;

    public String NextButtonContent { get; set; }

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

    private static bool _isFinishPage;

    public static bool IsFinishPage
    {
      get => _isFinishPage;

      set
      {
        _isFinishPage = value;
        RaiseStaticPropertyChanged("NextCommand");
      }
    }

    public static User User;
    public PageViewModel CurrentViewModel
    {
      get => _currentViewModel;
      set
      {
        _currentViewModel = value;
        this.OnPropertyChanged("CurrentViewModel");
      }
    }

    private readonly ObservableCollection<PageViewModel> settings;
    public PageViewModel pageViewModel;
    public ObservableCollection<PageViewModel> Settings
    {
      get { return this.settings; }
    }

    public bool IsCorrect(object state)
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
    public ICommand PreviousCommand { get; private set; }
    public ICommand NextCommand { get; private set; }
    public ICommand CancelCommand { get; private set; }
    public MainWindowViewModel()
    {
      this.PreviousCommand = new RelayCommand(o => PreviousPage(), IsPreviousCorrect);
      this.NextCommand = new RelayCommand(o => NextPage(), IsCorrect);
      this.CancelCommand = new RelayCommand(o => CancelApplication(), IsCancelPossible);
      settings = new ObservableCollection<PageViewModel>
      {
        new WelcomeViewModel(),
        new FirstNameViewModel(),
        new LastNameViewModel(),
        new AddressViewModel(),
        new PhoneNumberViewModel(),
        new SummaryViewModel()
      };
      CurrentViewModel = settings[0];
      IsPreviousEnable = true;
      IsNextEnable = true;
      IsCancelEnable = true;
      NextButtonContent = "Next";

    }

    private void PreviousPage()
    {
      if (IsFinishPage && NextButtonContent == "Finish")
      {
        NextButtonContent = "Next";
        IsCancelEnable = true;
        OnPropertyChanged("NextButtonContent");
      }
      OnPropertyChanged("IsPreviousEnable");

      CurrentViewModel = PreviousOf(settings, CurrentViewModel);

    }
    private void NextPage()
    {
      if (IsFinishPage && NextButtonContent == "Finish")
      {
        System.Windows.Application.Current.Shutdown();
      }
      if (IsFinishPage)
      {
        NextButtonContent = "Finish";
        OnPropertyChanged("NextButtonContent");
      }
      IsPreviousEnable = true;
      CurrentViewModel = NextOf(settings, CurrentViewModel);
    }
    private void CancelApplication()
    {
      System.Windows.Application.Current.Shutdown();
    }

    public static T NextOf<T>(ObservableCollection<T> list, T item)
    {
      if (User == null) User = new User();
      return list[(list.IndexOf(item) + 1) == list.Count ? 0 : (list.IndexOf(item) + 1)];
    }
    public static T PreviousOf<T>(ObservableCollection<T> list, T item)
    {
      return list[(list.IndexOf(item) - 1) == -1 ? 0 : (list.IndexOf(item) - 1)];
    }
  }
}
