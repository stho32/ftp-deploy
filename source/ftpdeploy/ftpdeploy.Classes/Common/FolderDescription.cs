using ftpdeploy.Interfaces.Common;

namespace ftpdeploy.Classes.Common;

public class FolderDescription : IFolderDescription
{
    public string Name { get; }

    public IFileDescription[] Files { get; }
    public IFolderDescription[] Folders { get; }

    public FolderDescription(
        string name, 
        IFileDescription[] files,
        IFolderDescription[] folders)
    {
        Name = name;
        Files = files;
        Folders = folders;
    }
}
