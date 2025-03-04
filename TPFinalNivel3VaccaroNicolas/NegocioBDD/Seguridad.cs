using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace NegocioBDD
{
    static public class Seguridad
    {
        static public bool sesionAbierta(Object user)
        {
            User trainee = user != null ? (User)user : null;
            return trainee != null && trainee.Id != 0;
        }
        static public bool esAdmin(User user)
        {
            User trainee = user != null ? (User)user : null;
            return trainee != null ? trainee.Admin : false;
        }

    }
}
