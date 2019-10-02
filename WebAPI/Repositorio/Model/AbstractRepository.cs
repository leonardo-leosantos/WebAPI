using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebAPI.Repositorio.Model
{
    public abstract class AbstractRepository<Cliente, cliente>
        where Cliente : class
    {
        protected string StringConnection { get; } = WebConfigurationManager.ConnectionStrings["TBCliente"].ConnectionString;

        public abstract List<Cliente> GetAll();
        public abstract Cliente GetById(cliente id);
        public abstract void Save(Cliente entity);
        public abstract void Update(Cliente entity);
        public abstract void Delete(Cliente entity);
        public abstract void DeleteById(cliente id);
    }
}