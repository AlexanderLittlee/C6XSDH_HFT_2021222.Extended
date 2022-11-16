using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6XSDH_HFT_2021222.Repository.REPOSITORY
{
    public interface IRepository<T>
    {
        void Create(T thing);
        T Read(int id);
        IQueryable<T> ReadAll();
        void Update(T thing);
        void Delete(int id);

    }
}
