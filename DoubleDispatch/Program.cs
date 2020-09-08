using System;

namespace DoubleDispatch
{
    public interface Graphic
    {
        void Draw();
    }

    class Shape : Graphic
    {
        public int id;

        public void Draw()
        {
            
        }
    }
    
    class Dot : Graphic
    {
        public int x;
        
        public int y;

        public void Draw()
        {
            
        }
    }
    
    class Circle : Graphic
    {
        public int x;
        
        public int y;
        
        public int radius;

        public void Draw()
        {
            
        }
    }
    
    class Rectangle : Graphic
    {
        public int width;
        
        public int height;
        
        public void Draw()
        {
            
        }
    }

    class Exporter
    {
        public void Export(Shape shape)
        {
            Console.Write("It is shape");
        }
        
        public void Export(Dot dot)
        {
            Console.Write("It is dot");
        }
        
        public void Export(Graphic graphic)
        {
            Console.Write("It is graphic");
        }
        
        public void Export(Circle circle)
        {
            Console.Write("It is Circle");
        }
    }
    
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            var exporter = new Exporter();
        
            /**
             * Разница:
             * В первом случае - вызываем метод напрямиг
             * Во втором - вызываем метод через прослойку
             */
            
            // Так связывается все правильно
            exporter.Export(new Dot());
            
            // А тут свяжется как graphic
            Export(new Circle());
        }

        public static void Export(Graphic graphic)
        {
            var exporter = new Exporter();
            
            // а что если не будет реализации этого метода для типа класса
            // поэтому идет ранее статическое связывание
            exporter.Export(graphic);
        }
    }
}