using System.Windows;
using PersonDataWizard.ViewModels;

namespace PersonDataWizard.Views
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {

      InitializeComponent();
      this.DataContext = new MainWindowViewModel();
    }
  }
}
