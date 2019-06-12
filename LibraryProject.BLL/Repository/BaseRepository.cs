using LibraryProject.DAL.ORM.Context;
using LibraryProject.DAL.ORM.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace LibraryProject.BLL.Repository
{
    public class BaseRepository<T> where T : BaseEntity
    {
        private ProjectContext db;

        protected DbSet<T> table;

        public BaseRepository()
        {
            db = new ProjectContext();
            table = db.Set<T>();
        }
        public int Save()
        {
            return db.SaveChanges();
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }
        public void Add(T item)
        {
            item.Status = DAL.ORM.Enum.Status.Active;
            table.Add(item);
            Save();
        }
        public bool Any(Expression<Func<T, bool>> exp) => table.Any(exp);

        public List<T> GetActive()
        {
            return table.Where(x => x.Status == DAL.ORM.Enum.Status.Active || x.Status == DAL.ORM.Enum.Status.Updated).ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return table.Where(exp).FirstOrDefault();
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return table.Where(exp).ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Remove(int id)
        {
            T item = GetById(id);
            item.Status = DAL.ORM.Enum.Status.Deleted;
            Update(item);
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Status = DAL.ORM.Enum.Status.Deleted;
                Update(item);
            }
        }
        public void Update(T item)
        {
            T update = GetById(item.ID);
            EntityEntry entry = db.Entry(update);
            entry.CurrentValues.SetValues(item);
            Save();
        }

    }
}
