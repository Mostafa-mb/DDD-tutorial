using Clean_arch.Domain.Users.Value_Object;

namespace Clean_arch.Domain.Users
{
    public class User
    {

        public User(string Name, string Family, PhoneBook phoneBook)
        {
            this.Name = Name;
            this.Family = Family;
            this.PhoneBook = phoneBook;
        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public PhoneBook PhoneBook { get; private set; }
    }
}
