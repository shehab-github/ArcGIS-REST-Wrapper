using System;
using System.Net.Mail;

namespace ArcGIS_ServiceCallingWrapper.Helpers
{
    /// <summary>
    /// Contains methods commonly used for validations.
    /// </summary>
    public class Validators
    {
        /// <summary>
        /// Validates the format of the email address
        /// </summary>
        /// <param name="emailaddress"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string emailaddress)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(emailaddress))
                    return false;

                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// Check if the given url is a valid http url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsUrlValid(string url)
        {
            if (String.IsNullOrWhiteSpace(url))
                return false;

            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult);
        }

        /// <summary>
        /// Check if the given url is a valid https url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsUrlValidSecure(string url)
        {
            if (String.IsNullOrWhiteSpace(url))
                return false;

            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
