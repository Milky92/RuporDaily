using System.Collections;
using System.Collections.Generic;
using Rupor.Domain.References;

namespace Rupor.Domain.Models
{
    public class Article:BaseModel
    {
        public string AuthorId { get; set; }
        public string EditorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }//html css article content
        public Picture TitlePicture { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<TopicInfo> Topics { get; set; }
              
    }
}