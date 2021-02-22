using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rupor.Business.Topics.Commands.RequestModels
{
    public class CreateTopicRequest : IRequest
    {
        public string Name { get; set; }
    }
}
