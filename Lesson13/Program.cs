namespace Lesson13
{
    public partial class Program
    {
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

        public static void Main(string[] args)
        {
            SingleTon s1 = SingleTon.Initialize();
            SingleTon s2 = SingleTon.Initialize();

            Console.WriteLine(s1 == s2 ? 1 : 0);
        }
    }
}