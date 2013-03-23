namespace MyApp.Utils.Interfaces
{
    public interface IBinaryFormat<TTarget> : IFormat<byte[], TTarget> where TTarget : new()
    {
    }
}
