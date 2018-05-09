using Project.ClothingMall.DAL;
using Project.ClothingMall.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ClothingMall.DALFactory
{
    /// <summary>
    /// DBSession;工厂类（数据会话层），作用：创建数据操作类的实例，业务层通过DBSession调用相应的数据操作类的实例，这样将业务层与数据层解耦。
    /// </summary>
    public class DBSession : IDBSession
    {
        //OAEntities Db = new OAEntities();
        public DbContext Db                                             //获得当前的DbContext的值
        {
            get { return DbContextFactory.CreateDbContext(); }
        }
        /// <summary>
        /// UserInfo
        /// </summary>
        private IUsersDal _UsersDal;
        public IUsersDal UsersDal
        {
            get
            {
                if (_UsersDal == null)
                {
                    // _UserInfoDal = new UserInfoDal();                  //如果要更换数据层，这里也要修改。
                    _UsersDal = AbstractFactory.CreateUsersInfoDal();
                }
                return _UsersDal;

            }
            set { _UsersDal = value; }

        }
        /// <summary>
        /// 一个业务中有可能涉及到对多张表的操作，那么可以将操作的数据，传递到数据层中相应的方法，打上相应的标记，最后调用该方法，将数据一次性提交到数据库中，避免了多次链接数据库。
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return Db.SaveChanges() > 0;
        }


    }
}
