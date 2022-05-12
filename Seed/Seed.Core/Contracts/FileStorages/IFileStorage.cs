using System;

namespace Seed.Core.Contracts.FileStorages
{
    public interface IFileStorage
    {
        T GetValue<T>(IFileStorageSourceGetter fileStorageSourceGetter, string key) where T : IConvertible;
    }
}
