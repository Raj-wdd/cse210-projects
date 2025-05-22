
class Cylinder
{
    private Circle _circle;
    private double _height;

    public Cylinder()
    {
        _circle = null;
        _height = 0.0;
    }

    public Cylinder(double height, Circle circle)
    {
        _height = height;
        _circle = circle;
    }

    public Cylinder(double height, double radius)
    {
        _height = height;
          
    }
    public void SetCircle(Circle circle) { _circle = circle; SetHeight(10); }
    public void SetHeight(double height) { if (height < 0) { Console.WriteLine("Error, cannont set a negative value."); return; } _height = height; }
    public double GetVolume()
    {         double radius = _circle.GetRadius();         return _circle.GetArea() * _height;         // return Math.PI * radius * radius * _height;
    }
}