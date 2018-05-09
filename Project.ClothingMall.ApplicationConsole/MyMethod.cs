using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ClothingMall.ApplicationConsole
{
    public static class MyMethod
    {
        //一个简单的斐波那契额方法
        public static int Fib(int n)
        {
            if (n == 1 || n == 2)
                return 1;
            else
                return Fib(n - 1) + Fib(n - 2);
        }
       public static int Fab(int n,int []a){
           if (n == 1 || n == 2)
           {
               a[n] = 1;
               return 1;
           }
           else
           {
               if (a[n] != 0)
               {
                   return Fab(n - 1, a) + Fab(n - 2, a);
               }
               else
                   a[n + 1] = Fab(n - 1, a) + Fab(n - 2, a);
               return a[n];
           }
           
       }
    }
}
