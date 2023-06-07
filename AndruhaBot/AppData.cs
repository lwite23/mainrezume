using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndruhaBot
{
    public enum TableName
    {
        Education,
        Grafik,
        Pol,
        Rezume,
        Role,
        User,
        UserRezume,
        Zanaytost
    }
    public static class AppData
    { 
        public static mainbaseEntities db = new mainbaseEntities();
    }   
}
