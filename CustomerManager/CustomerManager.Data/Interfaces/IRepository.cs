using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public List<T> Get(T t);
        public int Insert(T t, Guid createUser);
    }
}
