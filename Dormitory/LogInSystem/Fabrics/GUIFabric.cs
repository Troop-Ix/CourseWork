using DormitoryObjects;
using DormitoryObjects.Fabrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogInSystem.Fabrics
{
    public class GUIFabric
    {
        public static Form CreateUser(User user, IDbFactory factory)
        {
            switch (user.Type)
            {
                case "Администратор":
                    return new AdministratorForm(factory, user);
                case "Комендант":
                    return new CommandantForm(factory, user);
                default:
                    return null;
            }
        }
    }
}
