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
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        private readonly ApplicationDbContext _db;

        public ExerciseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Exercise exercise)
        {
            throw new NotImplementedException();
        }
    }
}
