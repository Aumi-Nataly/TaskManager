using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Service
{
    public interface IManager
    {
        Task<int> AddManager(string name, string surname, CancellationToken cancellationToken);
    }
}
