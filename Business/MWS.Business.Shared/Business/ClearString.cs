using MWS.Business.Shared.IBusiness;
using System.Text.RegularExpressions;

namespace MWS.Business.Shared.Business
{
    public class ClearString : IClearString
    {
        private string uniqueArabicChars(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "";
            }
            var regExY = new Regex("[ى]");
            var regExH = new Regex("[ة]");
            var regExA = new Regex("[أإآ]");
            input = regExY.Replace(input, "ي");
            input = regExH.Replace(input, "ه");
            input = regExA.Replace(input, "ا");

            return input;
        }

        public string clearAll(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "";
            }

            input = input.Trim();

            input = uniqueArabicChars(input);

            var regEx = new Regex("[^0-9a-zA-Zابتثجحخدذرزسشصضطظعغفقكلمنهويءئؤ]+");
            input = regEx.Replace(input, "");
            input = input.ToLower();
            return input;
        }

        public string clearAllButSpaces(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "";
            }

            input = input.Trim();

            input = uniqueArabicChars(input);

            var regEx = new Regex("[^0-9a-zA-Zابتثجحخدذرزسشصضطظعغفقكلمنهويءئؤ ]+");

            input = regEx.Replace(input, "");

            regEx = new Regex("[ ]+");
            input = regEx.Replace(input, " ");
            input = input.ToLower();
            return input;
        }


        public string trimSave(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "";
            }

            return input.Trim();
        }
    }
}
