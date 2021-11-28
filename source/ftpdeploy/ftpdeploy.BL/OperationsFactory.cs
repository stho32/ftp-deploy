using ftpdeploy.BL.FtpRelated;
using ftpdeploy.BL.Interfaces;
using ftpdeploy.Classes.CommandLineArguments;
using ftpdeploy.Interfaces.CommandLineArguments;

namespace ftpdeploy.BL;

public class OperationsFactory : IOperationsFactory
{
    ///<summary>
    /// ftpdeploy describe-dir --local C:\path\ --ignores ignore-something.json --output C:\listing.json
    /// ftpdeploy describe-dir --ftp user:password@somehost.com --ftproot / --ignores ignore-something.json --output C:\remote-listing.json
    ///</summary>    
    public IOperation DescribeDir(string[] args)
    {
        var parser = new Parser(
            new ICommandLineOption[] {
                new BoolCommandLineOption("describe-dir"),
                new StringCommandLineOption("--ftp"),
                new StringCommandLineOption("--ftproot"),
                new StringCommandLineOption("--local"),
                new StringCommandLineOption("--ignores"),
                new StringCommandLineOption("--output")
            });
        
        if (!parser.TryParse(args, false)) {
            Console.WriteLine("bad arguments for describe-dir subcommand");
            return new DoNothing.DoNothingOperation();
        }

        var ftpDataParameter = parser.TryGetOptionWithValue<string>("--ftp");
        var ftpRootParameter = parser.TryGetOptionWithValue<string>("--ftproot");
        var localDirectoryParameter = parser.TryGetOptionWithValue<string>("--local");
        var ignoresParameter = parser.TryGetOptionWithValue<string>("--ignores");
        var outputParameter = parser.TryGetOptionWithValue<string>("--output");

        Console.WriteLine(" - FTP Access Information: " + (string.IsNullOrWhiteSpace(ftpDataParameter)?"No":"Yes"));
        Console.WriteLine(" - FTP Root Information: " + (string.IsNullOrWhiteSpace(ftpRootParameter)?"No":"Yes"));
        Console.WriteLine(" - Local Directory: " + (string.IsNullOrWhiteSpace(localDirectoryParameter)?"No":"Yes"));
        Console.WriteLine(" - Ignore: " + (string.IsNullOrWhiteSpace(ignoresParameter)?"No":"Yes"));
        Console.WriteLine(" - Output: " + (string.IsNullOrWhiteSpace(outputParameter)?"No":"Yes"));

        if (!string.IsNullOrWhiteSpace(ftpDataParameter)) {
            var ftpAccessInformation = FtpRelated.FtpStringParser.Parse(ftpDataParameter);
            return new DescribeDirectory.DescribeFtpDirectoryOperation(
                ftpAccessInformation,
                ftpRootParameter,
                outputParameter
            );
        }

        return new DescribeDirectory.DescribeLocalDirectoryOperation(
            localDirectoryParameter,
            outputParameter
        );
    }
}

