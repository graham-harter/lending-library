using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LendingLibrary.Web.Models;
using LendingLibrary.Entities;

namespace LendingLibrary.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            // todo Do this in the recommended stylee.
            Mapper.CreateMap<Title, TitleViewModel>()
                .ForMember(vm => vm.Medium, map => map.MapFrom(m => m.Medium.Name))
                .ForMember(vm => vm.MediumId, map => map.MapFrom(m => m.Medium.ID))
                .ForMember(vm => vm.ImageURL, map => map.NullSubstitute(
                    "../../Content/images/NoImageAvailable.jpg"));

            Mapper.CreateMap<Medium, MediumViewModel>();
        }
    }
}
