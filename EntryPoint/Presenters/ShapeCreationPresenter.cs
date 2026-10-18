using GeometryApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace GeometryApp.Presenters;

internal abstract class ShapeCreationPresenter : IShapeCreation
{
    public abstract string ButtonText { get; }
    public abstract IReadOnlyList<string> PointsInsertTooltips { get; }
    public Geometry Create(Point[] points)
    {
        if (points.Length != PointsInsertTooltips.Count)
            throw new ArgumentException("Неверное количество заданных точек");
        return CreateGeometry(points);
    }
    protected abstract Geometry CreateGeometry(Point[] points);
}
