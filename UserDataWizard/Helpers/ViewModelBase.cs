using System;
using System.ComponentModel;

namespace UserDataWizard.Helpers
{
  public abstract class ViewModelBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
      OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    }

    protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    {
      PropertyChanged?.Invoke(this, e);
    }

    public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
    public static void RaiseStaticPropertyChanged(string propName)
    {
      StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propName));
    }

  }
}