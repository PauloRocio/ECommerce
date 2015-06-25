using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Minutrade.ECommerce.BusinessObjects.App_Codes;
using Minutrade.ECommerce.CommonObjects.Validations;
using Minutrade.ECommerce.Dal;
using Minutrade.ECommerce.Dto;

namespace Minutrade.ECommerce.BusinessObjects
{
    public class ClientsBo : IDisposable
    {
        private readonly ECommerceEntities _db = new ECommerceEntities();

        /// <summary>
        /// Método responsável por retornar um bool se cliente existe ou não
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ClientExists(long id)
        {
            return _db.Clients.Count(e => e.Id == id) > 0;
        }

        /// <summary>
        /// Método responsável por retornar uma lista de clientes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ClientDto> GetClients()
        {
            var clientDto = (from client in _db.Clients
                                  join state in _db.States on client.StateId equals state.id
                                  join maritaStatus in _db.MaritalStatus on client.MaritalStatusId equals maritaStatus.id
                             orderby client.Name
                             select new ClientDto
                             {
                                 Id                = client.Id,
                                 Cpf               = client.Cpf,
                                 Name              = client.Name,
                                 Email             = client.Email,
                                 StateName         = state.StatesName,
                                 MaritalStatusName = maritaStatus.MaritalStatus,
                             }).ToList();

            return clientDto;
        }

        /// <summary>
        /// Método responsável por retornar um cliente específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ClientDto GetClient(long id)
        {
            var client = _db.Clients.Find(id);
            
            if (client == null)
                throw new Exception("Cliente não encontrado!");

            return client.To<ClientDto>();
        }

        /// <summary>
        /// Método responsável por atualizar os dados do cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clientDto"></param>
        public void PutClient(long id, ClientDto clientDto)
        {
            if (id != clientDto.Id)
                throw new Exception("Erro!");

            if (!Cpf.Validade(clientDto.Cpf))
                throw new Exception("Erro! CPF inválido.");

            var client = clientDto.To<Client>();

            _db.Entry(client).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                    throw new Exception("Cliente não encontrado!");
             
                throw;
            }
        }

        /// <summary>
        /// Método responsável por atualizadar dados do cliente
        /// </summary>
        /// <param name="clientDto"></param>
        public void PostClient(ClientDto clientDto)
        {
            if (!Cpf.Validade(clientDto.Cpf))
                throw new Exception("Erro! CPF inválido.");

            var client = clientDto.To<Client>();

            _db.Clients.Add(client);
            _db.SaveChanges();
        }

        /// <summary>
        /// Método responsável por deletar um cliente específico
        /// </summary>
        /// <param name="id"></param>
        public ClientDto DeleteClient(long id)
        {
            Client client = _db.Clients.Find(id);
            
            if (client == null)
                throw new Exception("Cliente não encontrado!");

            _db.Clients.Remove(client);
            _db.SaveChanges();

            return client.To<ClientDto>();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}