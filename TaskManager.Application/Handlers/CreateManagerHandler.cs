

using MediatR;
using TaskManager.Application.Commands;
using TaskManager.Application.Service;

namespace TaskManager.Application.Handlers
{
    public class CreateManagerHandler: IRequestHandler<CreateManagerCommand,int>
    {
        private readonly IManager _manager;
        public CreateManagerHandler(IManager manager) 
        {
            _manager = manager;
        }

        public async Task<int> Handle(CreateManagerCommand request, CancellationToken cancellationToken)
        {
            return await _manager.AddManager(request.Name, request.Surname, cancellationToken);
        }
    }
}
