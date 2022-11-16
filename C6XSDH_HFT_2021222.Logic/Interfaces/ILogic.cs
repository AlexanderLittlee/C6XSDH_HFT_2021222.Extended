using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6XSDH_HFT_2021222.Logic.Interfaces
{
    public interface ILogic<T>
    {
        void Create(T thing);

        IQueryable<T> ReadAll();

        T Read(int id);

        void Update(T thing);

        void Delete(int id);

    }
}
