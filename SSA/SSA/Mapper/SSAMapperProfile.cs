﻿

using DataAccess.Entities;

namespace SSA.Mapper
{
    public class SSAMapperProfile:Profile
    {
        public SSAMapperProfile()
        {
            this.CreateMap<Currency, CurrencyModel>()
                .ForMember(x => x.Code, opt => opt.MapFrom(dest => dest.Code))
                .ForMember(x => x.Name, opt => opt.MapFrom(dest => dest.Name));
            this.CreateMap<ItemType, ItemTypeModel>()
                .ForMember(x => x.UID, opt => opt.MapFrom(dest => dest.UID))
                .ForMember(x => x.Name, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(dest => dest.Description));
            this.CreateMap<Item, ItemModel>()
                .ForMember(x => x.UID, opt => opt.MapFrom(dest => dest.UID))
                .ForMember(x => x.Name, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(x => x.ItemType, opt => opt.MapFrom(dest => dest.ItemType));
            this.CreateMap<FurnishType, FurnishTypeModel>().ReverseMap()
                .ForMember(x => x.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(x => x.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Description));
            this.CreateMap<PropertyType, PropertyTypeModel>().ReverseMap()
                .ForMember(x => x.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(x => x.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Description));
            this.CreateMap<TenancyType, TenancyTypeModel>().ReverseMap()
                .ForMember(x => x.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Description));
            this.CreateMap<Role, RoleModel>().ReverseMap()
                .ForMember(x => x.UID, opt => opt.Ignore())
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name));
            this.CreateMap<Country, CountryModel>().ReverseMap()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(x => x.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(x => x.CurrencyUID, opt => opt.MapFrom(dest => dest.Currency.UID));
            this.CreateMap<University, UniversityModel>().ReverseMap()
                .ForMember(x => x.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(x => x.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(x => x.UniversityCode, opt => opt.MapFrom(src => src.UniversityCode))
                .ForMember(x => x.ContactNumber, opt => opt.MapFrom(src => src.ContactNumber))
                .ForMember(x => x.ContactEmail, opt => opt.MapFrom(src => src.ContactEmail))
                .ForMember(x => x.CountryUID, opt => opt.Ignore())
                .ForMember(x => x.Ratings, opt => opt.MapFrom(src => src.Ratings));

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
            this.CreateMap<Tenant, TenantModel>().ReverseMap()
                .ForMember(x => x.DOB, opt => opt.MapFrom(src => Convert.ToDateTime(src.DOB)))
                .ForMember(x => x.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.IsActive));
            this.CreateMap<TenantPreference, TenantPreferenceModel>().ReverseMap()
                .ForMember(x => x.PropertyTypeUID, opt => opt.MapFrom(src => src.PropertyTypeUID))
                .ForMember(x => x.FurnishTypeUID, opt => opt.MapFrom(src => src.FurnishTypeUID))
                .ForMember(x => x.PreferedBathRoomCount, opt => opt.MapFrom(src => src.PreferedBathRoomCount))
                .ForMember(x => x.PreferedBathRoomCount, opt => opt.MapFrom(src => src.PreferedBathRoomCount))
                .ForMember(x => x.PreferedBedRoomCount, opt => opt.MapFrom(src => src.PreferedBedRoomCount))
                .ForMember(x => x.PreferedTenancyTypeUID, opt => opt.MapFrom(src => src.PreferedTenancyTypeUID))
                .ForMember(x => x.PreferedOccupantCount, opt => opt.MapFrom(src => src.PreferedOccupantCount))
                .ForMember(x => x.IsSharingPrefered, opt => opt.MapFrom(src => src.IsSharingPrefered))
                .ForMember(x => x.IsAttachedBathroomPrefered, opt => opt.MapFrom(src => src.IsAttachedBathroomPrefered))
                .ForMember(x => x.IsRentIncludingBillsPrefered, opt => opt.MapFrom(src => src.IsRentIncludingBillsPrefered))
                .ForMember(x => x.PreferedTenancyPeriod, opt => opt.MapFrom(src => src.PreferedTenancyPeriod))
                .ForMember(x => x.PreferedLocations, opt => opt.MapFrom(src => string.Join("|",src.PreferedLocations)))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(x => x.StartRangeAmount, opt => opt.MapFrom(src => src.StartRangeAmount))
                .ForMember(x => x.EndRangeAmount, opt => opt.MapFrom(src => src.EndRangeAmount));
            this.CreateMap<StudentProfile, StudentProfileModel>().ReverseMap()
                .ForMember(x => x.TenantUID, opt => opt.Ignore())
                .ForMember(x => x.StudentSecurityCode, opt => opt.MapFrom(src => src.StudentSecurityCode))
                .ForMember(x => x.CourseStartDate, opt => opt.MapFrom(src => Convert.ToDateTime(src.CourseStartDate)))
                .ForMember(x => x.CourseEndDate, opt => opt.MapFrom(src => Convert.ToDateTime(src.CourseEndDate)))
                .ForMember(x => x.UniversityStudentID, opt => opt.MapFrom(src => src.UniversityStudentID))
                .ForMember(x => x.EnrolledCourseName, opt => opt.MapFrom(src => src.EnrolledCourseName))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(x => x.UniversityUID, opt => opt.Ignore());
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
