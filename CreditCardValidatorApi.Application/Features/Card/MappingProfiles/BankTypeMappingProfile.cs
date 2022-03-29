using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using CreditCardValidatorApi.Application.Features.Card.Commands;
using CreditCardValidatorApi.Application.Features.Card.Dto;
using Model = CreditCardValidatorApi.Core.Entities;

namespace CreditCardValidatorApi.Application.Features.BankType.MappingProfiles
{
    public class BankTypeMappingProfile : Profile
    {
        public BankTypeMappingProfile()
        {
            CreateMap<CreateCardCommand, Model. Card>();
            CreateMap<Model.Card, CardDto>();
        }
    }
}
