using AutoMapper;

using Reimbursements.Business.DTOs;
using Reimbursements.DataAccess.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reimbursements.Business.Mappings
{
    public class DomainToDTOMapping : Profile
    {

        public DomainToDTOMapping()
        {
            CreateMap<ReimbursementsUser, UserDTO>().ForMember(u=> u.Full_name, opt => opt.MapFrom(x => x.UserName)).ReverseMap();
            CreateMap<Claim, ClaimDTO>().ReverseMap();
            CreateMap<Bank, BankDTO>().ReverseMap();
            CreateMap<ReimbursementType, ReimbursementTypeDTO>().ReverseMap();
            CreateMap<Currency, CurrencyDTO>().ReverseMap();
        }
    }
}
