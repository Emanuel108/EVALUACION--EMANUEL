using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebAppEvaluacionEmanuel.Data;
using WebAppEvaluacionEmanuel.Data.Models;

namespace EvaluacionEmanuelLibrary
{
    public class ClientLibrary
    {
        private readonly WebAppEvaluacionEmanuelDbContext _context;

        public ClientLibrary(WebAppEvaluacionEmanuelDbContext context)
        {
            _context = context;
        }

        public Cliente CreateClient(Cliente model)
        {
            try
            {
                var cliente = new Cliente
                {
                    NoCliente = GetNoClient(model),
                    Nombre = model.Nombre,
                    ApellidoPaterno = model.ApellidoPaterno,
                    ApellidoMaterno = model.ApellidoMaterno,
                    Domicilio = model.Domicilio,
                    CreatedAt = DateTime.Now,
                };

                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                return cliente;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public List<Cliente> GetClients()
        {
            var result = _context.Clientes.Where(x => x.Estatus == false).OrderByDescending(x => x.CreatedAt).ToList();

            return result;
        }

        public Cliente GetClientById(Guid id)
        {
            var result = _context.Clientes.Where(x => x.Id == id).FirstOrDefault();

            if(result != null)
            {
                return result;
            }

            return null;
 
        }

        public string GetNoClient(Cliente model)
        {
            var s = model.Nombre.Substring(0, 1) + model.ApellidoPaterno.Substring(0, 1) + model.ApellidoMaterno.Substring(0, 1);
            var noClient = s.ToUpper();

            return noClient;
        }

    }
}