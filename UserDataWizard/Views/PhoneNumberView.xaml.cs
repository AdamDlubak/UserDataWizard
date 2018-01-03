using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UserDataWizard.ViewModels;

namespace UserDataWizard.Views
{
  public partial class PhoneNumberView : UserControl
  {
    public PhoneNumberView()
    {
      InitializeComponent();
    }
    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
      PhoneNumberTextbox.Focus();
      PhoneNumberTextbox.Focusable = true;
      Keyboard.Focus(PhoneNumberTextbox);

      MainWindowViewModel.IsNextEnable = MainWindowViewModel.User.PhoneNumber != null;

      MainWindowViewModel.IsFinishPage = true;

    }
  }
}
