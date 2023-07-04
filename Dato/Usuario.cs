using BrainLinkConnect.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainLinkConnect.Dato
{
    public class Usuario
    {
        List<UsuarioModel> lista = new List<UsuarioModel>();
        /// <summary>
        /// Guarda nombre y edad del usuario
        ///
        /// </summary>
        /// <param name="modelo">nombre y edad del usuario</param>
        public void Guardar(UsuarioModel modelo)
        {
            lista.Add(modelo);
        } 
        /// <summary>
        /// Consulta todos los usuarios
        /// </summary>
        /// <returns>datos de usuarios</returns>
        public List<UsuarioModel> Consultar()
        {
            return lista;

        }
    }
}
