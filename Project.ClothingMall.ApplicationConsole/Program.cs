using Project.ClothingMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ClothingMall.ApplicationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int n=5;
            //int num = MyMethod.Fib(n);
            //Console.WriteLine(num);
            int[] a = new int[100];
            a[1] = 1;
            a[2] = 1;
            //foreach(int item in a){
            //    Console.WriteLine(item);
            //}
            int num = MyMethod.Fab(5, a);
            Console.WriteLine(num);
            
            Console.ReadKey();
        }
    }
}
//IBLL.IUsersService usersService = new BLL.UsersService();

//            Users users = usersService.GetEntities().FirstOrDefault();
            
//            Console.WriteLine(users.UserId.ToString());
//            Console.WriteLine(users.UserName.ToString());
//            Console.WriteLine(users.UserPassword.ToString());
//            Console.WriteLine(users.CreateTime.ToString());
//            Console.WriteLine(users.UpdateTime.ToString());
//            Console.WriteLine(users.Status.ToString());