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
                new StringCommandLineOption("--local"),
                new StringCommandLineOption("--ignores"),
                new StringCommandLineOption("--output")
            });
        
        if (!parser.TryParse(args)) {
            Console.WriteLine("bad arguments for describe-dir subcommand");
            return new DoNothing.DoNothingOperation();
        }

        return new DoNothing.DoNothingOperation();
    }
}

