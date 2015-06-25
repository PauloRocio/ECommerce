using System;
using AutoMapper;

namespace Minutrade.ECommerce.BusinessObjects.App_Codes
{
    public static class MapExtensions
    {
        public static T To<T>(this Object from)
        {
            return Mapper.Map<T>(from);
        }
    }
}