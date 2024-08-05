using Clean_arch.Domain.Shared;

namespace Clean_arch.Domain.Users.Value_Object
{
    public class PhoneBook : BaseValueObject
    {
        public PhoneBook(PhoneNumber telephone, PhoneNumber fax)
        {
            Telephone = telephone;
            Fax = fax;
        }

        public PhoneNumber Telephone { get; }
        public PhoneNumber Fax { get; }

    }
}
