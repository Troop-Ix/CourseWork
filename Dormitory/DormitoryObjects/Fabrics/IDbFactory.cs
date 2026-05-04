using DormitoryObjects.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Fabrics
{
    public interface IDbFactory
    {
        IDormitoryDatabase Create();
    }
}
