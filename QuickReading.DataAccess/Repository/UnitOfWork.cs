using QuickReading.DataAccess.Repository.IRepository;
using QuickReading.MVC.Data;
using QuickReading.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReading.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IExerciseRepository Exercise { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Exercise = new ExerciseRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
