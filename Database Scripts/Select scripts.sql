/****** Script for SelectTopNRows command from SSMS  ******/


SELECT * FROM [SSA].[dbo].[User]

SELECT * FROM [SSA].[dbo].[Landlord]

SELECT * FROM [SSA].[dbo].[Property]
SELECT * FROM [SSA].[dbo].[PropertyAttribute]
SELECT * FROM [SSA].[dbo].[PropertyListing]
SELECT * FROM [SSA].[dbo].[PropertyListingAttribute]

SELECT * FROM [SSA].[dbo].[PropertyImage]

--DELETE FROM [SSA].[dbo].[PropertyImage]

SELECT * FROM [SSA].[dbo].[Tenant]

SELECT * FROM [SSA].[dbo].[TenantPreference]

SELECT * FROM [SSA].[dbo].[StudentProfile]

SELECT 
P.Name,
P.Address,
PL.ListingAmount,
PL.ListingDate,
PLA.IsSharingAllowed,
PLA.IsChildrenAllowed,
PLA.IsPetsAllowed,
PLA.IsParkingAvailable,
PLA.IsPartyingAllowed,
PLA.AllowedOccupantCount,
PLA.AvailableBedroomCount,
PLA.AvailableBathroomCount,
PT.Description,
FT.Description
FROM [SSA].[dbo].[Property] P
INNER JOIN [SSA].[dbo].[PropertyListing] PL ON PL.PropertyUID=P.UID  AND P.IsActive=1 AND PL.IsActive=1
INNER JOIN [SSA].[dbo].[PropertyListingAttribute] PLA ON PLA.PropertyListingUID=PL.UID AND PLA.IsActive=1
INNER JOIN [SSA].[dbo].[PropertyAttribute] PA ON PLA.PropertyAttributeUID=PA.UID AND PA.IsActive=1
INNER JOIN [SSA].[dbo].[PropertyType] PT ON PA.PropertyTypeUID=PT.UID
INNER JOIN [SSA].[dbo].[FurnishType] FT ON PA.FurnishTypeUID=FT.UID;
--delete from [SSA].[dbo].[Tenant]
