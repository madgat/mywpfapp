namespace MyApp.Utils.Interfaces
{
    public interface ITextFormat<TTarget> : IFormat<string, TTarget> where TTarget : new()
    {
    }
}