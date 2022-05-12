using Seed.Core.Contracts.FileStorages;

namespace Seed.Api.FileStorages
{
    public class BusinessTextsFileStorageSourceGetter : IFileStorageSourceGetter
    {
        public string GetFileFullPath()
        {
            return "C:\\BusinessTexts.xml";
        }
    }
}
