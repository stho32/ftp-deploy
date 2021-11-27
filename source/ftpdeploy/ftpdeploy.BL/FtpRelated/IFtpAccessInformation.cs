namespace ftpdeploy.BL.FtpRelated;

public interface IFtpAccessInformation
{
    string User { get; }
    string Password { get; }
    string Host { get; }
    int Port { get; } 
}
