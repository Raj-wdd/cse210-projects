using System;

class Cylinder
{
    private Circle _circle;
    private double _height;

    public Cylinder(Circle circle, double height)
    {
        _circle = circle;
        _height = height;
    }

    public double GetVolume()
    {
        return _circle.GetArea() * _height;
    }
}
