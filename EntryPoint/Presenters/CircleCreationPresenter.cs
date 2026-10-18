using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace GeometryApp.Presenters;

internal class CircleCreationPresenter : ShapeCreationPresenter
{
    public override string ButtonText => "Circle";
    public override IReadOnlyList<string> PointsInsertTooltips => ["Выберите точку центра", "Выберите точку на окружности"];
    protected override Geometry CreateGeometry(Point[] points)
    {
        var rad = (points[1] - points[0]).Length;

        return new EllipseGeometry(points[0], rad, rad);
    }
}
