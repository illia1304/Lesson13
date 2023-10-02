namespace Lesson13
{
    public partial class Program
    {
        //SINGLETON
        private class SingleTon
        {
            private static SingleTon single = null;

            protected SingleTon()
            {

            }

            private static SingleTon Initialize()
            {
                if (single == null)
                {
                    single = new SingleTon();
                }

                return single;
            }
        }

        // DECORATOR
        public interface IComponent
        {
            void Operation();
        }

        public class ConcreteComponent: IComponent 
        {
            public void Operation()
            {
                Console.WriteLine("Operation ConcreteComponent is done");
            }
        }

        public abstract class Decorator : IComponent 
        { 
            protected IComponent component;

            public Decorator(IComponent component)
            {
                this.component = component;
            }
            public virtual void Operation()
            {
                component.Operation();
            }
        }

        public class ConcreteDecorator : Decorator
        {
            public ConcreteDecorator(IComponent component)
                : base(component)
            {

            }

            public override void Operation()
            {
                base.Operation();
                Console.WriteLine("additional functionality");
            }
        }
        //Abstract Factory

        public abstract class Toy
        {
            public abstract void Play();
        }

        public class Doll : Toy
        {
            public override void Play()
            {
                Console.WriteLine("Playing with doll");
            }
        }
        public class Car : Toy
        {
            public override void Play()
            {
                Console.WriteLine("Playing with car");
            }
        }
        public class SoftToy : Toy
        {
            public override void Play()
            {
                Console.WriteLine("Playing with soft toy");
            }
        }

        public abstract class ToyFactory
        {
            public abstract Toy CreateDoll();
            public abstract Toy CreateCar();
            public abstract Toy CreateSoftToy();
        }

        public class ConcreteToyFactory : ToyFactory
        {
            public override Toy CreateDoll()
            {
                return new Doll();
            }
            public override Toy CreateCar()
            {
                return new Car();
            }
            public override Toy CreateSoftToy()
            {
                return new SoftToy();
            }
        }

        //strategy

        interface IShippingStrategy
        {
            float CalculationShippingCost(float orderAmount);
        }

        class Customer
        {
            private string name;
            private IShippingStrategy shippingStrategy;

            public Customer(string name, IShippingStrategy shippingStrategy)
            {
                this.name = name;
                this.shippingStrategy = shippingStrategy;
            }

            public void SetShippingStrategy(IShippingStrategy strategy)
            {
                shippingStrategy = strategy;
            }

            public float CalculationCost(float orderAmount)
            {
                return shippingStrategy.CalculationShippingCost(orderAmount);
            }

            public void ProcessOrder(float orderAmount)
            {
                double shippingCost = CalculationCost(orderAmount);
                Console.WriteLine($"Customer {name}: order processing...");
                Console.WriteLine($"Customer {name}: shipping cost - {shippingCost}");
            }
        }

        class RegularShippingStrategy : IShippingStrategy
        {
            public float CalculationShippingCost(float orderAmount)
            {
                return orderAmount * 0.25f;
            }
        }
        class ExpressShippingStrategy : IShippingStrategy
        {
            public float CalculationShippingCost(float orderAmount)
            {
                return orderAmount * 0.40f;
            }
        }
        public static void Main(string[] args)
        {
            //singleton
            SingleTon s1 = SingleTon.Initialize();
            SingleTon s2 = SingleTon.Initialize();

            Console.WriteLine(s1 == s2 ? 1 : 0);

            //decorator
            IComponent component = new ConcreteComponent();
            component = new ConcreteDecorator(component);

            component.Operation();

            //factory
            ToyFactory factory = new ConcreteToyFactory();
            Toy doll = factory.CreateDoll();
            Toy car = factory.CreateCar();
            Toy softtoy = factory.CreateSoftToy();

            doll.Play();
            car.Play(); 
            softtoy.Play();

            //strategy
            Customer customer1 = new Customer("Customer1", new RegularShippingStrategy());
            customer1.ProcessOrder(100);

            Customer customer2 = new Customer("Customer2", new ExpressShippingStrategy());
            customer2.ProcessOrder(100);

        }
    }
}