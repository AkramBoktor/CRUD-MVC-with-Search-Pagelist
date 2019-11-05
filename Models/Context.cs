using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRMCars.Models
{
    public class Context : DbContext

    {
        public Context() :base("carcontext")
        {

        }

    public DbSet<Car> Cars { get; set; }

    }
 
}