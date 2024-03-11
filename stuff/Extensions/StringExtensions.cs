using System.Linq;

namespace stuff.Extensions
{
    public static class StringExtensions
    {
        public static string ReplaceAll(this string seed, char[] chars, char replacementCharacter)
        {
            return chars.Aggregate(seed, (str, cItem) => str.Replace(cItem, replacementCharacter));
        }
    }
}