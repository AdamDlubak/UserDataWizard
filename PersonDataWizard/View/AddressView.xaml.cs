using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PersonDataWizard.ViewModel;


namespace PersonDataWizard.View
{
  public partial class AddressView : UserControl
  {
    public AddressView()
    {
      InitializeComponent();
    }
    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
      AddressTextBox.Focus();
      AddressTextBox.Focusable = true;
      Keyboard.Focus(AddressTextBox);

      MainWindowViewModel.IsNextEnable = MainWindowViewModel.User.AddressStreet != null;
      MainWindowViewModel.IsFinishPage = false;

    }
  }
}
