using System;

namespace Responds__LINQ
{
    public class Debtor
    {
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Debt { get; set; }

        public Debtor(in string fullname, in DateTime birthDay, in string phone, in string email, in string address, in int debt)
        {
            FullName = fullname;
            BirthDay = birthDay;
            Phone = phone;
            Email = email;
            Address = address;
            Debt = debt;
        }

        public override string ToString()
        {
            return $"{FullName} {BirthDay.ToShortDateString()} {Phone} {Email} {Address} {Debt}";
        }
    }
}