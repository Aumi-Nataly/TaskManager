
using MediatR;

namespace TaskManager.Application.Commands
{
    public class CreateManagerCommand: IRequest<int>
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
