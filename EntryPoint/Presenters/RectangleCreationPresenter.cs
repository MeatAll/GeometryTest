using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace GeometryApp.Presenters;

internal class RectangleCreationPresenter : ShapeCreationPresenter
{
    public override string ButtonText => "Rectangle";
    public override IReadOnlyList<string> PointsInsertTooltips => ["Выберите верхнюю левую точку", "Выберите нижнюю правую точку"];
    protected override Geometry CreateGeometry(Point[] points) => new RectangleGeometry(new Rect(points[0], points[1]));
}
