using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BoardGameDesigner.Model.Components;
using BoardGameDesigner.ViewModel;

namespace BoardGameDesigner.BusinessLayer.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration ConfigureMappings()
        {
            return new MapperConfiguration(cfg => { cfg.CreateMap<Card, CardViewModel>()
                .ForMember(x => x.CardId, x => x.MapFrom(src => src.Id)); });
        }
    }
}
