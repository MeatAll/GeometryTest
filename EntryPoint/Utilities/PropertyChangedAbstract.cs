using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GeometryApp.Utilities;

public abstract class PropertyChangedAbstract : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        if (!string.IsNullOrEmpty(propertyName))
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
