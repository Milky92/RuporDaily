using System;

namespace Rupor.Domain.Models
{
    public class BaseModel
    {
        public BaseModel() { }

        public string Id { get; set; }
        public DateTime CreationDate => DateTime.UtcNow;
        /// <summary>
        /// Update time will be zero time zone
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}