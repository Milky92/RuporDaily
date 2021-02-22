using MediatR;
using Rupor.Business.Topics.Commands.RequestModels;
using Rupor.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rupor.Business.Topics.Commands.Handlers
{
    public class CreateTopicHandler : IRequestHandler<CreateTopicRequest>
    {
        private readonly IDatabaseContext _context;
        public CreateTopicHandler(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateTopicRequest request, CancellationToken cancellationToken)
        {
            //using (var context = _dataContext.GetContext())
            {
                await _context.Topics.AddAsync(new Domain.Models.Topic
                {
                    Name = request.Name
                }, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
