using System.Text.RegularExpressions;

namespace Sharpcut.Helpers
{
    public static class ColorHelper
    {
        public static bool IsValidHexColor(string hexColor)
        {
            if (string.IsNullOrWhiteSpace(hexColor))
            {
                return false;
            }

            var regex = new Regex(@"^#?([0-9a-f]{3}){1,2}$");

            return regex.IsMatch(hexColor);
        }
    }
}
