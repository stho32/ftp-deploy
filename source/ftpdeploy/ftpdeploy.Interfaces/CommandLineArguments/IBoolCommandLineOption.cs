namespace ftpdeploy.Interfaces.CommandLineArguments;

public interface IBoolCommandLineOption : ICommandLineOption
{
    bool GetValue();
}
