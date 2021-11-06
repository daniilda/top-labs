namespace ChainOfResponsibility.CheckStrategy.Abstractions
{
    public interface ICheckStrategy
    {
        ICheckStrategy SetNext(ICheckStrategy parseStrategy);
        (bool, ICheckStrategy) Check(ICheckResponse parseData);
        string GetErrorMessage();
    }
}