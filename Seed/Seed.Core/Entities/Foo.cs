using Seed.Core.Contracts.Entities;

namespace Seed.Core.Entities
{
    public class Foo : IEntity
    {
        public long Id { get; set; }

        public string Title { get; set; }
    }
}
