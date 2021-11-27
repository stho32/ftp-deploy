using ftpdeploy.BL.Interfaces;

namespace ftpdeploy.BL.DescribeDirectory;

///<summary>
/// ftpdeploy describe-dir --local C:\path\ --ignores ignore-something.json --output C:\listing.json
///</summary>
public class DescribeLocalDirectoryOperation : IOperation
{
    public void Execute()
    {
        Console.WriteLine("I perform a local describing operation on a directory");
    }
}

