
namespace CreatingConstructors
{
    static class StartUp
    {
        static void Main(string[] args)
        {
            var firstPerson = new Person();
            var secondPerson = new Person(20);
            var thirdPerson = new Person("Stamat", 25);          
        }
    }
}
