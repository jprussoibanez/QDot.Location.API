using QDot.Location.API.Client.Infraestructure.Exceptions;
using QDot.Location.API.Client.Infraestructure.Resources;
using System.Text.RegularExpressions;

namespace QDot.Location.API.Client.Validators
{
    internal static class RequestValidator
    {
        /// <summary>
        /// Validate whether required argument is null or empty.
        /// </summary>
        public static void RequiredField(string name, object value)
        {
            if (value == null)
            {
                throw new APIClientParameterException(string.Format(ErrorMessages.MissingRequiredArguments, name));
            }
            else
            {
                if (value.GetType() == typeof(string))
                {
                    string strValue = value as string;
                    if (string.IsNullOrEmpty(strValue))
                    {
                        throw new APIClientParameterException(string.Format(ErrorMessages.MissingRequiredArguments, name));
                    }
                }
            }
        }

        /// <summary>
        /// Validate whether the argument is correctly formated.
        /// </summary>
        public static void Match(string name, string value, string pattern)
        {
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            if (!rgx.IsMatch(value))
            {
                throw new APIClientParameterException(string.Format(ErrorMessages.BadArgumentFormat, value, name));
            }
        }
    }
}
