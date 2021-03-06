using Rupor.Domain.Doc;
using System;

namespace Rupor.Domain.Models.Base
{
    public class BaseModel : BaseDocument
    {
        public string Id { get; set; }

        public bool Visibility { get; set; }

        public BaseModel() 
        {
            Visibility = true;
        }        
    }
}