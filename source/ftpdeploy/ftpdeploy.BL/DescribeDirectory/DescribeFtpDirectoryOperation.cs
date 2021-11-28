using FluentFTP;
using ftpdeploy.BL.FtpRelated;
using ftpdeploy.BL.Interfaces;

namespace ftpdeploy.BL.DescribeDirectory;

///<summary>
/// ftpdeploy describe-dir --ftp user:password@somehost.com --ftproot / --ignores ignore-something.json --output C:\remote-listing.json
///</summary>
public class DescribeFtpDirectoryOperation : IOperation
{
    private readonly IFtpAccessInformation ftpAccessInformation;
    private readonly string? ftpRootParameter;
    private readonly string? outputParameter;

    public DescribeFtpDirectoryOperation(
        IFtpAccessInformation ftpAccessInformation, 
        string? ftpRootParameter,
        string? outputParameter)
    {
        this.ftpAccessInformation = ftpAccessInformation;
        this.ftpRootParameter = ftpRootParameter;
        this.outputParameter = outputParameter;
    }

    public void Execute()
    {
        Console.WriteLine("I perform a ftp describing operation on a directory");

        FtpClient client = new FtpClient(
            ftpAccessInformation.Host, 
            ftpAccessInformation.User, 
            ftpAccessInformation.Password);

        client.AutoConnect();

        var items = client.GetListing();
        foreach (var item in items) {
            Console.WriteLine(item.FullName);
        }
    }
}