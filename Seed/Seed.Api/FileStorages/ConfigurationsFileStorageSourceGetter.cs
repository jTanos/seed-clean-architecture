using Seed.Core.Contracts.FileStorages;

namespace Seed.Api.FileStorages
{
    public class ConfigurationsFileStorageSourceGetter : IFileStorageSourceGetter
    {
        public string GetFileFullPath()
        {
            return "C:\\Configurations.xml";
        }
    }
}
