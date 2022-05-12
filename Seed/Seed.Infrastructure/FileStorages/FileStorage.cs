using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Seed.Core.Contracts.FileStorages;

namespace Seed.Infrastructure.FileStorages
{
    public class FileStorage : IFileStorage
    {
        private static readonly Dictionary<string, StorageConfiguration> StorageConfigurations = new Dictionary<string, StorageConfiguration>();

        private static readonly ConcurrentDictionary<string, object> FileStorageSourceGettersLoadLocker = new ConcurrentDictionary<string, object>();

        public T GetValue<T>(IFileStorageSourceGetter fileStorageSourceGetter, string key) where T : IConvertible
        {
            string currentStorageFileFullPath = fileStorageSourceGetter.GetFileFullPath();

            lock (FileStorageSourceGettersLoadLocker.GetOrAdd(currentStorageFileFullPath, x=> new object()))
            {
                if (!StorageConfigurations.ContainsKey(currentStorageFileFullPath))
                {
                    StorageConfigurations[currentStorageFileFullPath] = new StorageConfiguration(currentStorageFileFullPath);
                }
            }

            object value;

            if (!StorageConfigurations[currentStorageFileFullPath].TryGetItemValue(key, out value))
            {
                throw new ArgumentException($"{nameof(key)} {key} not exists.");
            }

            return ParsedItemValue<T>(value);
        }

        private static T ParsedItemValue<T>(object value)
        {
            try
            {
                var typeToBeConverted = typeof(T);

                if (typeToBeConverted.IsEnum)
                {
                    return (T)Enum.Parse(typeToBeConverted, value.ToString());
                }

                return (T)Convert.ChangeType(value, typeToBeConverted);
            }
            catch (Exception ex)
            {
                throw new TypeInitializationException($"{typeof(T).FullName}", ex);
            }
        }
    }
}
