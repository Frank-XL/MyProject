using Project.ClothingMall.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Project.ClothingMall.DAL
{
    public class DbContextFactory
    {
        /// <summary>
        /// 保证EF上下文实例是线程内唯一。
        /// </summary>
        /// <returns></returns>
        public static DbContext CreateDbContext()
        {
            DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            if (dbContext == null)
            {
                dbContext = new ClothingMallEntities();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;//如果有则直接返回这个DBContext
        }
    }
}
