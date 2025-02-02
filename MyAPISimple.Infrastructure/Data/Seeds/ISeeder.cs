using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPISimple.Infrastructure.Data.Seeds
{
    internal interface ISeeder
    {
        void Seed(ModelBuilder modelBuilder);
    }
}