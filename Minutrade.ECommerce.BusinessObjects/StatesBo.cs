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
    public class StatesBo : IDisposable
    {
        private readonly ECommerceEntities _db = new ECommerceEntities();

        /// <summary>
        /// Método responsável por retornar se existe um estado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool StatesExists(long id)
        {
            return _db.States.Count(e => e.id == id) > 0;
        }

        /// <summary>
        /// Método responsável por retornar lista de estados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StateDto> GetStates()
        {
            var states = _db.States;
            return states.To<IEnumerable<StateDto>>();
        }

        /// <summary>
        /// Método responsável por retornar estado especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StateDto GetState(long id)
        {
            var state = _db.States.Find(id);
            if (state == null)
                throw new Exception("Estado não encontrado!");
            return state.To<StateDto>();
        }

        /// <summary>
        /// Método responsável por atualizar o estado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statesDto"></param>
        public void PutStates(long id, StateDto statesDto)
        {
            if (id != statesDto.id)
                throw new Exception("Erro!");

            var states = statesDto.To<State>();

            _db.Entry(states).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatesExists(id))
                    throw new Exception("Cliente não encontrado!");
                
                throw;
            }
        }

        /// <summary>
        /// Método responsável por adicionar um estado
        /// </summary>
        /// <param name="stateDto"></param>
        public void PostSate(StateDto stateDto)
        {
            var state = stateDto.To<State>();

            _db.States.Add(state);
            _db.SaveChanges();
        }

        /// <summary>
        /// Método responsável por deletar um estado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StateDto DeleteClient(long id)
        {
            State state = _db.States.Find(id);

            if (state == null)
                throw new Exception("Estado não encontrado!");

            _db.States.Remove(state);
            _db.SaveChanges();

            return state.To<StateDto>();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}