using System;
using System.Collections.Generic;

// Базовий інтерфейс
interface IShape
{
    void Draw();
}
// Інтерфейс з кольором, успадковується від IShape
interface IColoredShape : IShape
{
    void SetColor(string color);
}
// Клас коло, що реалізує IColoredShape
class Circle : IColoredShape
{
    private string color;

    public Circle(string color)
    {
        this.color = color;
    }

    public void SetColor(string color)
    {
        this.color = color;
    }
    public void Draw()
    {
        Console.WriteLine($"Малюю коло кольору: {color}");
    }
}
class Program
{
    static void Main()
    {
        // Створюємо список об’єктів типу IShape
        List<IShape> shapes = new List<IShape>
        {
            new Circle("Червоний"),
            new Circle("Синій"),
            new Circle("Зелений"),
            new Circle("Жовтий")
        };

        // Виводимо опис кожної фігури
        foreach (IShape shape in shapes)
        {
            shape.Draw();
        }
    }
}