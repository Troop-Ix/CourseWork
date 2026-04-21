using DormitoryObjects;
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
        public static Form CreateUser(User user)
        {
            switch (user.Type)
            {
                case "Администратор":
                    return new AdministratorForm();
                case "Комендант":
                    return new CommandantForm();
                default:
                    return null;
            }
        }
    }
}
