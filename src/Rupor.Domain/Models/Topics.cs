using Rupor.Domain.References;

namespace Rupor.Domain.Models
{
    public class Topics : BaseModel
    {
        public string Name { get; set; }
        public Picture Picture { get; set; }
        public string Description { get; set; }
    }
}