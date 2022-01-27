using AppWcf_Cubits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AppWcf_Cubits
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "IUserService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione IUserService.svc o IUserService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class IUserService : IIUserService
    {
        private readonly List<User> db = new List<User>();
        
        public List<User> GetList()
        {
            return new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Matias"
                }
            };
        }
    }
}
