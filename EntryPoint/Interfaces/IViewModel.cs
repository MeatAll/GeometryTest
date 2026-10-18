using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;

namespace GeometryApp.Interfaces;

public interface IViewModel
{
    IReadOnlyCollection<IPaletteItem> Palette { get; }
    ObservableCollection<Geometry> GeometryShapes { get; }
    ICommand ClearCommand { get; }
    string Tooltip { get; }
    bool IsPaletteEnabled { get; }
}
