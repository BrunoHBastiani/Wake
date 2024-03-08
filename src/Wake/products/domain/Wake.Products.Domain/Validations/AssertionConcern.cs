using Wake.Products.Domain.Exceptions;

namespace Wake.Products.Domain.Validations
{
    public static class AssertionConcern
    {

        public static void NotNull(object obj, string message)
        {
            if (obj == null)
            {
                throw new HttpBadRequestException(message);
            }
        }

        public static void Null(object obj, string message)
        {
            if (obj != null)
            {
                throw new HttpBadRequestException(message);
            }
        }

        public static void NotEmpty(string text, string message)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new HttpBadRequestException(message);
            }
        }

        public static void NotNullOrWhiteSpace(string text, string message)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new HttpBadRequestException(message);
            }
        }

        public static void GreaterThan(int value, int limit, string message)
        {
            if (value <= limit)
            {
                throw new HttpBadRequestException(message);
            }
        }

        public static void LessThan(int value, int limit, string message)
        {
            if (value >= limit)
            {
                throw new HttpBadRequestException(message);
            }
        }

        public static void LessThan(decimal value, decimal limit, string message)
        {
            if (value >= limit)
            {
                throw new HttpBadRequestException(message);
            }
        }

        public static void GreaterThanOrEqual(int value, int limit, string message)
        {
            if (value < limit)
            {
                throw new HttpBadRequestException(message);
            }
        }

        public static void LessThanOrEqual(int value, int limit, string message)
        {
            if (value > limit)
            {
                throw new HttpBadRequestException(message);
            }
        }

        public static void Equal(int value1, int value2, string message)
        {
            if (value1 != value2)
            {
                throw new HttpBadRequestException(message);
            }
        }

        public static void True(bool condition, string message)
        {
            if (!condition)
            {
                throw new HttpBadRequestException(message);
            }
        }

        public static void False(bool condition, string message)
        {
            if (condition)
            {
                throw new HttpBadRequestException(message);
            }
        }

        public static void ContainsText(string text, string subtext, string message)
        {
            if (!text.Contains(subtext))
            {
                throw new HttpBadRequestException(message);
            }
        }

        public static void NotContainsText(string text, string subtext, string message)
        {
            if (text.Contains(subtext))
            {
                throw new HttpBadRequestException(message);
            }
        }

        public static void EqualSize(string text, int size, string message)
        {
            if (text.Length != size)
            {
                throw new HttpBadRequestException(message);
            }
        }

        public static void SizeGreaterThanOrEqual(string text, int size, string message)
        {
            if (text.Length < size)
            {
                throw new HttpBadRequestException(message);
            }
        }

        public static void SizeLessThanOrEqual(string text, int size, string message)
        {
            if (text.Length > size)
            {
                throw new HttpBadRequestException(message);
            }
        }
    }
}
