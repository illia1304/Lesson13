namespace Lesson13
{
    public partial class Program
    {
        //SINGLETON
        class SingleTon
        {
            private static SingleTon single = null;

            protected SingleTon()
            {

            }

            public static SingleTon Initialize()
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
        
        public static void Main(string[] args)
        {
            SingleTon s1 = SingleTon.Initialize();
            SingleTon s2 = SingleTon.Initialize();

            Console.WriteLine(s1 == s2 ? 1 : 0);

            IComponent component = new ConcreteComponent();
            component = new ConcreteDecorator(component);

            component.Operation();
        }
    }
}