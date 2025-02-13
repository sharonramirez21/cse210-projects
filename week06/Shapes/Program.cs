using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("Blue", 5);
        Rectangle rectangle = new Rectangle("Red", 4, 6);
        Circle circle = new Circle("Yellow", 3);

        Console.WriteLine($"Square color: {square.GetColor()}, Area: {square.GetArea()}");
        Console.WriteLine($"Rectangle color: {rectangle.GetColor()}, Area: {rectangle.GetArea()}");
        Console.WriteLine($"Circle color: {circle.GetColor()}, Area: {circle.GetArea()}");
    }
}