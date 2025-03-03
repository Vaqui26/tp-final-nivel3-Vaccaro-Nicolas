using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    public class User
    {
        public int Id { get; set; } 
        public string Email { get; set; }   
        public string Pass { get; set; }    
        public string Nombre {  get; set; }
        public string Apellido { get; set; }
        
        public string ImagenPerfil  { get; set; }

        public TipoUsuario Tipo {  get; set; }  

        public User(string email, string pass) {
            
            this.Email = email; 
            this.Pass = pass;
            this.Tipo = TipoUsuario.Normal;
        }   
    }
    public enum TipoUsuario
    {
        Normal = 1,
        Admin = 2
    }
}
