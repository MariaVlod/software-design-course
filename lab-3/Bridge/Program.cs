using Bridge.Renderers;
using Bridge.Shapes;

class Program
{
    static void Main()
    {
        IRenderer vectorRenderer = new VectorRenderer();
        IRenderer rasterRenderer = new RasterRenderer();

        Shape circle1 = new Circle(vectorRenderer);
        Shape square1 = new Square(rasterRenderer);
        Shape triangle1 = new Triangle(vectorRenderer);
        Shape circle2 = new Circle(rasterRenderer);
        Shape triangle2 = new Triangle(rasterRenderer);
        Shape square2 = new Square(vectorRenderer);

        Console.WriteLine("Drawing shapes:");
        Console.WriteLine("---------------");
        circle1.Draw();
        square1.Draw();
        triangle1.Draw();
        circle2.Draw();
        triangle2.Draw();
        square2.Draw();
    }
}