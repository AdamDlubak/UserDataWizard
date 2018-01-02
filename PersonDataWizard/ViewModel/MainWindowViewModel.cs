using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PersonDataWizard.ViewModel
{
  public class MainWindowViewModel : ViewModelBase
  {
    // ViewModel that is currently bound to the ContentControl
    private PageViewModel _currentViewModel;
    public PageViewModel CurrentViewModel
    {
      get { return _currentViewModel; }
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
    public ICommand LoadPreviousPageCommand { get; private set; }
    public ICommand LoadNextPageCommand { get; private set; }
    public MainWindowViewModel()
    {
      this.LoadPreviousPageCommand = new RelayCommand(o => this.LoadPreviousPage());
      this.LoadNextPageCommand = new RelayCommand(o => this.LoadNextPage());
      settings = new ObservableCollection<PageViewModel>
      {
        new WelcomeViewModel(),
        new NameViewModel(),
        new SurnameViewModel(),
        new AddressViewModel(),
        new PhoneNumberViewModel(),
        new SummaryViewModel()
      };
      CurrentViewModel = settings[0];



    }
    private void LoadPreviousPage()
    {
      CurrentViewModel = PreviousOf(settings, CurrentViewModel);
    }
    private void LoadNextPage()
    {
      CurrentViewModel = NextOf(settings, CurrentViewModel);
    }
    public static T NextOf<T>(ObservableCollection<T> list, T item)
    {
      return list[(list.IndexOf(item) + 1) == list.Count ? 0 : (list.IndexOf(item) + 1)];
    }
    public static T PreviousOf<T>(ObservableCollection<T> list, T item)
    {
      return list[(list.IndexOf(item) - 1) == list.Count ? 0 : (list.IndexOf(item) - 1)];
    }
  }
}
