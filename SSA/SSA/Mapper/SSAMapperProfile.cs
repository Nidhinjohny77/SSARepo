

using DataAccess.Entities;

namespace SSA.Mapper
{
    public class SSAMapperProfile:Profile
    {
        public SSAMapperProfile()
        {
            this.CreateMap<Role, RoleModel>()
                .ForMember(x => x.UID, opt => opt.Ignore())
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name));
            this.CreateMap<User, UserModel>()
                .ForMember(x => x.UID, opt => opt.Ignore())
                .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(x => x.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(x=>x.Role,opt=>opt.MapFrom(src=>src.Role));

        }
    }
}
