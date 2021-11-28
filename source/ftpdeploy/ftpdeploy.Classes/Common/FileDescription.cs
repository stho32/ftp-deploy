using ftpdeploy.Interfaces.Common;

namespace ftpdeploy.Classes.Common;

public class FileDescription : IFileDescription
{
    public string Name { get; }

    public FileDescription(string name)
    {
        Name = name;
    }
}