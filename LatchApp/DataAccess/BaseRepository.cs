using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatchApp.DataAccess
{
    public abstract class BaseRepository
    {
        protected string _connString;

        public enum TypeOfExistenceCheck
        {
            DoesExistInDB,
            DoesNotExistInDB
        }

        public enum RequestType
        {
            Add,
            Update,
            Read,
            Delete,
            ConfirmAdd,
            ConfirmDelete
        }
        /*public void Add(BaseRepository elementModel) { }
        public void Update(BaseRepository elementModel) { }
        public void Delete(BaseRepository elementModel) { }
        public void DeleteById(int elementModelID) { }
        public IEnumerable<BaseRepository> GetAll() { return null; }
        public IEnumerable<int> GetAllIds() { return null; }
        public IEnumerable<int> GetReferenceIds() { return null; }*/

    }
}
