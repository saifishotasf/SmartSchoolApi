using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class ApplicationSettings
    {
        public const int ScreenTimeoutMins = 5;
        public const int PasswordValidDays = 2;
        public const int TokenValidDurationInDays = 10;
        public const string TokenType = "Bearer";
        public const string ClaimTypeId = "Id";
        public const string ClaimTypeFullName = "FullName";
        public const string ClaimTypeLastName = "LastName";
        public const string ClaimTypeEmail = "Email";
        public const string ClaimContact = "Contact";

        public static string Secret { get; set; } = "9STM5IhCQReO5ZdEUNfAJOQZAtt19uiDhNtKKUt";
        public static string Issuer { get; set; } = "https://localhost:44378/";
        public static string Audiance { get; set; } = "TwaradPostmanClient";
    }
}
