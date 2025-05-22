using System; using System.Diagnostics.Tracing; using System.IO.Compression;

class Program {     static void Main(string[] args)     
  {
                Circle myCircle = new Circle(10);       
        myCircle.SetRadius(10);
        Console.WriteLine($"{myCircle.GetRadius()}");     
        Circle myCircle2 = new Circle();
                myCircle2.SetRadius(20);
                Console.WriteLine($"{myCircle2.GetRadius()}");
        Console.WriteLine($"{myCircle.GetArea()}");
                Console.WriteLine($"{myCircle2.GetArea()}");
        Cylinder myCylinder = new Cylinder();       
          myCylinder.SetHeight(10);  
                 myCylinder.SetCircle(myCircle);
                Console.WriteLine($"{myCylinder.GetVolume()}");     } }

        