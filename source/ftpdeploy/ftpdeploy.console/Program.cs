using ftpdeploy.Classes.CommandLineArguments;

var parser = new Parser(
    new[] {
        new BoolCommandLineOption("describe-dir")
    });

Console.WriteLine("ftpdeploy application for controlled synchronization tasks");

if (!parser.TryParse(args) || args.Length == 0) {
    Console.WriteLine("Unfortunately there have been problems with the command line arguments.");
    Console.WriteLine("");
    Console.WriteLine("Usage examples:");
    Console.WriteLine(@"ftpdeploy describe-dir --local C:\path\ --ignores ignore-something.json --output C:\listing.json");
    Console.WriteLine(@"ftpdeploy describe-dir --ftp --user xxx --password yyy  --host somehost.com --root / --ignores ignore-something.json --output C:\remote-listing.json");
    Console.WriteLine(@"ftpdeploy find-differences --source listing.json --target remote-listing.json --output differences-between-source-and-target.json");
    Console.WriteLine(@"ftpdeploy create-synchronization-commands --differences differences-between-source-and-target.json --output C:\synchronization-commands.json");
    Console.WriteLine(@"ftpdeploy execute-synchronization --commands C:\synchronization-commands.json --ftp --user xxx --password yyy --host somehost.com --root /");
}

if (parser.GetBoolOption("describe-dir")) {
    Console.WriteLine("Describing directory");
}