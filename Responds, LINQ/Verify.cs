using System;

namespace Responds__LINQ
{
    public class Verify
    {
        public static bool IsChoiceNumber(in string choice)
        {
            return int.TryParse(choice, out _);
        }
        public static bool IsChoiceCorrect(in string choice, in int maxChoice)
        {
            if ((!String.IsNullOrWhiteSpace(choice)) && IsChoiceNumber(choice))
            {
                return int.Parse(choice) <= maxChoice && int.Parse(choice) > 0;
            }

            return false;
        }

        public static bool IsRangeNumberCorrect(in string choice, in int go)
        {
            if(IsChoiceNumber(choice))
            {
                return int.Parse(choice) < go  || int.Parse(choice) == 0;
            }
            return false;
        }

    }
}
