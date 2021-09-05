using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Layer.Interface
{
    public interface IcountryRepo<type>
    {
        IEnumerable<type> GetAll();
        type GetById(int id);
    }
}
