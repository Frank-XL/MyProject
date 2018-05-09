using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ClothingMall.DAL
{
    public class BaseDal<T> where T : class,new()
    {
        // OAEntities Db = new OAEntities();
        DbContext Db = DbContextFactory.CreateDbContext();//通过获得当前的上下文对象,使得后面可以不用频繁地创建和调用上下文对象
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where<T>(whereLambda);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted; 
            // return Db.SaveChanges() > 0;
            return true;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool EditEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            // return Db.SaveChanges() > 0;
            return true;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            Db.Set<T>().Add(entity);
            // Db.SaveChanges();
            return entity;
        }
    }
}
