using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ClothingMall.IBLL
{
    public interface IBaseService<T> where T : class,new()
    {
        IDAL.IDBSession GetCurrentDbSession { get; }     //获得当前上下文的Session
        IDAL.IBaseDal<T> CurrentDal { get; set; }        //获得当前上下文的DAL 
        IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);
        bool DeleteEntity(T entity);
        bool EditEntity(T entity);
        T AddEntity(T entity);

    }
}
