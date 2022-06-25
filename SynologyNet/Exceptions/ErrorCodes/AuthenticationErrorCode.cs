using System.ComponentModel.DataAnnotations;

namespace SynologyNet.Exceptions
{
    internal enum AuthenticationErrorCode
    {
        [Display(Name = "No such account or incorrect password")]
        IncorrectCredentials = 400,

        [Display(Name = "Account disabled")]
        AccountDisabled = 401,

        [Display(Name = "Permission denied")]
        PermissionDenied = 402,

        [Display(Name = "2-step verification code required")]
        TwoFactorAuthenticationRequired = 403,

        [Display(Name = "Failed to authenticate 2-step verification code")]
        TwoFactorAuthenticationFailed = 404,
    }
}
