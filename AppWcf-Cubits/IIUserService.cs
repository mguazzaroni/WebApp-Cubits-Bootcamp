using AppWcf_Cubits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AppWcf_Cubits
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IIUserService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IIUserService
    {
        [OperationContract]
        List<User> GetList();
    }
}
