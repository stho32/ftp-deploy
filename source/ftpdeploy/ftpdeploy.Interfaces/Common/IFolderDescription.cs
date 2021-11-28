namespace ftpdeploy.Interfaces.Common;

public interface IFolderDescription {
    string Name { get; }
    IFileDescription[] Files { get; }
    IFolderDescription[] Folders { get; }
}
