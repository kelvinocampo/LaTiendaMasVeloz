using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Modelo;
using Modelo.Entities;

namespace Logica
{
    public class UsuarioController
    {
        public DataTable GetAll()
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            DataTable dataTable = new DataTable();
            dataTable= usuarioDB.GetAll();
            return dataTable;
        }

        public void Delete(int ID)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            usuarioDB.Delete(ID);
        }

        public void Update(int ID, int Doc, string email, string phone, string name, string address, string role)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            Usuario usuario = new Usuario();
            usuario.Doc = Doc;
            usuario.email = email;
            usuario.phone = phone;
            usuario.name = name;
            usuario.address = address;
            usuario.role = role;

            bool usuarioExist = GetByID(ID);

            if (usuarioExist)
            {
                usuarioDB.Update(ID, usuario);
            }
            else
            {
                Create(Doc, email, phone, name, address, role);
            }
        }

        public bool GetByID(int ID)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            var usuario = usuarioDB.Get(ID);

            if (usuario == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Create( int Doc, string email, string phone, string name, string address, string role)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            Usuario usuario = new Usuario();
            usuario.Doc = Doc;
            usuario.email = email;
            usuario.phone = phone;
            usuario.name = name;
            usuario.address = address;
            usuario.role = role;
            usuarioDB.Create(usuario);
        }
    }
}
