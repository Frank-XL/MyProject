using Project.ClothingMall.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project.ClothingMall.DALFactory
{
    /// <summary>
    /// 抽象工厂：与工厂本质是一样的，都解决对象的创建问题。区别在创建对象的方式不一样，抽象工厂是通过反射的方式创建类的实例。
    /// </summary>
    public class AbstractFactory
    {
        private static readonly string DalAssemblyPath = ConfigurationManager.AppSettings["DalAssemblyPath"];//设置当前的
        private static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];
        /// <summary>
        /// 创建UserInfo的实例
        /// </summary>
        /// <returns></returns>
        public static IUsersDal CreateUsersInfoDal() //创建当前的用户访问实体
        {
            string fullClassName = NameSpace + ".UsersDal";//构建类的全名称.
            return CreateInstance(fullClassName) as IUsersDal;
        }
       
        /// <summary>
        /// 反射
        /// </summary>
        /// <param name="fullClassName"></param>
        public static object CreateInstance(string fullClassName)
        {
            var assembly = Assembly.Load(DalAssemblyPath);//加载程序集
            return assembly.CreateInstance(fullClassName);
        }

    }
}
