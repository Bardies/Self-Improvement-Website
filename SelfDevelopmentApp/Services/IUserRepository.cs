using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Services
{
    public interface IUserRepository
    {
        public List<Models.ApplicationUser> AllUser();
    }
}
