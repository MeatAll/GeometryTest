using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace GeometryApp.Presenters;

internal class LineCreationPresenter : ShapeCreationPresenter
{
    public override string ButtonText => "Line";
    public override IReadOnlyList<string> PointsInsertTooltips => ["Выберите первую точку", "Выберите вторую точку"];
    protected override Geometry CreateGeometry(Point[] points) => new LineGeometry(points[0], points[1]);
}
