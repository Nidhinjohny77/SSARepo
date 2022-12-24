

using DataAccess.Entities;

namespace SSA.Mapper
{
    public class SSAMapperProfile:Profile
    {
        public SSAMapperProfile()
        {
            this.CreateMap<Role, RoleModel>().ReverseMap()
                .ForMember(x => x.UID, opt => opt.Ignore())
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name));
            this.CreateMap<User, UserModel>().ReverseMap()
                .ForMember(x => x.UID, opt => opt.MapFrom(src=>src.UID))
                .ForMember(x => x.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(x => x.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(x=>x.UserType,opt => opt.Ignore())
                .ForMember(x=>x.CreatedBy,opt=>opt.Ignore())
                .ForMember(x => x.CreatedDate, opt => opt.Ignore())
                .ForMember(x => x.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(x => x.RoleUID, opt => opt.Ignore())
                .ForMember(x=>x.Role, opt => opt.Ignore());
            this.CreateMap<University, UniversityModel>().ReverseMap()
                .ForMember(x => x.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(x => x.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(x => x.UniversityCode, opt => opt.MapFrom(src => src.UniversityCode))
                .ForMember(x => x.ContactNumber, opt => opt.MapFrom(src => src.ContactNumber))
                .ForMember(x => x.ContactEmail, opt => opt.MapFrom(src => src.ContactEmail))
                .ForMember(x => x.CountryCode, opt => opt.MapFrom(src => src.CountryCode))
                .ForMember(x => x.Ratings, opt => opt.MapFrom(src => src.Ratings));
            this.CreateMap<Student, StudentModel>().ReverseMap()
                .ForMember(x => x.UserUID, opt => opt.MapFrom(src => src.UserUID))
                .ForMember(x => x.ProfileUID, opt => opt.MapFrom(src => src.ProfileUID))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(x => x.CourseStartDate, opt => opt.MapFrom(src => Convert.ToDateTime(src.CourseStartDate)))
                .ForMember(x => x.CourseEndDate, opt => opt.MapFrom(src => Convert.ToDateTime(src.CourseEndDate)))
                .ForMember(x => x.StudentId, opt => opt.MapFrom(src => src.StudentID))
                .ForMember(x => x.StudentCode, opt => opt.MapFrom(src => src.StudentCode))
                .ForMember(x => x.EnrolledCourseName, opt => opt.MapFrom(src => src.EnrolledCourseName))
                .ForMember(x => x.DOB, opt => opt.MapFrom(src => src.DOB))
                .ForMember(x => x.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(x => x.CountryCode, opt => opt.MapFrom(src => src.CountryCode))
                .ForMember(x => x.ContinentCode, opt => opt.MapFrom(src => src.ContinentCode))
                .ForMember(x => x.UniversityUID, opt => opt.Ignore());
            this.CreateMap<Landlord, LandlordModel>().ReverseMap()
                .ForMember(x => x.UserUID, opt => opt.MapFrom(src => src.UserUID))
                .ForMember(x => x.ProfileUID, opt => opt.MapFrom(src => src.ProfileUID))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(x => x.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(x => x.CountryCode, opt => opt.MapFrom(src => src.CountryCode))
                .ForMember(x => x.DOB, opt => opt.MapFrom(src => src.DOB));
        }
    }
}
