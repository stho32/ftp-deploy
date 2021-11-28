using ftpdeploy.BL.FtpRelated;
using ftpdeploy.BL.Interfaces;

namespace ftpdeploy.BL.DescribeDirectory;

public class DescribeFtpDirectoryOperation : IOperation
{
    private IFtpAccessInformation ftpAccessInformation;
    private string? outputParameter;

    public DescribeFtpDirectoryOperation(IFtpAccessInformation ftpAccessInformation, string? outputParameter)
    {
        this.ftpAccessInformation = ftpAccessInformation;
        this.outputParameter = outputParameter;
    }

    public void Execute()
    {
        Console.WriteLine("I perform a ftp describing operation on a directory");
    }
}