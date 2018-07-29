using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni.Data.Contracts
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
