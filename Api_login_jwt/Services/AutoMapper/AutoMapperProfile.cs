using AutoMapper;
using Domain.DTO;
using Domain.Entity;
using Services.Request;

namespace Services.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddUsuarioRequest, Usuario>();
        CreateMap<AddRoleRequest, Role>();
        CreateMap<AddUsuarioRoleRequest, UsuarioRole>();
        CreateMap<Usuario, UsuarioDTO>()
            .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UsuarioRoles.Select(ur => ur.Role.UserRole).ToList()));
    } 
}