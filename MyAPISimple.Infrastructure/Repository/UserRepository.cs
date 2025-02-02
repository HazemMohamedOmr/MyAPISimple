using MyAPISimple.Core.Interfaces.IRepository;
using MyAPISimple.Core.Models;
using MyAPISimple.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPISimple.Infrastructure.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
        public Task<User> MakeComplexQuery(User user)
        {
            throw new NotImplementedException();
        }
    }
}