using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ClothingMall.IDAL
{
    public interface IDBSession
    {
        IUsersDal UsersDal { get; set; }
        bool SaveChanges();
    }
}
