using Clean_arch.Domain.Shared;
using Clean_arch.Domain.UserAgg.Events;
using Clean_arch.Domain.Users.Value_Object;

namespace Clean_arch.Domain.Users
{
    public class User : AggregateRoot
    {

        public User(string Name, string Family, PhoneBook phoneBook, string email)
        {
            this.Name = Name;
            this.Family = Family;
            this.PhoneBook = phoneBook;
            Email = email;
        }


        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Family { get; private set; }
        public PhoneBook PhoneBook { get; private set; }


        public static User Register(string email)
        {
            var user = new User("", "", null, email);
            user.AddDomainEvent(new UserRegistered(user.Id, email));
            return user;
        }
    }


}
