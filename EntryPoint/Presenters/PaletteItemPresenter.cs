using GeometryApp.Interfaces;
using GeometryApp.Utilities;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GeometryApp.Presenters;

internal class PaletteItemPresenter(IShapeCreation shapeCreation, Func<Task> create) : IPaletteItem
{
    public string ButtonText => shapeCreation.ButtonText;
    public ICommand CreateCommand => new AsyncRelayCommand(create);
}
