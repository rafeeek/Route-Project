using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Layer.Interface
{
    public interface Interface<Demo>
    {
        public IEnumerable<Demo> AllData();
        public void Creat(Demo obj);
        public Demo GetById(int Id);
        public void Updata(Demo obj);
        public void Delete(Demo obj);
    }
}
