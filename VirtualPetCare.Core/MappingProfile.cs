    using AutoMapper;
    using Mapster;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.PortableExecutable;
    using System.Text;
    using System.Threading.Tasks;
    using VirtualPetCare.Core.DTOs.Pet;
    using VirtualPetCare.Core.DTOs.User;
    using VirtualPetCareAPI.Entities;

    namespace VirtualPetCare.Core
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<PetCreateDto, Pet>().ReverseMap();
                CreateMap<UserCreateDto, User>().ReverseMap();



            }

        }
    }
