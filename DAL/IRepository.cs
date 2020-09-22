using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL {
    public interface IRepository<T> where T : class {
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetAllWithIncludes();
        public T Add(T item);
        public T Get(T item);
        public T GetById(double id);
        public T Update(T item);
        public T RemoveById(double id);
    }
}
