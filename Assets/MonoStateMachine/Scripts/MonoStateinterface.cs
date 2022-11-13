namespace MonoState.Data
{
    public interface IMonoDatable
    {
        string Path { get; }
    }

    public interface IMonoDatableSystem<Data> : IMonoDatable
    {
        Data GetData { get; }
    }

    public interface IMonoDatableUni<Data> : IMonoDatable where Data : UnityEngine.Object  
    {
        Data GetData { get; }
    }
}