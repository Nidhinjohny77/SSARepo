/****** Script for SelectTopNRows command from SSMS  ******/


SELECT * FROM [dbo].[User]

SELECT * FROM [dbo].[Landlord]

SELECT * FROM [dbo].[Property] order by Name
SELECT * FROM [dbo].[PropertyAttribute]
SELECT * FROM [dbo].[PropertyListing]
SELECT * FROM [dbo].[PropertyListingAttribute]
SELECT * FROM [dbo].[PropertyImage] where PropertyUID='a37c1f36-4f04-427b-afab-076298bfd704' order by FileName
SELECT * FROM [dbo].[PropertyImage] where PropertyUID='77382e87-4ba7-431f-8044-9711d538354d' order by FileName
SELECT * FROM [dbo].[PropertyImage] where PropertyUID='4f20da6d-9a89-45ad-95fd-f79efec152b3' order by FileName
SELECT * FROM [dbo].[PropertyImage] where PropertyUID='a367c899-d1a0-42f2-9316-2380263960d2' order by FileName
SELECT * FROM [dbo].[PropertyImage] where PropertyUID='7af92e80-a6b5-47a4-b54a-bc8280e151bc' order by FileName



--DELETE FROM [dbo].[PropertyImage]
--UPDATE [dbo].[PropertyImage] set ImageTypeUID=1 where UID='93d45761-543a-47ad-84f4-3fd56212c662'
--UPDATE [dbo].[PropertyImage] set FileTypeUID=2 where UID='e4b99bb6-35a6-45e0-a639-c2121bb5e113'
--UPDATE [dbo].[FileType] set Name='jpg' where UID=1001

SELECT * FROM [dbo].[Tenant]

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
