using System;

namespace DiskCommerce.Domain.Exceptions
{
    public class Guardian
    {

        public static void CheckNullOrEmpty(String value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException();
        }

        public static void CheckNull(object value)
        {
            if (value == null)
                throw new ArgumentNullException(value.GetType().ToString());
        }

        public static void CheckAnyNull(params object[] values)
        {
            foreach (var value in values)
            {
                if (value == null)
                    throw new ArgumentNullException();
            }
        }

        public static void CheckLength(string value, int minLen, int maxLen)
        {
            CheckNull(value);

            if ((value.Length < minLen || (value.Length > maxLen)))
                throw new ArgumentOutOfRangeException(value.GetType().ToString());
        }

        public static void CheckRange(decimal value, decimal minLen, decimal maxLen)
        {
            CheckNull(value);

            if ((value < minLen || (value > maxLen)))
                throw new ArgumentOutOfRangeException(value.GetType().ToString());
        }

    }
}
