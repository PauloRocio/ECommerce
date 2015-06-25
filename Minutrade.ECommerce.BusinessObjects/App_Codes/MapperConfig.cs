using AutoMapper;
using Minutrade.ECommerce.Dal;
using Minutrade.ECommerce.Dto;

namespace Minutrade.ECommerce.BusinessObjects.App_Codes
{
    /// <summary>
    /// Classe responsável pela configuração do mapeamento de conversão de objetos.
    /// </summary>
    public static class MapperConfig
    {
        /// <summary>
        /// Método responsável por inicializar o mapeamento.
        /// </summary>
        public static void InitMaps()
        {
            Mapper.CreateMap<ClientDto, Client>();
            Mapper.CreateMap<MaritalStatuDto, MaritalStatu>();
            Mapper.CreateMap<PhoneDto, Phone>();
            Mapper.CreateMap<StateDto, State>();
            Mapper.CreateMap<Client, ClientDto>();
            Mapper.CreateMap<MaritalStatu, MaritalStatuDto>();
            Mapper.CreateMap<Phone, PhoneDto>();
            Mapper.CreateMap<State, StateDto>();
        }
    }
}