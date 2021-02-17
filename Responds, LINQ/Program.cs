using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Responds__LINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Debtor> debtors = Configuration.GetDebtors();
            string[] menu = Configuration.GetMenu();

            Console.WriteLine(menu.Length);

            List<Debtor> helper;
            while (true)
            {
                Configuration.PrintMenu(menu);
                Console.Write("Enter: ");
                string option = Console.ReadLine();

                while (!Verify.IsChoiceCorrect(option, menu.Length))
                {
                    Console.WriteLine("\nEnter one of this numbers: ");
                    option = Console.ReadLine();
                }
                Console.Clear();

                switch (option)
                {
                    case DebtorMenuChoices.ShowAllDebtor:
                        {
                            debtors.ForEach(d => Console.WriteLine(d));
                        }
                        break;

                    case DebtorMenuChoices.ShowReverseVersionOfAllDebtor:
                        {
                            helper = Enumerable.Reverse(debtors).ToList();
                            helper.ForEach(d => Console.WriteLine(d));
                        }
                        break;

                    case DebtorMenuChoices.DomainNameRhytaOrDayrep:
                        {
                            helper = debtors.FindAll(d => d.Email.Split('@')[1] == "rhyta.com" || d.Email.Split('@')[1] == "dayrep.com");
                            helper.ForEach(d => Console.WriteLine(d));
                        }
                        break;

                    case DebtorMenuChoices.AgeBetween:
                        {
                            helper = debtors.FindAll(d => DateTime.Now.Year - d.BirthDay.Year >= 26 && DateTime.Now.Year - d.BirthDay.Year < 36);
                            helper.ForEach(d => Console.WriteLine(d));
                        }
                        break;

                    case DebtorMenuChoices.LessThan5000:
                        {
                            helper = debtors.FindAll(d => d.Debt <= 5000);
                            helper.ForEach(f => Console.WriteLine(f));
                        }
                        break;

                    case DebtorMenuChoices.FullNameLengthLessThan18AndPhoneNumberHasAtLeastTwoAmountOf7:
                        {
                            helper = debtors.FindAll(Predicates.IsPhoneHasTwoOrMoreSevenAndNamLengthMoreThan18);
                            helper.ForEach(d => Console.WriteLine(d));
                        }
                        break;

                    case DebtorMenuChoices.BornInWinter:
                        {
                            helper = debtors.FindAll(d => d.BirthDay.Month == WinterMonths.December
                            || d.BirthDay.Month == WinterMonths.January || d.BirthDay.Month == WinterMonths.February);
                            helper.ForEach(d => Console.WriteLine(d));
                        }
                        break;
                    case DebtorMenuChoices.MoreThanAverageDebt:
                        {
                            double averageAmount = debtors.Average(d => d.Debt);
                            helper = debtors.FindAll(d => d.Debt > averageAmount)
                                .OrderByDescending(d => d.FullName)
                                .OrderByDescending(d => d.Debt).ToList();

                            helper.ForEach(m => Console.WriteLine(m));
                            Console.Write(new string(' ', (Console.WindowWidth - $"Average debt is {averageAmount} $".Length) / 2));
                            Console.WriteLine($"Average debt is {averageAmount} $");
                        }
                        break;

                    case DebtorMenuChoices.PhoneNumberNotContains8:
                        {
                            helper = debtors.FindAll(d => !d.Phone.Contains("8"));
                            helper.ForEach
                            (
                                d =>
                                {
                                    string surname = d.FullName.Substring(d.FullName.IndexOf(' ') + 1);
                                    Console.WriteLine($"Surname: {surname}, Age:  {DateTime.Now.Year - d.BirthDay.Year}, Debt: {d.Debt}");
                                }

                            );
                        }
                        break;


                    case DebtorMenuChoices.NameSurname3SameCharacter:
                        {
                            helper = debtors.FindAll(Predicates.IsNameAndSurnameHasAtLeastThreeSameCharacters)
                                .OrderBy(d => d.FullName).ToList();

                            helper.ForEach(h => Console.WriteLine(h));
                        }
                        break;

                    case DebtorMenuChoices.MostOfTheDebtorsBornYear:
                        {
                            int mostDebtorYear = debtors.GroupBy(d => d.BirthDay.Year)
                                .OrderByDescending(year => year.Count())
                                .Select(d => d.Key)
                                .First();
                            Console.WriteLine($"Most debt year is {mostDebtorYear}");
                        }
                        break;

                    case DebtorMenuChoices.FiveBigDebtors:
                        {
                            helper = debtors.OrderByDescending(d => d.Debt).Take(5).ToList();
                            helper.ForEach(d => Console.WriteLine(d));
                        }
                        break;

                    case DebtorMenuChoices.AllDebtInBank:
                        {
                            int allDebt = debtors.Sum(d => d.Debt);
                            Console.WriteLine($"All debt is {allDebt:C} $");
                        }
                        break;

                    case DebtorMenuChoices.WorldWarTwoDebtors:
                        {
                            helper = debtors.FindAll(d => d.BirthDay.Year <= 1945);
                            helper.ForEach(d => Console.WriteLine(d));
                        }
                        break;

                    case DebtorMenuChoices.NonRepetetivePhoneNumberCharacters:
                        {
                            helper = debtors.FindAll(Predicates.NonRepetitivePhoneNumber);
                            helper.ForEach(d => Console.WriteLine(d));
                        }
                        break;

                    case DebtorMenuChoices.PaidTillBirthday:
                        {
                            helper = debtors.FindAll(Predicates.IsPay);
                            helper.ForEach(p => Console.WriteLine(p));
                        }
                        break;

                    case DebtorMenuChoices.MakeSmileWordWithTheirNameAndSurname:
                        {
                            helper = debtors.FindAll(Predicates.IsSmileWordExistFullName);
                            helper.ForEach(d => Console.WriteLine(d));
                        }
                        break;

                    case DebtorMenuChoices.ShowInterval:
                        {
                            Console.Write("Enter starting Range: ");
                            option = Console.ReadLine();

                            while (!Verify.IsChoiceCorrect(option, debtors.Count - 1))
                            {
                                Console.WriteLine("\nEnter correct number: ");
                                option = Console.ReadLine();
                            }
                            Console.Clear();

                            int start = Convert.ToInt32(option);
                            Console.Write("Enter how far to go: ");
                            option = Console.ReadLine();

                            while (!Verify.IsRangeNumberCorrect(option, debtors.Count - start + 1))
                            {
                                Console.WriteLine("\nEnter correct number: ");
                                option = Console.ReadLine();
                            }
                            Console.Clear();

                            helper = debtors.GetRange(start, Convert.ToInt32(option));
                            helper.ForEach(d => Console.WriteLine(d));
                        }
                        break;
                    case DebtorMenuChoices.Exit:
                        {
                            MessageBox.Show("See you soon goodbye.", $"Mezahir Production", MessageBoxButtons.OK);
                            return;
                        }

                }
                MessageBox.Show("Operation Done", $"Mezahir Production", MessageBoxButtons.OK);
                Console.Clear();
            }
           
           
           
        }
    }
}
