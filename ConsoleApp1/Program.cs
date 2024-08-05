using Clean_arch.Domain.Shared;
using Clean_arch.Domain.Users;
using Clean_arch.Domain.Users.Value_Object;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var money1 = Money.FromTooman(10000);
            var money2= Money.FromTooman(20000);
            var money3 = money1 + money2;
            Console.WriteLine(money3.ToString());

            var user = new User("Mostafa", "Mobasher",new PhoneBook(new PhoneNumber("09108433119"),new PhoneNumber("05138416351")));


        }
    }
}
