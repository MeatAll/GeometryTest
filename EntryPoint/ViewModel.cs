using GeometryApp.Interfaces;
using GeometryApp.Presenters;
using GeometryApp.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace GeometryApp;

public class ViewModel : PropertyChangedAbstract, IViewModel
{
    private readonly string _defaultTooltip = "Выберите на палитре необходимую геометрическую фигуру";
    private readonly IPointInput _input;
    public ViewModel(IEnumerable<IShapeCreation> shapeCreations, IPointInput pointInput)
    {
        _input = pointInput;
        Tooltip = _defaultTooltip;
        Palette = shapeCreations.Select(x => new PaletteItemPresenter(x, () => CreateShapeAsync(x))).ToArray();
    }
    public IReadOnlyCollection<IPaletteItem> Palette { get; }
    public ObservableCollection<Geometry> GeometryShapes { get; } = [];
    public ICommand ClearCommand => field ??= new RelayCommandWithoutParameter(GeometryShapes.Clear);
    public string Tooltip 
    {
        get;
        set 
        {
            var val = string.IsNullOrEmpty(value) ? _defaultTooltip : value == _defaultTooltip ? _defaultTooltip : $"{value} или Escape для отмены:";

            if (field == val) return;

            field = val;

            OnPropertyChanged();
        } 
    }
    public bool IsPaletteEnabled
    {
        get;
        private set { field = value; OnPropertyChanged(); }
    } = true;
    private async Task CreateShapeAsync(IShapeCreation shapeCreation)
    {
        IsPaletteEnabled = false;

        try
        {
            var points = await _input.PickPointsAsync(shapeCreation.PointsInsertTooltips, new Progress<string>(t => Tooltip = t));

            if (points is null) return;

            GeometryShapes.Add(shapeCreation.Create(points));
        }
        finally
        {
            IsPaletteEnabled = true;
        }
    }
}