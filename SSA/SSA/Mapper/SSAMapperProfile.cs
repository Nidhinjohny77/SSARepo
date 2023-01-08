﻿

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

            this.CreateMap<ImageType, ImageTypeModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            this.CreateMap<ImageTypeModel, ImageType>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            this.CreateMap<FileType, FileTypeModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            this.CreateMap<FileTypeModel, FileType>()
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
                .ForMember(dest => dest.PreferedTenancyPeriodInMonths, opt => opt.MapFrom(src => src.PreferedTenancyPeriodInMonths))
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
                .ForMember(dest => dest.PreferedTenancyPeriodInMonths, opt => opt.MapFrom(src => src.PreferedTenancyPeriodInMonths))
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
            this.CreateMap<Landlord, LandlordModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.UserUID, opt => opt.MapFrom(src => src.UserUID))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.CountryUID, opt => opt.MapFrom(src => src.CountryUID))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.DOB, opt => opt.MapFrom(src => src.DOB.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));                
            this.CreateMap<LandlordModel, Landlord>()
                .ForMember(dest => dest.UID, opt => opt.Ignore())
                .ForMember(dest => dest.UserUID, opt => opt.MapFrom(src => src.UserUID))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.CountryUID, opt => opt.MapFrom(src => src.CountryUID))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.DOB, opt => opt.MapFrom(src => Convert.ToDateTime(src.DOB)));

            this.CreateMap<PropertyImage, PropertyImageModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.PropertyUID, opt => opt.MapFrom(src => src.PropertyUID))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.ImageTypeUID, opt => opt.MapFrom(src => src.ImageTypeUID))
                .ForMember(dest => dest.FileTypeUID, opt => opt.MapFrom(src => src.FileTypeUID))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
            this.CreateMap<PropertyImageModel, PropertyImage>()
                .ForMember(dest => dest.UID, opt => opt.Ignore())
                .ForMember(dest => dest.PropertyUID, opt => opt.MapFrom(src => src.PropertyUID))
                .ForMember(dest => dest.ImageTypeUID, opt => opt.MapFrom(src => src.ImageTypeUID))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.FileTypeUID, opt => opt.MapFrom(src => src.FileTypeUID))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));

            this.CreateMap<Property, PropertyModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.LandlordUID, opt => opt.MapFrom(src => src.LandlordUID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.PostCode, opt => opt.MapFrom(src => src.PostCode))
                .ForMember(dest => dest.CountryUID, opt => opt.MapFrom(src => src.CountryUID))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
            this.CreateMap<PropertyModel, Property>()
                .ForMember(dest => dest.UID, opt => opt.Ignore())
                .ForMember(dest => dest.LandlordUID,opt => opt.MapFrom(src => src.LandlordUID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.PostCode, opt => opt.MapFrom(src => src.PostCode))
                .ForMember(dest => dest.CountryUID, opt => opt.MapFrom(src => src.CountryUID))
                .ForMember(dest => dest.Address,opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.IsActive,opt => opt.MapFrom(src => src.IsActive));
            this.CreateMap<PropertyAttribute, PropertyAttributeModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.PropertyUID, opt => opt.MapFrom(src => src.PropertyUID))
                .ForMember(dest => dest.PropertyTypeUID, opt => opt.MapFrom(src => src.PropertyTypeUID))
                .ForMember(dest => dest.FurnishTypeUID, opt => opt.MapFrom(src => src.FurnishTypeUID))
                .ForMember(dest => dest.BathroomCount, opt => opt.MapFrom(src => src.BathroomCount))
                .ForMember(dest => dest.BedroomCount, opt => opt.MapFrom(src => src.BedroomCount))
                .ForMember(dest => dest.FloorCount, opt => opt.MapFrom(src => src.FloorCount))
                .ForMember(dest => dest.IsBackyardAvailable, opt => opt.MapFrom(src => src.IsBackyardAvailable))
                .ForMember(dest => dest.IsGarageAvailable, opt => opt.MapFrom(src => src.IsGarageAvailable))
                .ForMember(dest => dest.IsParkingSlotAvailable, opt => opt.MapFrom(src => src.IsParkingSlotAvailable))
                .ForMember(dest => dest.TotalAreaInSqFT, opt => opt.MapFrom(src => src.TotalAreaInSqFT))
                .ForMember(dest => dest.ParkingSlotCount, opt => opt.MapFrom(src => src.ParkingSlotCount))
                .ForMember(dest => dest.MaxOccupantCount, opt => opt.MapFrom(src => src.MaxOccupantCount))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
            this.CreateMap<PropertyAttributeModel, PropertyAttribute>()
                .ForMember(dest => dest.UID, opt => opt.Ignore())
                .ForMember(dest => dest.PropertyUID, opt => opt.MapFrom(src => src.PropertyUID))
                .ForMember(dest => dest.PropertyTypeUID, opt => opt.MapFrom(src => src.PropertyTypeUID))
                .ForMember(dest => dest.FurnishTypeUID, opt => opt.MapFrom(src => src.FurnishTypeUID))
                .ForMember(dest => dest.BathroomCount, opt => opt.MapFrom(src => src.BathroomCount))
                .ForMember(dest => dest.BedroomCount, opt => opt.MapFrom(src => src.BedroomCount))
                .ForMember(dest => dest.FloorCount, opt => opt.MapFrom(src => src.FloorCount))
                .ForMember(dest => dest.IsBackyardAvailable, opt => opt.MapFrom(src => src.IsBackyardAvailable))
                .ForMember(dest => dest.IsGarageAvailable, opt => opt.MapFrom(src => src.IsGarageAvailable))
                .ForMember(dest => dest.IsParkingSlotAvailable, opt => opt.MapFrom(src => src.IsParkingSlotAvailable))
                .ForMember(dest => dest.TotalAreaInSqFT, opt => opt.MapFrom(src => src.TotalAreaInSqFT))
                .ForMember(dest => dest.ParkingSlotCount, opt => opt.MapFrom(src => src.ParkingSlotCount))
                .ForMember(dest => dest.MaxOccupantCount, opt => opt.MapFrom(src => src.MaxOccupantCount))
                .ForMember(dest => dest.IsActive,opt=>opt.MapFrom(src=>src.IsActive));
            this.CreateMap<PropertyListing, PropertyListingModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.PropertyUID, opt => opt.MapFrom(src => src.PropertyUID))
                .ForMember(dest => dest.ListingDate, opt => opt.MapFrom(src => src.ListingDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.ListingAmount, opt => opt.MapFrom(src => src.ListingAmount))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsCTIAvailableForSale, opt => opt.MapFrom(src => src.IsCTIAvailableForSale))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
            this.CreateMap<PropertyListingModel, PropertyListing>()
                .ForMember(dest => dest.UID, opt => opt.Ignore())
                .ForMember(dest => dest.PropertyUID, opt => opt.MapFrom(src => src.PropertyUID))
                .ForMember(dest => dest.ListingDate, opt => opt.MapFrom(src => Convert.ToDateTime(src.ListingDate)))
                .ForMember(dest => dest.ListingAmount, opt => opt.MapFrom(src => src.ListingAmount))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsCTIAvailableForSale, opt => opt.MapFrom(src => src.IsCTIAvailableForSale))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
            this.CreateMap<PropertyListingAttribute, PropertyListingAttributeModel>()
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.PropertyListingUID, opt => opt.MapFrom(src => src.PropertyListingUID))
                .ForMember(dest => dest.PropertyAttributeUID, opt => opt.MapFrom(src => src.PropertyAttributeUID))
                .ForMember(dest => dest.AvailableBedroomCount, opt => opt.MapFrom(src => src.AvailableBedroomCount))
                .ForMember(dest => dest.AvailableBathroomCount, opt => opt.MapFrom(src => src.AvailableBathroomCount))
                .ForMember(dest => dest.AllowedOccupantCount, opt => opt.MapFrom(src => src.AllowedOccupantCount))
                .ForMember(dest => dest.AvailableParkingSlots, opt => opt.MapFrom(src => src.AvailableParkingSlots))
                .ForMember(dest => dest.IsSharingAllowed, opt => opt.MapFrom(src => src.IsSharingAllowed))
                .ForMember(dest => dest.IsParkingAvailable, opt => opt.MapFrom(src => src.IsParkingAvailable))
                .ForMember(dest => dest.IsChildrenAllowed, opt => opt.MapFrom(src => src.IsChildrenAllowed))
                .ForMember(dest => dest.IsPartyingAllowed, opt => opt.MapFrom(src => src.IsPartyingAllowed))
                .ForMember(dest => dest.IsPetsAllowed, opt => opt.MapFrom(src => src.IsPetsAllowed))
                .ForMember(dest => dest.IsSmokingAllowed, opt => opt.MapFrom(src => src.IsSmokingAllowed))
                .ForMember(dest => dest.IsUnisex, opt => opt.MapFrom(src => src.IsUnisex))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.TenancyTypeUID, opt => opt.MapFrom(src => src.TenancyTypeUID));
            this.CreateMap<PropertyListingAttributeModel, PropertyListingAttribute>()
                .ForMember(dest => dest.UID, opt => opt.Ignore())
                .ForMember(dest => dest.PropertyListingUID, opt => opt.MapFrom(src => src.PropertyListingUID))
                .ForMember(dest => dest.PropertyAttributeUID, opt => opt.MapFrom(src => src.PropertyAttributeUID))
                .ForMember(dest => dest.AvailableBedroomCount, opt => opt.MapFrom(src => src.AvailableBedroomCount))
                .ForMember(dest => dest.AvailableBathroomCount, opt => opt.MapFrom(src => src.AvailableBathroomCount))
                .ForMember(dest => dest.AllowedOccupantCount, opt => opt.MapFrom(src => src.AllowedOccupantCount))
                .ForMember(dest => dest.AvailableParkingSlots, opt => opt.MapFrom(src => src.AvailableParkingSlots))
                .ForMember(dest => dest.IsSharingAllowed, opt => opt.MapFrom(src => src.IsSharingAllowed))
                .ForMember(dest => dest.IsParkingAvailable, opt => opt.MapFrom(src => src.IsParkingAvailable))
                .ForMember(dest => dest.IsChildrenAllowed, opt => opt.MapFrom(src => src.IsChildrenAllowed))
                .ForMember(dest => dest.IsPartyingAllowed, opt => opt.MapFrom(src => src.IsPartyingAllowed))
                .ForMember(dest => dest.IsPetsAllowed, opt => opt.MapFrom(src => src.IsPetsAllowed))
                .ForMember(dest => dest.IsSmokingAllowed, opt => opt.MapFrom(src => src.IsSmokingAllowed))
                .ForMember(dest => dest.IsUnisex, opt => opt.MapFrom(src => src.IsUnisex))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.TenancyTypeUID, opt => opt.MapFrom(src => src.TenancyTypeUID));
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

            this.CreateMap<PropertyListing, PropertyDataModel>()
                .ForMember(dest => dest.PropertyListingUID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.PropertyUID, opt => opt.MapFrom(src => src.PropertyUID))
                .ForMember(dest => dest.AvailableDate, opt => opt.MapFrom(src => src.ListingDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.ListingAmount))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.BedRoomCount, opt => opt.MapFrom(src => src.PropertyListingAttribute.AvailableBedroomCount))
                .ForMember(dest => dest.BathRoomCount, opt => opt.MapFrom(src => src.PropertyListingAttribute.AvailableBathroomCount))
                .ForMember(dest => dest.IsParkingAvailable, opt => opt.MapFrom(src => src.PropertyListingAttribute.IsParkingAvailable))
                .ForMember(dest => dest.IsPetsAllowed, opt => opt.MapFrom(src => src.PropertyListingAttribute.IsPetsAllowed))
                .ForMember(dest => dest.AvailableParkingSlots, opt => opt.MapFrom(src => src.PropertyListingAttribute.AvailableParkingSlots))
                .ForMember(dest => dest.IsPartyingAllowed, opt => opt.MapFrom(src => src.PropertyListingAttribute.IsPartyingAllowed))
                .ForMember(dest => dest.IsSmokingAllowed, opt => opt.MapFrom(src => src.PropertyListingAttribute.IsSmokingAllowed))
                .ForMember(dest => dest.AllowedOccupantCount, opt => opt.MapFrom(src => src.PropertyListingAttribute.AllowedOccupantCount))
                .ForMember(dest => dest.ThumbNailImageData, opt => opt.MapFrom(src => src.Property.Images.FirstOrDefault(x=>x.ImageTypeUID==1)))
                .ForMember(dest => dest.IsSharingAllowed, opt => opt.MapFrom(src => src.PropertyListingAttribute.IsSharingAllowed));
        }
    }
}
