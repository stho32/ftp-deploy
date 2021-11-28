using ftpdeploy.Classes.CommandLineArguments;
using ftpdeploy.BL;
using ftpdeploy.BL.Interfaces;

var parser = new Parser(
    new[] {
        new BoolCommandLineOption("describe-dir"),
        new BoolCommandLineOption("find-differences"),
        new BoolCommandLineOption("create-synchronization-commands"),
        new BoolCommandLineOption("execute-synchronization"),
    });

Console.WriteLine("ftpdeploy application for controlled synchronization tasks");

if (!parser.TryParse(args, true) || args.Length == 0) {
    Console.WriteLine("Unfortunately there have been problems with the command line arguments.");
    Console.WriteLine("");
    Console.WriteLine("Usage examples:");
    Console.WriteLine(@"ftpdeploy describe-dir --local C:\path\ --ignores ignore-something.json --output C:\listing.json");
    Console.WriteLine(@"ftpdeploy describe-dir --ftp user:password@somehost.com --ftproot / --ignores ignore-something.json --output C:\remote-listing.json");
    Console.WriteLine(@"ftpdeploy find-differences --source listing.json --target remote-listing.json --output differences-between-source-and-target.json");
    Console.WriteLine(@"ftpdeploy create-synchronization-commands --differences differences-between-source-and-target.json --output C:\synchronization-commands.json");
    Console.WriteLine(@"ftpdeploy execute-synchronization --commands C:\synchronization-commands.json --ftp user:password@somehost.com --ftproot /");
    return;
}

try
{
    var operationsFactory = new OperationsFactory();

    if (parser.GetBoolOption("describe-dir")) {
        operationsFactory.DescribeDir(args).Execute();
    }

    /* ... further commands */
} catch (Exception ex) {
    Console.WriteLine("");
    Console.WriteLine("Exception: " + ex.Message);
    Console.WriteLine("");
}


