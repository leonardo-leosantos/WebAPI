using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class RepositorioController : ApiController
    {
        private ClienteRepository repository = new ClienteRepository();

        // GET: api/Cliente
        public List<Cliente> Get()
        {
            return repository.GetAll();
        }

        // GET: api/Cliente/5
        public Cliente Get(int id)
        {

            return repository.GetById(id);
        }

        // POST: api/Cliente
        public void Post([FromBody]Cliente cliente)
        {
            ClienteRepository clienteRepository = new ClienteRepository();
            clienteRepository.Save(cliente);
        }


        // PUT: api/Cliente/5
        public void Put(int id, [FromBody]Cliente clienteAlterado)
        {
            ClienteRepository clienteRepository = new ClienteRepository();
            clienteRepository.Update(clienteAlterado);

        }

        // DELETE: api/Cliente/5

        public void Delete(int id)
        {
            ClienteRepository clienteRepository = new ClienteRepository();
            clienteRepository.DeleteById(id);           

        }

    }
}
