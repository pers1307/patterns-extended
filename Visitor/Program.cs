using System;
using System.Collections.Generic;

namespace Visitor
{
    internal class Program
    {
        /**
         * Может принимать в себя любой интерфейс посетителя 
         */
        public interface IComponent
        {
            void Accept(IVisitor visitor);
        }
        
        /**
         * Конкретные объекты, которые в себя умеют принимать поситителя
         */
        public class ConcreteComponentA : IComponent
        {
            public void Accept(IVisitor visitor)
            {
                visitor.VisitConcreteComponentA(this);
            }
            
            public string ExclusiveMethodOfConcreteComponentA()
            {
                return "A";
            }
        }
        
        public class ConcreteComponentB : IComponent
        {
            public void Accept(IVisitor visitor)
            {
                visitor.VisitConcreteComponentB(this);
            }

            public string SpecialMethodOfConcreteComponentB()
            {
                return "B";
            }
        }
        
        // Есть реализация для каждого конкретного исходного объекта
        public interface IVisitor
        {
            void VisitConcreteComponentA(ConcreteComponentA element);

            void VisitConcreteComponentB(ConcreteComponentB element);
        }
        
        /**
         * Это непосредственно поситители, которые в себе хранят дополнительную логику,
         * для исходных объектов 
         */
        class ConcreteVisitor1 : IVisitor
        {
            public void VisitConcreteComponentA(ConcreteComponentA element)
            {
                Console.WriteLine(element.ExclusiveMethodOfConcreteComponentA() + " + ConcreteVisitor1");
            }

            public void VisitConcreteComponentB(ConcreteComponentB element)
            {
                Console.WriteLine(element.SpecialMethodOfConcreteComponentB() + " + ConcreteVisitor1");
            }
        }
        
        class ConcreteVisitor2 : IVisitor
        {
            public void VisitConcreteComponentA(ConcreteComponentA element)
            {
                Console.WriteLine(element.ExclusiveMethodOfConcreteComponentA() + " + ConcreteVisitor2");
            }

            public void VisitConcreteComponentB(ConcreteComponentB element)
            {
                Console.WriteLine(element.SpecialMethodOfConcreteComponentB() + " + ConcreteVisitor2");
            }
        }
        
        public class Client
        {
            public static void ClientCode(List<IComponent> components, IVisitor visitor)
            {
                foreach (var component in components)
                {
                    component.Accept(visitor);
                }
            }
        }
        
       
        public static void Main(string[] args)
        {
            List<IComponent> components = new List<IComponent>
            {
                new ConcreteComponentA(),
                new ConcreteComponentB()
            };

            Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
            var visitor1 = new ConcreteVisitor1();
            Client.ClientCode(components,visitor1);

            Console.WriteLine();

            Console.WriteLine("It allows the same client code to work with different types of visitors:");
            var visitor2 = new ConcreteVisitor2();
            Client.ClientCode(components, visitor2);
        }
    }
}