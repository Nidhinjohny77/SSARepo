

using DataAccess.Entities;
using System.Globalization;

namespace SSA.Mapper
{
    public class SSAMapperProfile:Profile
    {
        public SSAMapperProfile()
        {
            this.CreateMap<Currency, CurrencyModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            this.CreateMap<CurrencyModel, Currency>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            this.CreateMap<ItemType, ItemTypeModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            this.CreateMap<ItemTypeModel, ItemType>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            this.CreateMap<Item, ItemModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ItemType, opt => opt.MapFrom(src => src.ItemType));
            this.CreateMap<ItemModel, Item>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ItemType, opt => opt.MapFrom(src => src.ItemType));

            this.CreateMap<FurnishType, FurnishTypeModel>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            this.CreateMap<FurnishTypeModel, FurnishType>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            this.CreateMap<PropertyType, PropertyTypeModel>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            this.CreateMap<PropertyTypeModel, PropertyType>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            this.CreateMap<TenancyType, TenancyTypeModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            this.CreateMap<TenancyTypeModel, TenancyType>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            this.CreateMap<Role, RoleModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            this.CreateMap<RoleModel, Role>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            this.CreateMap<Country, CountryModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(dest => dest.Currency));
            this.CreateMap<Country, CountryModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(dest => dest.Currency));

            this.CreateMap<University, UniversityModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.UniversityCode, opt => opt.MapFrom(src => src.UniversityCode))
                .ForMember(dest => dest.ContactNumber, opt => opt.MapFrom(src => src.ContactNumber))
                .ForMember(dest => dest.ContactEmail, opt => opt.MapFrom(src => src.ContactEmail))
                .ForMember(dest => dest.CountryUID, opt => opt.MapFrom(src => src.CountryUID))
                .ForMember(dest => dest.Ratings, opt => opt.MapFrom(src => src.Ratings));
            this.CreateMap<UniversityModel, University>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.UniversityCode, opt => opt.MapFrom(src => src.UniversityCode))
                .ForMember(dest => dest.ContactNumber, opt => opt.MapFrom(src => src.ContactNumber))
                .ForMember(dest => dest.ContactEmail, opt => opt.MapFrom(src => src.ContactEmail))
                .ForMember(dest => dest.CountryUID, opt => opt.MapFrom(src => src.CountryUID))
                .ForMember(dest => dest.Ratings, opt => opt.MapFrom(src => src.Ratings));

            this.CreateMap<User, UserModel>().ReverseMap()
                .ForMember(x => x.UID, opt => opt.MapFrom(src=>src.UID))
                .ForMember(x => x.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(x => x.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(x=>x.UserType,opt => opt.Ignore())
                .ForMember(x=>x.CreatedBy,opt=>opt.Ignore())
                .ForMember(x => x.CreatedDate, opt => opt.Ignore())
                .ForMember(x => x.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(x => x.RoleUID, opt => opt.Ignore())
                .ForMember(x=>x.Role, opt => opt.Ignore());
            this.CreateMap<Tenant, TenantModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.UserUID, opt => opt.MapFrom(src => src.UserUID))
                .ForMember(dest => dest.TenancyTypeUID, opt => opt.MapFrom(src => src.TenancyTypeUID))
                .ForMember(dest => dest.CountryUID, opt => opt.MapFrom(src => src.CountryUID))
                .ForMember(dest => dest.DOB, opt => opt.MapFrom(src => src.DOB.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
            this.CreateMap<TenantModel, Tenant>()
                .ForMember(dest => dest.UserUID, opt => opt.MapFrom(src => src.UserUID))
                .ForMember(dest => dest.TenancyTypeUID, opt => opt.MapFrom(src => src.TenancyTypeUID))
                .ForMember(dest => dest.CountryUID, opt => opt.MapFrom(src => src.CountryUID))
                .ForMember(dest => dest.DOB, opt => opt.MapFrom(src => Convert.ToDateTime(src.DOB)))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
            this.CreateMap<TenantPreference, TenantPreferenceModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.PropertyTypeUID, opt => opt.MapFrom(src => src.PropertyTypeUID))
                .ForMember(dest => dest.FurnishTypeUID, opt => opt.MapFrom(src => src.FurnishTypeUID))
                .ForMember(dest => dest.PreferedBathRoomCount, opt => opt.MapFrom(src => src.PreferedBathRoomCount))
                .ForMember(dest => dest.PreferedBathRoomCount, opt => opt.MapFrom(src => src.PreferedBathRoomCount))
                .ForMember(dest => dest.PreferedBedRoomCount, opt => opt.MapFrom(src => src.PreferedBedRoomCount))
                .ForMember(dest => dest.PreferedTenancyTypeUID, opt => opt.MapFrom(src => src.PreferedTenancyTypeUID))
                .ForMember(dest => dest.PreferedOccupantCount, opt => opt.MapFrom(src => src.PreferedOccupantCount))
                .ForMember(dest => dest.IsSharingPrefered, opt => opt.MapFrom(src => src.IsSharingPrefered))
                .ForMember(dest => dest.IsAttachedBathroomPrefered, opt => opt.MapFrom(src => src.IsAttachedBathroomPrefered))
                .ForMember(dest => dest.IsRentIncludingBillsPrefered, opt => opt.MapFrom(src => src.IsRentIncludingBillsPrefered))
                .ForMember(dest => dest.PreferedTenancyPeriodInMonths, opt => opt.MapFrom(src => src.PreferedTenancyPeriod))
                .ForMember(dest => dest.PreferedLocations, opt => opt.MapFrom(src => src.PreferedLocations.Split("|",StringSplitOptions.RemoveEmptyEntries).ToArray()))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.StartRangeAmount, opt => opt.MapFrom(src => src.StartRangeAmount))
                .ForMember(dest => dest.EndRangeAmount, opt => opt.MapFrom(src => src.EndRangeAmount));
            this.CreateMap<TenantPreferenceModel, TenantPreference>()
                .ForMember(dest => dest.PropertyTypeUID, opt => opt.MapFrom(src => src.PropertyTypeUID))
                .ForMember(dest => dest.FurnishTypeUID, opt => opt.MapFrom(src => src.FurnishTypeUID))
                .ForMember(dest => dest.PreferedBathRoomCount, opt => opt.MapFrom(src => src.PreferedBathRoomCount))
                .ForMember(dest => dest.PreferedBathRoomCount, opt => opt.MapFrom(src => src.PreferedBathRoomCount))
                .ForMember(dest => dest.PreferedBedRoomCount, opt => opt.MapFrom(src => src.PreferedBedRoomCount))
                .ForMember(dest => dest.PreferedTenancyTypeUID, opt => opt.MapFrom(src => src.PreferedTenancyTypeUID))
                .ForMember(dest => dest.PreferedOccupantCount, opt => opt.MapFrom(src => src.PreferedOccupantCount))
                .ForMember(dest => dest.IsSharingPrefered, opt => opt.MapFrom(src => src.IsSharingPrefered))
                .ForMember(dest => dest.IsAttachedBathroomPrefered, opt => opt.MapFrom(src => src.IsAttachedBathroomPrefered))
                .ForMember(dest => dest.IsRentIncludingBillsPrefered, opt => opt.MapFrom(src => src.IsRentIncludingBillsPrefered))
                .ForMember(dest => dest.PreferedTenancyPeriod, opt => opt.MapFrom(src => src.PreferedTenancyPeriodInMonths))
                .ForMember(dest => dest.PreferedLocations, opt => opt.MapFrom(src => string.Join("|", src.PreferedLocations)))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.StartRangeAmount, opt => opt.MapFrom(src => src.StartRangeAmount))
                .ForMember(dest => dest.EndRangeAmount, opt => opt.MapFrom(src => src.EndRangeAmount));
            this.CreateMap<StudentProfile, StudentProfileModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.TenantUID, opt => opt.MapFrom(src => src.TenantUID))
                .ForMember(dest => dest.StudentSecurityCode, opt => opt.MapFrom(src => src.StudentSecurityCode))
                .ForMember(dest => dest.CourseStartDate, opt => opt.MapFrom(src => src.CourseStartDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.CourseEndDate, opt => opt.MapFrom(src => src.CourseEndDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.UniversityStudentID, opt => opt.MapFrom(src => src.UniversityStudentID))
                .ForMember(dest => dest.EnrolledCourseName, opt => opt.MapFrom(src => src.EnrolledCourseName))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.UniversityUID, opt => opt.MapFrom(src => src.UniversityUID));
            this.CreateMap<StudentProfileModel, StudentProfile>()
                .ForMember(dest => dest.TenantUID, opt => opt.MapFrom(src => src.TenantUID))
                .ForMember(dest => dest.StudentSecurityCode, opt => opt.MapFrom(src => src.StudentSecurityCode))
                .ForMember(dest => dest.CourseStartDate, opt => opt.MapFrom(src => Convert.ToDateTime(src.CourseStartDate)))
                .ForMember(dest => dest.CourseEndDate, opt => opt.MapFrom(src => Convert.ToDateTime(src.CourseEndDate)))
                .ForMember(dest => dest.UniversityStudentID, opt => opt.MapFrom(src => src.UniversityStudentID))
                .ForMember(dest => dest.EnrolledCourseName, opt => opt.MapFrom(src => src.EnrolledCourseName))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.UniversityUID, opt => opt.MapFrom(src => src.UniversityUID));
            this.CreateMap<Landlord, LandlordModel>().ReverseMap()
                .ForMember(x => x.UserUID, opt => opt.MapFrom(src => src.UserUID))
                .ForMember(x => x.ProfileUID, opt => opt.MapFrom(src => src.ProfileUID))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(x => x.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(x => x.CountryCode, opt => opt.MapFrom(src => src.CountryCode))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(x => x.DOB, opt => opt.MapFrom(src => src.DOB));
            this.CreateMap<Property, PropertyModel>().ReverseMap()
                .ForMember(x=>x.UID, opt => opt.Ignore())
                .ForMember(x=>x.LandlordProfileUID,opt => opt.MapFrom(src => src.LandlordProfileUID))
                .ForMember(x=>x.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(x=>x.Address,opt => opt.MapFrom(src => src.Address))
                .ForMember(x=>x.IsActive,opt => opt.MapFrom(src => src.IsActive));
            this.CreateMap<PropertyAttribute, PropertyAttributeModel>().ReverseMap()
                .ForMember(x => x.UID, opt => opt.Ignore())
                .ForMember(x => x.PropertyUID, opt => opt.MapFrom(src => src.PropertyUID))
                .ForMember(x => x.PropertyTypeUID, opt => opt.MapFrom(src => src.PropertyTypeUID))
                .ForMember(x => x.FurnishTypeUID, opt => opt.MapFrom(src => src.FurnishTypeUID))
                .ForMember(x => x.BathroomCount, opt => opt.MapFrom(src => src.BathroomCount))
                .ForMember(x => x.BedroomCount, opt => opt.MapFrom(src => src.BedroomCount))
                .ForMember(x => x.FloorCount, opt => opt.MapFrom(src => src.FloorCount))
                .ForMember(x => x.IsBackyardAvailable, opt => opt.MapFrom(src => src.IsBackyardAvailable))
                .ForMember(x => x.IsGarageAvailable, opt => opt.MapFrom(src => src.IsGarageAvailable))
                .ForMember(x => x.IsParkingSlotAvailable, opt => opt.MapFrom(src => src.IsParkingSlotAvailable))
                .ForMember(x => x.TotalAreaInSqFT, opt => opt.MapFrom(src => src.TotalArea))
                .ForMember(x => x.ParkingSlotCount, opt => opt.MapFrom(src => src.ParkingSlotCount))
                .ForMember(x=>x.IsActive,opt=>opt.MapFrom(src=>src.IsActive));
            this.CreateMap<PropertyListing, PropertyListingModel>().ReverseMap()
                .ForMember(x => x.UID, opt => opt.Ignore())
                .ForMember(x => x.PropertyUID, opt => opt.MapFrom(src => src.PropertyUID))
                .ForMember(x => x.ListingDate, opt => opt.MapFrom(src => Convert.ToDateTime(src.ListingDate)))
                .ForMember(x => x.ListingAmount, opt => opt.MapFrom(src => src.ListingAmount))
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(x => x.Listedby, opt => opt.MapFrom(src => src.Listedby))
                .ForMember(x => x.ListingStatus, opt => opt.MapFrom(src => src.ListingStatus))
                .ForMember(x => x.IsCTIAvailableForSale, opt => opt.MapFrom(src => src.IsCTIAvailableForSale))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.IsActive));
            this.CreateMap<PropertyListingAttribute, PropertyListingAttributeModel>().ReverseMap()
                .ForMember(x => x.UID, opt => opt.Ignore())
                .ForMember(x => x.PropertyListingUID, opt => opt.MapFrom(src => src.PropertyListingUID))
                .ForMember(x => x.PropertyAttributeUID, opt => opt.MapFrom(src => src.PropertyAttributeUID))
                .ForMember(x => x.AvailableBedroomCount, opt => opt.MapFrom(src => src.AvailableBedroomCount))
                .ForMember(x => x.AvailableBathroomCount, opt => opt.MapFrom(src => src.AvailableBathroomCount))
                .ForMember(x => x.AllowedOccupantCount, opt => opt.MapFrom(src => src.AllowedOccupantCount))
                .ForMember(x => x.AvailableParkingSlots, opt => opt.MapFrom(src => src.AvailableParkingSlots))
                .ForMember(x => x.IsSharingAllowed, opt => opt.MapFrom(src => src.IsSharingAllowed))
                .ForMember(x => x.IsParkingAvailable, opt => opt.MapFrom(src => src.IsParkingAvailable))
                .ForMember(x => x.IsChildrenAllowed, opt => opt.MapFrom(src => src.IsChildrenAllowed))
                .ForMember(x => x.IsPartyingAllowed, opt => opt.MapFrom(src => src.IsPartyingAllowed))
                .ForMember(x => x.IsPetsAllowed, opt => opt.MapFrom(src => src.IsPetsAllowed))
                .ForMember(x => x.IsSmokingAllowed, opt => opt.MapFrom(src => src.IsSmokingAllowed))
                .ForMember(x => x.IsUnisex, opt => opt.MapFrom(src => src.IsUnisex))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(x => x.TenantTypeUID, opt => opt.MapFrom(src => src.TenantTypeUID));
            this.CreateMap<PropertyViewing, PropertyViewingModel>().ReverseMap()
                .ForMember(x => x.UID, opt => opt.Ignore())
                .ForMember(x => x.PropertyListingUID, opt => opt.MapFrom(src => src.PropertyListingUID))
                .ForMember(x => x.TenantUID, opt => opt.MapFrom(src => src.TenantUID))
                .ForMember(x => x.StartDateTime, opt => opt.MapFrom(src => src.StartDateTime))
                .ForMember(x => x.EndDateTime, opt => opt.MapFrom(src => src.EndDateTime))
                .ForMember(x => x.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.IsActive));
            this.CreateMap<PropertyRenting, PropertyRentingModel>().ReverseMap()
                .ForMember(x => x.UID, opt => opt.Ignore())
                .ForMember(x => x.PropertyListingUID, opt => opt.MapFrom(src => src.PropertyListingUID))
                .ForMember(x => x.TenantUID, opt => opt.MapFrom(src => src.TenantUID))
                .ForMember(x => x.RentAmount, opt => opt.MapFrom(src => src.RentAmount))
                .ForMember(x => x.AdvanceAmount, opt => opt.MapFrom(src => src.AdvanceAmount))
                .ForMember(x => x.RentPaymentFrequency, opt => opt.MapFrom(src => src.RentPaymentFrequency))
                .ForMember(x => x.RentStartDate, opt => opt.MapFrom(src => src.RentStartDate))
                .ForMember(x => x.RentEndDate, opt => opt.MapFrom(src => src.RentEndDate))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.IsActive));
            this.CreateMap<PropertyReview,PropertyReviewModel>().ReverseMap()
                .ForMember(x=>x.UID,opt=>opt.Ignore())
                .ForMember(x=>x.PropertyUID,opt=>opt.MapFrom(src=>src.PropertyUID))
                .ForMember(x=>x.ReviewerUID,opt=>opt.MapFrom(src=>src.ReviewerUID))
                .ForMember(x=>x.ReviewRating,opt=>opt.MapFrom(src=>src.ReviewRating))
                .ForMember(x=>x.ReviewDate,opt=>opt.MapFrom(src=>src.ReviewDate))
                .ForMember(x=>x.ReviewDescription,opt=>opt.MapFrom(src=>src.ReviewDescription));
        }
    }
}
