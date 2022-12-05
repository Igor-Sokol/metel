using System.Text;

namespace Extensions
{
    public static class Extensions
    {
        public static string GetString(this char[] array)
        {
            StringBuilder result = new StringBuilder();

            foreach (var ch in array)
            {
                result.Append(ch);
            }

            return result.ToString();
        }
    }
}