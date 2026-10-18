using System.Windows.Input;

namespace GeometryApp.Interfaces;

public interface IPaletteItem
{
    string ButtonText { get; }
    ICommand CreateCommand { get; }
}
