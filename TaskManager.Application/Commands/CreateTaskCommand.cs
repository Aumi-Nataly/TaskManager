
using MediatR;

namespace TaskManager.Application.Commands
{
    public class CreateTaskCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ManagerId { get; set; }
    }
}
