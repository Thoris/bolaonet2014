using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web.Security;

namespace Framework.Security.Model
{
    public interface ISystemProperties
    {
        #region Properties
        /// <summary>
        /// The name of the application using the custom membership provider.
        /// </summary>
        /// <value></value>
        /// <returns>The name of the application using the custom membership provider.</returns>
        string ApplicationName { get; set; }
        /// <summary>
        /// Gets a brief, friendly description suitable for display in administrative tools or other user interfaces (UIs).
        /// </summary>
        /// <value></value>
        /// <returns>A brief, friendly description suitable for display in administrative tools or other UIs.</returns>
        string Description { get; }
        /// <summary>
        /// Indicates whether the membership provider is configured to allow users to reset their passwords.
        /// </summary>
        /// <value></value>
        /// <returns>true if the membership provider supports password reset; otherwise, false. The default is true.</returns>
        bool EnablePasswordReset { get; }
        /// <summary>
        /// Indicates whether the membership provider is configured to allow users to retrieve their passwords.
        /// </summary>
        /// <value></value>
        /// <returns>true if the membership provider is configured to support password retrieval; otherwise, false. The default is false.</returns>
        bool EnablePasswordRetrieval { get; }
        /// <summary>
        /// Gets the number of invalid password or password-answer attempts allowed before the membership user is locked out.
        /// </summary>
        /// <value></value>
        /// <returns>The number of invalid password or password-answer attempts allowed before the membership user is locked out.</returns>
        int MaxInvalidPasswordAttempts { get; }
        /// <summary>
        /// Gets the minimum number of special characters that must be present in a valid password.
        /// </summary>
        /// <value></value>
        /// <returns>The minimum number of special characters that must be present in a valid password.</returns>
        int MinRequiredNonAlphanumericCharacters { get; }
        /// <summary>
        /// Gets the minimum length required for a password.
        /// </summary>
        /// <value></value>
        /// <returns>The minimum length required for a password. </returns>
        int MinRequiredPasswordLength { get; }
        /// <summary>
        /// Gets the friendly name used to refer to the provider during configuration.
        /// </summary>
        /// <value></value>
        /// <returns>The friendly name used to refer to the provider during configuration.</returns>
        string Name { get; }
        /// <summary>
        /// Gets the number of minutes in which a maximum number of invalid password or password-answer attempts are allowed before the membership user is locked out.
        /// </summary>
        /// <value></value>
        /// <returns>The number of minutes in which a maximum number of invalid password or password-answer attempts are allowed before the membership user is locked out.</returns>
        int PasswordAttemptWindow { get; }
        /// <summary>
        /// Gets a value indicating the format for storing passwords in the membership data store.
        /// </summary>
        /// <value></value>
        /// <returns>One of the <see cref="T:System.Web.Security.MembershipPasswordFormat"/> values indicating the format for storing passwords in the data store.</returns>
        MembershipPasswordFormat PasswordFormat { get; }
        /// <summary>
        /// Gets the regular expression used to evaluate a password.
        /// </summary>
        /// <value></value>
        /// <returns>A regular expression used to evaluate a password.</returns>
        string PasswordStrengthRegularExpression { get; }
        /// <summary>
        /// Gets a value indicating whether the membership provider is configured to require the user to answer a password question for password reset and retrieval.
        /// </summary>
        /// <value></value>
        /// <returns>true if a password answer is required for password reset and retrieval; otherwise, false. The default is true.</returns>
        bool RequiresQuestionAndAnswer { get; }
        /// <summary>
        /// Gets a value indicating whether the membership provider is configured to require a unique e-mail address for each user name.
        /// </summary>
        /// <value></value>
        /// <returns>true if the membership provider requires a unique e-mail address; otherwise, false. The default is true.</returns>
        bool RequiresUniqueEmail { get; }

        //ConnectionStringSettings ConnectionStringSettings { get; }
        #endregion

        void Initialize(string name, System.Collections.Specialized.NameValueCollection config);
    }
}
