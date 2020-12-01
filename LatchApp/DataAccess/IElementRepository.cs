using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LatchApp.DataAccess
{
    public interface IElementRepository<T>
    {
        void Add(T elementModel);
        void Update(T elementModel);
        void Delete(T elementModel);
        void DeleteById(int elementModelID);
        IEnumerable<T> GetAll();
        IEnumerable<int> GetAllIds();
        IEnumerable<int> GetReferenceIds();
    }
}
