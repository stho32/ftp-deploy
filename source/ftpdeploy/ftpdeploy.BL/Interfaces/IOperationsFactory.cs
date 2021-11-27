namespace ftpdeploy.BL.Interfaces;

public interface IOperationsFactory {
    IOperation DescribeDir(string[] args);
}

