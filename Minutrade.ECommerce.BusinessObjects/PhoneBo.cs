using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Minutrade.ECommerce.BusinessObjects.App_Codes;
using Minutrade.ECommerce.Dal;
using Minutrade.ECommerce.Dto;

namespace Minutrade.ECommerce.BusinessObjects
{
    public class PhoneBo : IDisposable
    {
        private readonly ECommerceEntities _db = new ECommerceEntities();

        /// <summary>
        /// Método responsável por retornar se existe um telefone
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool PhoneExists(long id)
        {
            return _db.Phones.Count(e => e.id == id) > 0;
        }

        /// <summary>
        /// Método responsável por retornar uma lista de telefones
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PhoneDto> GetPhones()
        {
            var phoneDto = (from phone in _db.Phones
                                join client in _db.Clients on phone.ClientId equals client.Id
                           orderby client.Cpf
                           select new PhoneDto()
                           {
                               Id      = phone.id,
                               CodArea = phone.CodArea,
                               Number  = phone.Number,
                               Cpf     = client.Cpf
                           }).ToList();


            return phoneDto;
        }

        /// <summary>
        /// Método responsável por buscar um telefone especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PhoneDto GetPhone(long id)
        {
            var phone = _db.Phones.Find(id);
            if(phone == null)
                throw new Exception("Telefone não encontrado");

            return phone.To<PhoneDto>();
        }

        /// <summary>
        /// Método responsável por atualizar um telefone
        /// </summary>
        /// <param name="id"></param>
        /// <param name="phoneDto"></param>
        public void PutPhone(long id, PhoneDto phoneDto)
        {
            if (id != phoneDto.Id)
                throw new Exception("Erro!");

            var phone = phoneDto.To<Phone>();

            _db.Entry(phone).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneExists(id))
                    throw new Exception("Telefone não encontrado");
                
                throw;
            }
        }

        /// <summary>
        /// Método responsável por adicionar um telefone
        /// </summary>
        /// <param name="phoneDto"></param>
        public void PostPhone(PhoneDto phoneDto)
        {
            var phone = phoneDto.To<Phone>();

            _db.Phones.Add(phone);
            _db.SaveChanges();
        }

        /// <summary>
        /// Método responsável por deletar um telefone
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PhoneDto DeletePhone(long id)
        {
            Phone phone = _db.Phones.Find(id);

            if (phone == null)
                throw new Exception("Telefone não encontrado");

            _db.Phones.Remove(phone);
            _db.SaveChanges();

            return phone.To<PhoneDto>();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}