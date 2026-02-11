using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("Blue", 4);
        Console.WriteLine($"Square color: {square.GetColor()}, area: {square.GetArea()}");

        Rectangle rectangle = new Rectangle("Green", 3, 5);
        Console.WriteLine($"Rectangle color: {rectangle.GetColor()}, area: {rectangle.GetArea()}");

        Circle circle = new Circle("Red", 2.5);
        Console.WriteLine($"Circle color: {circle.GetColor()}, area: {circle.GetArea()}");

        List<Shape> shapes = new List<Shape>
        {
            square,
            rectangle,
            circle,
            new Square("Yellow", 6)
        };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()} shape area: {shape.GetArea()}");
        }
    }
}