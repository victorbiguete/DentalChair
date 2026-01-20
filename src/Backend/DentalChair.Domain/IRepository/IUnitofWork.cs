using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalChair.Domain.IRepository
{
    public interface IUnitofWork
    {
        public Task Commit();
    }
}
