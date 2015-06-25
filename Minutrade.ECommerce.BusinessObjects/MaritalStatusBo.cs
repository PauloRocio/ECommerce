using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Minutrade.ECommerce.BusinessObjects.App_Codes;
using Minutrade.ECommerce.Dal;
using Minutrade.ECommerce.Dto;

namespace Minutrade.ECommerce.BusinessObjects
{
    public class MaritalStatusBo : IDisposable
    {
        private readonly ECommerceEntities _db = new ECommerceEntities();

        /// <summary>
        /// Método responsável por retornar se existe um estado civil
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool MaritalExists(long id)
        {
            return _db.MaritalStatus.Count(e => e.id == id) > 0;
        }
        
        /// <summary>
        /// Método responsável por retornar uma lista de estado civil
        /// </summary>
        /// <returns></returns> 
        public IEnumerable<MaritalStatuDto> GetMaritalStatus()
        {
            var maritalStatus = _db.MaritalStatus;
            return maritalStatus.To<IEnumerable<MaritalStatuDto>>();

        }

        /// <summary>
        /// Método responsável por buscar um estado civil especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MaritalStatuDto GetMaritalStatu(long id)
        {
            var marital = _db.MaritalStatus.Find(id);

            if (marital == null)
                throw new Exception("Cliente não encontrado!");
            return marital.To<MaritalStatuDto>();
        }

        /// <summary>
        /// Método responsável por atualizar dados de estado civil
        /// </summary>
        /// <param name="id"></param>
        /// <param name="maritalDto"></param>
        public void PutMarital(long id, MaritalStatuDto maritalDto)
        {
            if (id != maritalDto.Id)
                throw new Exception("Erro!");

            var marital = maritalDto.To<MaritalStatu>();

            _db.Entry(marital).State = System.Data.Entity.EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!MaritalExists(id))
                    throw new Exception("Cliente não encontrado!");

                throw;
            }
        }

        /// <summary>
        /// Método responsável por adicionar um estado civil
        /// </summary>
        /// <param name="maritalDto"></param>
        public void PostMaritalStatus(MaritalStatuDto maritalDto)
        {
            var marital = maritalDto.To<MaritalStatu>();

            _db.MaritalStatus.Add(marital);
            _db.SaveChanges();
        }

        /// <summary>
        /// Método responsável por deletar um estado civil
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MaritalStatuDto DeleteMarital(long id)
        {
            MaritalStatu marital = _db.MaritalStatus.Find(id);

            if (marital == null)
                throw new Exception("Cliente não encontrado!");

            _db.MaritalStatus.Remove(marital);
            _db.SaveChanges();

            return marital.To<MaritalStatuDto>();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}