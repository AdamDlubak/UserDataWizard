using System.Windows;
using System.Windows.Controls;
using UserDataWizard.ViewModels;

namespace UserDataWizard.Views
{
  public partial class WelcomeView : UserControl
  {
    public WelcomeView()
    {
      InitializeComponent();
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
      MainWindowViewModel.IsPreviousEnable = false;
      MainWindowViewModel.IsNextEnable = true;
    }
  }
}