using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellphones
{
    public interface ICellphonesRepository
    {
        void Add(Cellphone phone);
        void Remove(int id);
        IEnumerable<Cellphone> GetAll();
    }
}
