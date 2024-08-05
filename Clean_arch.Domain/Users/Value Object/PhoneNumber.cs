using Clean_arch.Domain.Shared;

namespace Clean_arch.Domain.Users.Value_Object
{
    public class PhoneNumber : BaseValueObject
    {
        public string Phone { get;}

        public PhoneNumber(string phone)
        {
            if(phone.Length < 11)
            {
                throw new ArgumentException("شماره نادرست است");
            }
            Phone = phone;
        }
    }
}
