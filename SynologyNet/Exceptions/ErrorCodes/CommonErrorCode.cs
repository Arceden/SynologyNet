using System.ComponentModel.DataAnnotations;

namespace SynologyNet.Exceptions
{
    internal enum CommonErrorCode
    {
        [Display(Name = "Unknown error")]
        Unknown = 100,

        [Display(Name = "No parameter of API, method or version")]
        MissingApiSpecs = 101,

        [Display(Name = "The requested API does not exist")]
        ApiNotFound = 102,

        [Display(Name = "The requested method does not exist")]
        MethodNotFound = 103,

        [Display(Name = "The requested version does not support the functionality")]
        VersionMismatch = 104,

        [Display(Name = "The logged in session does not have permission")]
        NotAuthorized = 105,

        [Display(Name = "Session timeout")]
        SessionTimeout = 106,

        [Display(Name = "Session interrupted by duplicate login")]
        SessionInterrupted = 107,

        [Display(Name = "SID not found")]
        SidNotFound = 119
    }
}
