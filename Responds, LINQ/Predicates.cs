using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Responds__LINQ
{
    public static class Predicates
    {
        public static bool IsPhoneNumberHasTwoAmountOfSeven(string number)
        {
            int counter = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == '7')
                {
                    ++counter;

                    if (counter >= 2)
                        return true;
                }
            }

            return false;
        }
        public static bool IsNameLengthMoreThan18(string number)
        {
            return number.Length > 18;
        }
        public static bool IsPhoneHasTwoOrMoreSevenAndNamLengthMoreThan18(Debtor debtor)
        {
            return /*IsNameLengthMoreThan18(debtor.FullName) && */IsPhoneNumberHasTwoAmountOfSeven(debtor.Phone);
        }

        public static bool IsNameAndSurnameHasAtLeastThreeSameCharacters(Debtor debtor)
        {
            StringBuilder surname = new StringBuilder(debtor.FullName.Substring(debtor.FullName.IndexOf(' ') + 1));
            StringBuilder name = new StringBuilder(debtor.FullName.Substring(0, debtor.FullName.Length - surname.Length - 1));

            int counter = 0;
            char found = '~';
            for (int i = 0; i < surname.Length; i++)
            {
                for (int j = 0; j < name.Length && surname[i] != ' '; j++)
                {
                    if (surname[i] == name[j])
                    {
                        ++counter;
                        if (counter >= 3)
                            return true;

                        name[j] = found;
                        break;
                    }
                }
            }

            return false;
        }

        public static bool NonRepetitivePhoneNumber(Debtor debtor)
        {
            List<char> digits = new List<char>();
            foreach (var number in debtor.Phone)
            {
                if ((!digits.Contains(number)) || number == '-')
                    digits.Add(number);
                else
                    return false;
            }
            return true;
        }

        public static bool IsPay(Debtor debtor)
        {
            return
                (debtor.BirthDay.Month < DateTime.Now.Month) ?
                Math.Abs(12 + (DateTime.Now.Month - debtor.BirthDay.Month)) * 500 >= debtor.Debt
                : Math.Abs(debtor.BirthDay.Month - DateTime.Now.Month + 1) * 500 >= debtor.Debt;
        }

        public static bool IsSmileWordExistNameAndSurnameCharacters(Debtor debtor)
        {
            List<char> surname = debtor.FullName.Substring(debtor.FullName.IndexOf(' ') + 1).ToList();
            List<char> name = debtor.FullName.Substring(0, debtor.FullName.Length - surname.Count - 1).ToList();

            return name.Contains('s') && name.Contains('m') && name.Contains('i') && name.Contains('l') && name.Contains('e') &&
                   surname.Contains('s') && surname.Contains('m') && surname.Contains('i') && surname.Contains('l') && surname.Contains('e');
        }

        public static bool IsSmileWordExistFullName(Debtor debtor)
        {
            return debtor.FullName.Contains('s')
                    && debtor.FullName.Contains('m')
                    && debtor.FullName.Contains('i')
                    && debtor.FullName.Contains('l')
                    && debtor.FullName.Contains('e');
        }



    }
}
