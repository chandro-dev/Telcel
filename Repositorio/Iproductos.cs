using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public interface Iproductos<i>
    {
        public List<i> getAll();
        public string add(i item);
        public string remove(i item);
        public string modify(i item);
    }
}
