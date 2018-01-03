using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UserDataWizard.ViewModels;

namespace UserDataWizard.Views
{
  public partial class AddressView : UserControl
  {
    public AddressView()
    {
      InitializeComponent();
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
      Address.Focus();
      Address.Focusable = true;
      Keyboard.Focus(Address);

      MainWindowViewModel.IsNextEnable = AddressViewModel._isCorrect;
      MainWindowViewModel.IsFinishPage = false;
    }
  }
}