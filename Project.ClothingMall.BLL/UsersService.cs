using Project.ClothingMall.Models;
using Project.ClothingMall.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ClothingMall.BLL
{
   
    public class UsersService : BaseService<Users>,IUsersService
    {
        public IQueryable<Users> GetEntities()
        {
            var temp = this.GetCurrentDbSession.UsersDal.LoadEntities(c => c.UserName!= "");
            return temp;
        }
        public Users GetByUserId(int id)
        {
            Users user = this.GetCurrentDbSession.UsersDal.LoadEntities(c=>c.UserId==id).FirstOrDefault();
            return user;
        }
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.UsersDal;
        }
      

     

    }
}
