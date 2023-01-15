namespace SynologyNet.DependencyInjection;

public record SynologyOptions
{
    /// <summary>
    /// Synology host ip address or hostname
    /// </summary>
    public string Host { get; set; } = string.Empty;

    /// <summary>
    /// Synology host port number
    /// </summary>
    public int Port { get; set; } = 5000;

    /// <summary>
    /// Synology user to log in to
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Synology user password
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
