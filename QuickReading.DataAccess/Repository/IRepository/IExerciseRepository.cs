using QuickReading.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickReading.DataAccess.Repository.IRepository
{
    public interface IExerciseRepository : IRepository<Exercise>
    {
        public void Update(Exercise exercise);
    }
}
