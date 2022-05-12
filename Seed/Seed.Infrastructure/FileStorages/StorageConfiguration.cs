using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Seed.Infrastructure.FileStorages
{
    public class StorageConfiguration
    {
        private readonly string _configurationsFilePath;

        private readonly FileSystemWatcher _configurationsFileWatcher;

        private readonly ConcurrentDictionary<string, object> _storageItems;

        private readonly object _onConfigurationsFileChangedLocker = new object();

        public StorageConfiguration(string configurationsFilePath)
        {
            if (string.IsNullOrEmpty(configurationsFilePath))
                throw new ArgumentException("Value cannot be null or empty.", nameof(configurationsFilePath));
            if (!File.Exists(configurationsFilePath)) throw new ArgumentException($"File {configurationsFilePath} not exists.", nameof(configurationsFilePath));

            _storageItems = new ConcurrentDictionary<string, object>();

            LoadConfigurationsInfo(configurationsFilePath);

            var configurationsFilePathInfo = new FileInfo(configurationsFilePath);

            _configurationsFileWatcher = new FileSystemWatcher
            {
                Path = configurationsFilePathInfo.DirectoryName,
                Filter = configurationsFilePathInfo.Name,
                NotifyFilter = NotifyFilters.LastWrite
            };

            _configurationsFileWatcher.Changed += OnConfigurationsFileChanged;

            _configurationsFileWatcher.EnableRaisingEvents = true;

            _configurationsFilePath = configurationsFilePath;
        }

        public bool TryGetItemValue(string itemKey, out object itemValue)
        {
            return _storageItems.TryGetValue(itemKey, out itemValue);
        }

        private void OnConfigurationsFileChanged(object source, FileSystemEventArgs e)
        {
            lock (_onConfigurationsFileChangedLocker)
            {
                try
                {
                    _configurationsFileWatcher.EnableRaisingEvents = false;

                    LoadConfigurationsInfo(_configurationsFilePath);
                }
                finally
                {
                    _configurationsFileWatcher.EnableRaisingEvents = true;
                }
            }
        }

        private void LoadConfigurationsInfo(string configurationsFilePath)
        {
            var addedOrUpdatedKeys = new List<string>();

            using (var reader = XmlReader.Create(configurationsFilePath))
            {
                while (reader.ReadToFollowing("item"))
                {
                    var currentKey = reader.GetAttribute("key");

                    if (string.IsNullOrEmpty(currentKey)) throw new Exception($"{nameof(StorageConfiguration)} load exception. {nameof(configurationsFilePath)} {configurationsFilePath} is not valid.");

                    object currentValue = reader.ReadElementContentAsObject();

                    _storageItems.AddOrUpdate(currentKey, currentValue, (k, v) => currentValue);

                    addedOrUpdatedKeys.Add(currentKey);
                }
            }

            foreach (string key in _storageItems.Keys)
            {
                if (!addedOrUpdatedKeys.Contains(key))
                {
                    object removedValue;
                    _storageItems.TryRemove(key, out removedValue);
                }
            }
        }
    }
}
