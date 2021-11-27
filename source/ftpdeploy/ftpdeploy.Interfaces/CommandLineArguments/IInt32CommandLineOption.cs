namespace ftpdeploy.Interfaces.CommandLineArguments;

public interface IInt32CommandLineOption : ICommandLineOption {
    int GetValue();
}