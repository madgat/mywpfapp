using System;

namespace MyApp.Utils.Interfaces
{
    public interface IFormat<TSource, TTarget> where TTarget : new()
    {
        string Name { get; }
        string Description { get; }
        Version Version { get; }

        TTarget Read(TSource input);
        TSource Write(TTarget output);
    }
}