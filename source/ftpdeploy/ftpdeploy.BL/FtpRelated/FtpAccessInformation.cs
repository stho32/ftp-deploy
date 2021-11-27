namespace ftpdeploy.BL.FtpRelated;

public class FtpAccessInformation : IFtpAccessInformation
{
    public string User { get; }
    public string Password { get; }
    public string Host { get; }
    public int Port { get; } 

    public FtpAccessInformation(string user, string password, string host, int port) {
        User = user;
        Password = password;
        Host = host;
        Port = port;
    }
}
