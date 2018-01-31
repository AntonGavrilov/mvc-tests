using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoqMvcApp.Models
{
    public interface IRepository : IDisposable
    {

        List<Computer> GetComputerList();
        Computer GetComputer(int id);
        void Create(Computer item);
        void Update(Computer item);
        void Delete(int id);
        void Save();
    }


    public class ComputerRepository : IRepository
    {
        private CompContext db;
        private bool disposed = false;

        public ComputerRepository()
        {
            db = new CompContext();
        }
        public void Create(Computer item)
        {
            db.Computers.Add(item);
        }

        public void Delete(int id)
        {
            var comp = db.Computers.Find(id);
            if (comp != null)
                db.Computers.Remove(comp);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Computer GetComputer(int id)
        {
            return db.Computers.Find(id);
        }

        public List<Computer> GetComputerList()
        {
            return db.Computers.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Computer item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }

            disposed = true;
        }


    }
}