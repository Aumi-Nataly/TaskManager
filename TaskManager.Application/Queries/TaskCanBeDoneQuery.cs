
using MediatR;

namespace TaskManager.Application.Queries
{
    public class TaskCanBeDoneQuery : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
