using Project.ClothingMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ClothingMall.IBLL
{
    
    public interface IUsersService : IBaseService<Users>
    {
         IQueryable<Users> GetEntities();

         Users GetByUserId(int? id);
    }
}
