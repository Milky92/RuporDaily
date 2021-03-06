using Rupor.Domain.Doc;
using Rupor.Domain.Models.Base;

namespace Rupor.Domain.References
{
    public class Tag:BaseDocument
    {
        public string Name { get; set; }
        public string Author { get; set; }
    }
}