USE [testBooking]
GO
/****** Object:  Table [dbo].[abouts]    Script Date: 2/11/2025 10:02:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[abouts](
	[aboutId] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](max) NULL,
	[subject] [text] NULL,
	[orderId] [int] NULL,
	[languageId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[additionalActivities]    Script Date: 2/11/2025 10:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[additionalActivities](
	[additionalActivityId] [int] IDENTITY(1,1) NOT NULL,
	[title] [text] NULL,
	[adultPrice] [decimal](18, 2) NULL,
	[childPrice] [decimal](18, 2) NULL,
	[infantPrice] [decimal](18, 2) NULL,
	[languageId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[additionalInformations]    Script Date: 2/11/2025 10:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[additionalInformations](
	[additionalInfoId] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](200) NULL,
	[details] [nvarchar](max) NULL,
	[tourId] [decimal](18, 0) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[blockedDates]    Script Date: 2/11/2025 10:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[blockedDates](
	[blockedDatesID] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[date] [nvarchar](50) NULL,
	[tourId] [int] NULL,
	[isPublic] [nvarchar](2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[blogs]    Script Date: 2/11/2025 10:02:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[blogs](
	[blogId] [int] IDENTITY(1,1) NOT NULL,
	[seoTitle] [nvarchar](500) NULL,
	[seoDescription] [nvarchar](500) NULL,
	[seokeyWords] [nvarchar](500) NULL,
	[viewport] [nvarchar](500) NULL,
	[title] [nvarchar](500) NULL,
	[description] [text] NULL,
	[languageId] [int] NULL,
	[creationDate] [datetime] NULL,
	[isActive] [nvarchar](1) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bookAdditionalActivities]    Script Date: 2/11/2025 10:02:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bookAdditionalActivities](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bookId] [decimal](18, 0) NULL,
	[tourActivityId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[booking]    Script Date: 2/11/2025 10:02:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[booking](
	[requestId] [decimal](18, 0) IDENTITY(1000,1) NOT NULL,
	[tourId] [decimal](18, 0) NULL,
	[phone] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL,
	[name] [nvarchar](100) NULL,
	[countryName] [nvarchar](50) NULL,
	[tourDate] [datetime] NULL,
	[numberOfAdult] [int] NULL,
	[numberOfChild] [int] NULL,
	[numberOfInfant] [int] NULL,
	[pickup] [nvarchar](max) NULL,
	[status] [nvarchar](50) NULL,
	[numberOfRoom] [int] NULL,
	[languageName] [nvarchar](100) NULL,
	[totalPrice] [decimal](18, 2) NULL,
	[sessionReference] [nvarchar](200) NULL,
	[paymentErrorDesc] [text] NULL,
	[roomType] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contacts]    Script Date: 2/11/2025 10:02:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contacts](
	[contactId] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NULL,
	[email] [nvarchar](200) NULL,
	[phone] [nvarchar](100) NULL,
	[message] [nvarchar](max) NULL,
	[NumberOfAdult] [int] NULL,
	[NumberOfChild] [int] NULL,
	[numberOfInfant] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[countries]    Script Date: 2/11/2025 10:02:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[countries](
	[countyId] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[countryName] [nvarchar](100) NULL,
	[creationDate] [date] NULL,
	[createdBy] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[currency]    Script Date: 2/11/2025 10:02:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[currency](
	[currencyName] [nvarchar](50) NULL,
	[currencyId] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[currencyCode] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[days]    Script Date: 2/11/2025 10:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[days](
	[dayId] [int] NOT NULL,
	[dayName] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[excludes]    Script Date: 2/11/2025 10:02:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[excludes](
	[excludeId] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[excludeText] [nvarchar](max) NULL,
	[tourId] [decimal](18, 0) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[expects]    Script Date: 2/11/2025 10:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[expects](
	[expectId] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](200) NULL,
	[details] [nvarchar](max) NULL,
	[tourId] [decimal](18, 0) NULL,
	[order] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[facebookTokens]    Script Date: 2/11/2025 10:02:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[facebookTokens](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[appId] [nvarchar](100) NULL,
	[appSecret] [nvarchar](200) NULL,
	[shortToken] [text] NULL,
	[longToken] [text] NULL,
	[expiryDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[facilities]    Script Date: 2/11/2025 10:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[facilities](
	[facilitiesId] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](500) NULL,
	[description] [text] NULL,
	[imagePath] [nvarchar](500) NULL,
	[orderId] [int] NULL,
	[languageId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[faqs]    Script Date: 2/11/2025 10:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[faqs](
	[faqId] [int] IDENTITY(1,1) NOT NULL,
	[question] [nvarchar](max) NOT NULL,
	[answer] [text] NOT NULL,
	[orderId] [int] NULL,
	[languageId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hotelRoomPricing]    Script Date: 2/11/2025 10:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hotelRoomPricing](
	[hotelRoomId] [int] IDENTITY(1,1) NOT NULL,
	[roomTypeId] [int] NULL,
	[price] [decimal](18, 2) NULL,
	[numberOfAdult] [int] NULL,
	[numberOfChild] [int] NULL,
	[numberOfInfant] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hotelType]    Script Date: 2/11/2025 10:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hotelType](
	[hotelTypeId] [int] IDENTITY(1,1) NOT NULL,
	[hotelTypeName] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[includes]    Script Date: 2/11/2025 10:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[includes](
	[includeId] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[includeText] [nvarchar](max) NULL,
	[tourId] [decimal](18, 0) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[languages]    Script Date: 2/11/2025 10:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[languages](
	[languageId] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[languageName] [nvarchar](100) NULL,
	[creationDate] [date] NULL,
	[createdBy] [nvarchar](100) NULL,
	[code] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[localizations]    Script Date: 2/11/2025 10:02:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[localizations](
	[localizeId] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[parentLocalizeId] [decimal](18, 0) NULL,
	[languageId] [decimal](18, 0) NULL,
	[keyName] [nvarchar](100) NULL,
	[value] [nvarchar](1000) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[packs]    Script Date: 2/11/2025 10:02:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[packs](
	[packId] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](max) NULL,
	[tourId] [decimal](18, 0) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permissions]    Script Date: 2/11/2025 10:02:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permissions](
	[permissionId] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[permissionArea] [nvarchar](100) NULL,
	[permissionAction] [nvarchar](100) NULL,
	[isMenu] [nvarchar](50) NULL,
	[permissionName] [nvarchar](100) NULL,
	[icon] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rolePermissions]    Script Date: 2/11/2025 10:02:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rolePermissions](
	[rolePermissionsId] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[roleId] [decimal](18, 0) NULL,
	[permissionId] [decimal](18, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 2/11/2025 10:02:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[roleId] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[roleName] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roomType]    Script Date: 2/11/2025 10:02:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roomType](
	[roomTypeId] [int] IDENTITY(1,1) NOT NULL,
	[roomTypeName] [nvarchar](200) NULL,
	[icon] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seo]    Script Date: 2/11/2025 10:02:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seo](
	[seoId] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](500) NULL,
	[description] [nvarchar](500) NULL,
	[keyWords] [nvarchar](500) NULL,
	[viewport] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[settings]    Script Date: 2/11/2025 10:02:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[settings](
	[settingId] [int] IDENTITY(1,1) NOT NULL,
	[keyName] [nvarchar](50) NULL,
	[value] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[specialRequests]    Script Date: 2/11/2025 10:02:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[specialRequests](
	[specialRequestId] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](100) NULL,
	[phone] [nvarchar](100) NULL,
	[name] [nvarchar](200) NULL,
	[countryName] [nvarchar](200) NULL,
	[nights] [int] NULL,
	[arriveDate] [date] NULL,
	[leaveDate] [date] NULL,
	[message] [text] NULL,
	[numberOfAdult] [int] NULL,
	[numberOfChild] [int] NULL,
	[numberOfInfant] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[terms]    Script Date: 2/11/2025 10:02:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[terms](
	[termId] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](max) NULL,
	[subject] [text] NULL,
	[orderId] [int] NULL,
	[languageId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tourAdditionalActivities]    Script Date: 2/11/2025 10:02:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tourAdditionalActivities](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tourId] [int] NULL,
	[activityId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tourAttachments]    Script Date: 2/11/2025 10:02:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tourAttachments](
	[tourAttachmentId] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[attachmentPath] [nvarchar](max) NULL,
	[attachmentName] [nvarchar](max) NULL,
	[tourId] [decimal](18, 0) NULL,
	[isMainAttachment] [nvarchar](1) NULL,
	[type] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tourDays]    Script Date: 2/11/2025 10:02:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tourDays](
	[tourDayId] [int] IDENTITY(1,1) NOT NULL,
	[dayId] [int] NULL,
	[tourId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tourLanguages]    Script Date: 2/11/2025 10:02:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tourLanguages](
	[tourLanguageId] [int] IDENTITY(1,1) NOT NULL,
	[languageId] [int] NULL,
	[tourId] [int] NULL,
	[languageName] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tours]    Script Date: 2/11/2025 10:02:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tours](
	[tourId] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[duration] [nvarchar](50) NULL,
	[tourLocation] [nvarchar](max) NULL,
	[tourDays] [nvarchar](100) NULL,
	[pickupLocation] [nvarchar](max) NULL,
	[dropOff] [nvarchar](max) NULL,
	[tourType] [nvarchar](200) NULL,
	[overview] [text] NULL,
	[includeId] [decimal](18, 0) NULL,
	[exculdeId] [decimal](18, 0) NULL,
	[highlights] [nvarchar](max) NULL,
	[expectId] [decimal](18, 0) NULL,
	[packId] [decimal](18, 0) NULL,
	[adultPrice] [decimal](10, 2) NULL,
	[capacity] [decimal](10, 0) NULL,
	[title] [nvarchar](300) NULL,
	[childPrice] [decimal](18, 2) NULL,
	[infantPrice] [decimal](18, 2) NULL,
	[languageId] [int] NULL,
	[adultPriceForDouble] [decimal](18, 2) NULL,
	[adultPriceForSuite] [decimal](18, 2) NULL,
	[isActive] [nvarchar](1) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 2/11/2025 10:02:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[userId] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](100) NULL,
	[fullName] [nvarchar](100) NULL,
	[gender] [nvarchar](1) NULL,
	[status] [nvarchar](1) NULL,
	[createdby] [nvarchar](100) NULL,
	[creationDate] [date] NULL,
	[lastUpdateBy] [nvarchar](100) NULL,
	[lastUpdateDate] [date] NULL,
	[email] [nvarchar](100) NULL,
	[mobile] [nvarchar](100) NULL,
	[password] [nvarchar](100) NULL,
	[roleId] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[whyChooseUs]    Script Date: 2/11/2025 10:02:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[whyChooseUs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [text] NULL,
	[languageId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[abouts] ON 

INSERT [dbo].[abouts] ([aboutId], [title], [subject], [orderId], [languageId]) VALUES (2, N'Who we are', N'Our Dahabiya Nile cruise called (Anoush) which has 12 cabins and 4 suits. According to our experience in our field more than 10 years we built our Nile Dahabiya for our guests who demand the best. <br><br> Dahabyia Nile cruises is the most exclusive and luxurious way to experience the Egyptian river. <br><br> Sail into the past on Dahabiya Nile Cruise and travel the Nile like the pioneering voyagers aboard a traditional Dahabiya. <br><br> A Dahabiya Nile Cruise offers the romance of the past with modern comfort and convenience. It’s a leisurely way to get between Luxor and Aswan and brings together superb sightseeing, sailing, delicious traditional meals and attentive personal service. <br><br> Life on board a Dahabiya Nile cruise is peaceful and idyllic A day on board a traditional Dahabiya has many pleasures. You can lie in a deck chair, read a book or watch children playing and women doing their washing. Every day there is a chance to walk around villages, visit local markets or explore monuments along the Nile. <br><br> Enjoy our Dahabiya facilities,Meals,Drinks,Entertainment There’s nothing better than an evening dining under a twinkling night sky by the light of a campfire. You are far away from the fancy-dress parties of the large cruisers. You’ll find no flashing disco’s here, but it might be possible to attend a show by local musicians under the stars. <br><br> Welcome to (Anoush Dahabiy)', 1, 1)
SET IDENTITY_INSERT [dbo].[abouts] OFF
GO
SET IDENTITY_INSERT [dbo].[additionalActivities] ON 

INSERT [dbo].[additionalActivities] ([additionalActivityId], [title], [adultPrice], [childPrice], [infantPrice], [languageId]) VALUES (2, N'Nubian village', CAST(35.00 AS Decimal(18, 2)), NULL, NULL, 1)
INSERT [dbo].[additionalActivities] ([additionalActivityId], [title], [adultPrice], [childPrice], [infantPrice], [languageId]) VALUES (3, N'Hot air balloon', CAST(95.00 AS Decimal(18, 2)), NULL, NULL, 1)
INSERT [dbo].[additionalActivities] ([additionalActivityId], [title], [adultPrice], [childPrice], [infantPrice], [languageId]) VALUES (4, N'Abu Simbel excluding entrance fees', CAST(90.00 AS Decimal(18, 2)), NULL, NULL, 1)
INSERT [dbo].[additionalActivities] ([additionalActivityId], [title], [adultPrice], [childPrice], [infantPrice], [languageId]) VALUES (5, N'City cultural tour', CAST(30.00 AS Decimal(18, 2)), NULL, NULL, 1)
INSERT [dbo].[additionalActivities] ([additionalActivityId], [title], [adultPrice], [childPrice], [infantPrice], [languageId]) VALUES (6, N'Sound And Light show excluding entrance fees', CAST(25.00 AS Decimal(18, 2)), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[additionalActivities] OFF
GO
SET IDENTITY_INSERT [dbo].[additionalInformations] ON 

INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32757 AS Decimal(18, 0)), NULL, N'<br>
<br>
Cancellation policy :
<br>

you can cancel 5 days before the travel date and you will get full refund.

<br>

between 4 and 2 days before the travel date a fee of 30% of the total price.
<br>
less than 2 days before the travel date a fee of 50% of the total price.

<br>', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32818 AS Decimal(18, 0)), NULL, N'Children policy:
<br>
(Up to 2 years free of charge.)
<br>
(Age from 2 and below 5 years : 15% of adult price)

<br>
(Age from 5 up to 11 years : 50% of adult price )

<br>
(Ages 12 years and up : adult price)

<br>
<br>

Note:
<br>
 Child pricing applies to children who share rooms with their parents (max 1 children in each room)', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32819 AS Decimal(18, 0)), NULL, N'<br>
<br>
Cancellation policy :
<br>

you can cancel 5 days before the travel date and you will get full refund.

<br>

between 4 and 2 days before the travel date a fee of 30% of the total price.
<br>
less than 2 days before the travel date a fee of 50% of the total price.

<br>', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32820 AS Decimal(18, 0)), NULL, N'Prices are quoted in US Dollars per person per trip except during Christmas, New Year & Easter holidays.
<br>
<br>
', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32821 AS Decimal(18, 0)), NULL, N'Confirmation will be received at time of booking
<br>
<br>', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32822 AS Decimal(18, 0)), NULL, N'This itinerary is flexible so we can amend any part of it upon your request.
<br>
<br>', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32823 AS Decimal(18, 0)), NULL, N'Other languages are available with extra cost upon your request .
<br>
<br>', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32824 AS Decimal(18, 0)), NULL, N'A child less than 6 years is not allowed for the balloon trip.
<br>
<br>', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32825 AS Decimal(18, 0)), NULL, N'If you want to have your own room, then you need to book for a single room .
<br>
<br>', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32826 AS Decimal(18, 0)), NULL, N'Camera is not allowed on the balloon basket, you can only use your cellphone to take pictures.
<br>
<br>', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32827 AS Decimal(18, 0)), NULL, N'This Tour is not private but in a small group.
<br>
<br>', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32828 AS Decimal(18, 0)), NULL, N'Optional tours such as Abu Simbel Or Nubian village are available upon your request .
<br>
<br>
Wi fi is Available on board your Nile Dahabiya.
<br>
<br>
Alcohol on board is available with extra cost upon your request.
<br>
<br>', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32829 AS Decimal(18, 0)), NULL, N'Suits in our calendar booking applies only to our Dahabiya accommodation not to hotels in Cairo,red sea,etc
<br>
<br>', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32830 AS Decimal(18, 0)), NULL, N'Children policy:
<br>
(Up to 2 years free of charge.)
<br>
(Age from 2 and below 5 years : 15% of adult price)

<br>
(Age from 5 up to 11 years : 50% of adult price )

<br>
(Ages 12 years and up : adult price)

<br>
<br>

Note:
<br>
 Child pricing applies to children who share rooms with their parents (max 1 children in each room)', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32831 AS Decimal(18, 0)), NULL, N'<br>
<br>
Cancellation policy :
<br>

you can cancel 5 days before the travel date and you will get full refund.

<br>

between 4 and 2 days before the travel date a fee of 30% of the total price.
<br>
less than 2 days before the travel date a fee of 50% of the total price.

<br>', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32832 AS Decimal(18, 0)), NULL, N'Prices are quoted in US Dollars per person per trip except during Christmas, New Year & Easter holidays.
<br>
<br>
', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32833 AS Decimal(18, 0)), NULL, N'Confirmation will be received at time of booking
<br>
<br>', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32834 AS Decimal(18, 0)), NULL, N'This itinerary is flexible so we can amend any part of it upon your request.
<br>
<br>
', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32835 AS Decimal(18, 0)), NULL, N'Other languages are available with extra cost upon your request .
<br>
<br>', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32836 AS Decimal(18, 0)), NULL, N'A child less than 6 years is not allowed for the balloon trip.
<br>
<br>', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32837 AS Decimal(18, 0)), NULL, N'If you want to have your own room, then you need to book for a single room .
<br>
<br>', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32838 AS Decimal(18, 0)), NULL, N'Camera is not allowed on the balloon basket, you can only use your cellphone to take pictures.
<br>
<br>
', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32839 AS Decimal(18, 0)), NULL, N'This Tour is not private but in a small group.
<br>
<br>
', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32840 AS Decimal(18, 0)), NULL, N'Optional tours such as Abu Simbel Or Nubian village are available upon your request .
<br>
<br>
Wi fi is Available on board your Nile Dahabiya.
<br>
<br>
Alcohol on board is available with extra cost upon your request.
<br>
<br>
', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32841 AS Decimal(18, 0)), NULL, N'Suits in our calendar booking applies only to our Dahabiya accommodation not to hotels in Cairo,red sea,etc
<br>
<br>', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32842 AS Decimal(18, 0)), NULL, N'Children policy:
<br>
(Up to 2 years free of charge.)
<br>
(Age from 2 and below 5 years : 15% of adult price)

<br>
(Age from 5 up to 11 years : 50% of adult price )

<br>
(Ages 12 years and up : adult price)

<br>
<br>

Note:
<br>
 Child pricing applies to children who share rooms with their parents (max 1 children in each room)
', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32843 AS Decimal(18, 0)), NULL, N'<br>
<br>
Cancellation policy :
<br>

you can cancel 5 days before the travel date and you will get full refund.

<br>

between 4 and 2 days before the travel date a fee of 30% of the total price.
<br>
less than 2 days before the travel date a fee of 50% of the total price.

<br>', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32130 AS Decimal(18, 0)), NULL, N'3', CAST(45 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32128 AS Decimal(18, 0)), NULL, N're', CAST(44 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32806 AS Decimal(18, 0)), NULL, N'Prices are quoted in US Dollars per person per trip except during Christmas, New Year & Easter holidays.
<br>
<br>

', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32807 AS Decimal(18, 0)), NULL, N'Confirmation will be received at time of booking
<br>
<br>', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32808 AS Decimal(18, 0)), NULL, N'This itinerary is flexible so we can amend any part of it upon your request.
<br>
<br>', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32809 AS Decimal(18, 0)), NULL, N'Other languages are available with extra cost upon your request .
<br>
<br>', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32810 AS Decimal(18, 0)), NULL, N'A child less than 6 years is not allowed for the balloon trip.
<br>
<br>', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32811 AS Decimal(18, 0)), NULL, N'If you want to have your own room, then you need to book for a single room .
<br>
<br>', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32812 AS Decimal(18, 0)), NULL, N'Camera is not allowed on the balloon basket, you can only use your cellphone to take pictures.
<br>
<br>', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32813 AS Decimal(18, 0)), NULL, N'This Tour is not private but in a small group.
<br>
<br>', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32814 AS Decimal(18, 0)), NULL, N'Optional tours such as Abu Simbel Or Nubian village are available upon your request .
<br>
<br>
Wi fi is Available on board your Nile Dahabiya.
<br>
<br>
Alcohol on board is available with extra cost upon your request.
<br>
<br>', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32815 AS Decimal(18, 0)), NULL, N'Suits in our calendar booking applies only to our Dahabiya accommodation not to hotels in Cairo,red sea,etc
<br>
<br>', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32816 AS Decimal(18, 0)), NULL, N'Children policy:
<br>
(Up to 2 years free of charge.)
<br>
(Age from 2 and below 5 years : 15% of adult price)

<br>
(Age from 5 up to 11 years : 50% of adult price )

<br>
(Ages 12 years and up : adult price)

<br>
<br>

Note:
<br>
 Child pricing applies to children who share rooms with their parents (max 1 children in each room)', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32817 AS Decimal(18, 0)), NULL, N'<br>
<br>
Cancellation policy :
<br>

you can cancel 5 days before the travel date and you will get full refund.

<br>

between 4 and 2 days before the travel date a fee of 30% of the total price.
<br>
less than 2 days before the travel date a fee of 50% of the total price.

<br>
<br>', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32758 AS Decimal(18, 0)), NULL, N'Prices are quoted in US Dollars per person per trip except during Christmas, New Year & Easter holidays.
<br>
<br>
', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32759 AS Decimal(18, 0)), NULL, N'Confirmation will be received at time of booking
<br>
<br>', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32760 AS Decimal(18, 0)), NULL, N'This itinerary is flexible so we can amend any part of it upon your request.
<br>
<br>', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32761 AS Decimal(18, 0)), NULL, N'Other languages are available with extra cost upon your request .
<br>
<br>', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32762 AS Decimal(18, 0)), NULL, N'A child less than 6 years is not allowed for the balloon trip.
<br>
<br>', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32763 AS Decimal(18, 0)), NULL, N'If you want to have your own room, then you need to book for a single room .
<br>
<br>', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32764 AS Decimal(18, 0)), NULL, N'Camera is not allowed on the balloon basket, you can only use your cellphone to take pictures.
<br>
<br>', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32765 AS Decimal(18, 0)), NULL, N'This Tour is not private but in a small group.
<br>
<br>', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32766 AS Decimal(18, 0)), NULL, N'Optional tours such as Abu Simbel Or Nubian village are available upon your request .
<br>
<br>
Wi fi is Available on board your Nile Dahabiya.
<br>
<br>
Alcohol on board is available with extra cost upon your request.
<br>
<br>', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32767 AS Decimal(18, 0)), NULL, N'Suits in our calendar booking applies only to our Dahabiya accommodation not to hotels in Cairo,red sea,etc
<br>
<br>', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32768 AS Decimal(18, 0)), NULL, N'Children policy:
<br>
(Up to 2 years free of charge.)
<br>
(Age from 2 and below 5 years : 15% of adult price)

<br>
(Age from 5 up to 11 years : 50% of adult price )

<br>
(Ages 12 years and up : adult price)

<br>
<br>

Note:
<br>
 Child pricing applies to children who share rooms with their parents (max 1 children in each room', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32769 AS Decimal(18, 0)), NULL, N'<br>
<br>
Cancellation policy :
<br>

you can cancel 5 days before the travel date and you will get full refund.

<br>

between 4 and 2 days before the travel date a fee of 30% of the total price.
<br>
less than 2 days before the travel date a fee of 50% of the total price.

<br>', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32723 AS Decimal(18, 0)), NULL, N'Prices are quoted in US Dollars per person per trip except during Christmas, New Year & Easter holidays.
<br>
<br>

', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32724 AS Decimal(18, 0)), NULL, N'Confirmation will be received at time of booking.
<br>
<br>', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32725 AS Decimal(18, 0)), NULL, N'This itinerary is flexible so we can amend any part of it upon your request.
<br>
<br>', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32726 AS Decimal(18, 0)), NULL, N'Other languages are available with extra cost upon your request .
<br>
<br>', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32727 AS Decimal(18, 0)), NULL, N'If you want to have your own room, then you need to book for a single room .
<br>
<br>', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32728 AS Decimal(18, 0)), NULL, N'Camera is not allowed on the balloon basket, you can only use your cellphone to take pictures.
<br>
<br>', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32729 AS Decimal(18, 0)), NULL, N'This Tour is not private but in a small group.
<br>
<br>
', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32730 AS Decimal(18, 0)), NULL, N'Optional tours such as Abu Simbel Or Nubian village are available upon your request .
<br>
<br>
Wi fi is Available on board your Nile Dahabiya.
<br>
<br>
Alcohol on board is available with extra cost upon your request.
<br>
<br>', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32731 AS Decimal(18, 0)), NULL, N'Suits in our calendar booking applies only to our Dahabiya accommodation not to hotels in Cairo,red sea,etc
<br>
<br>', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32732 AS Decimal(18, 0)), NULL, N'Children policy:
<br>
(Up to 2 years free of charge.)
<br>
(Age from 2 and below 5 years : 15% of adult price)

<br>
(Age from 5 up to 11 years : 50% of adult price )

<br>
(Ages 12 years and up : adult price)

<br>
<br>

Note:
<br>
 Child pricing applies to children who share rooms with their parents (max 1 children in each room)', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32782 AS Decimal(18, 0)), NULL, N'Prices are quoted in US Dollars per person per trip except during Christmas, New Year & Easter holidays.
<br>
<br>
', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32783 AS Decimal(18, 0)), NULL, N'Confirmation will be received at time of booking
<br>
<br>', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32784 AS Decimal(18, 0)), NULL, N'This itinerary is flexible so we can amend any part of it upon your request.
<br>
<br>', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32785 AS Decimal(18, 0)), NULL, N'Other languages are available with extra cost upon your request .
<br>
<br>', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32786 AS Decimal(18, 0)), NULL, N'A child less than 6 years is not allowed for the balloon trip.
<br>
<br>', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32787 AS Decimal(18, 0)), NULL, N'If you want to have your own room, then you need to book for a single room .
<br>
<br>', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32788 AS Decimal(18, 0)), NULL, N'Camera is not allowed on the balloon basket, you can only use your cellphone to take pictures.
<br>
<br>', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32789 AS Decimal(18, 0)), NULL, N'This Tour is not private but in a small group.
<br>
<br>
', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32790 AS Decimal(18, 0)), NULL, N'Optional tours such as Abu Simbel Or Nubian village are available upon your request .
<br>
<br>
Wi fi is Available on board your Nile Dahabiya.
<br>
<br>
Alcohol on board is available with extra cost upon your request.
<br>
<br>', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32791 AS Decimal(18, 0)), NULL, N'Suits in our calendar booking applies only to our Dahabiya accommodation not to hotels in Cairo,red sea,etc
<br>
<br>', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32792 AS Decimal(18, 0)), NULL, N'Children policy:
<br>
(Up to 2 years free of charge.)
<br>
(Age from 2 and below 5 years : 15% of adult price)

<br>
(Age from 5 up to 11 years : 50% of adult price )

<br>
(Ages 12 years and up : adult price)

<br>
<br>

Note:
<br>
 Child pricing applies to children who share rooms with their parents (max 1 children in each room)', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32793 AS Decimal(18, 0)), NULL, N'<br>
<br>
Cancellation policy :
<br>

you can cancel 5 days before the travel date and you will get full refund.

<br>

between 4 and 2 days before the travel date a fee of 30% of the total price.
<br>
less than 2 days before the travel date a fee of 50% of the total price.', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32734 AS Decimal(18, 0)), NULL, N'Prices are quoted in US Dollars per person per trip except during Christmas, New Year & Easter holidays.
<br>
<br>', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32711 AS Decimal(18, 0)), NULL, N'Prices are quoted in US Dollars per person per trip except during Christmas, New Year & Easter holidays.
<br>
<br>
', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32712 AS Decimal(18, 0)), NULL, N'Confirmation will be received at time of booking
<br>
<br>', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32713 AS Decimal(18, 0)), NULL, N'This itinerary is flexible so we can amend any part of it upon your request.
<br>
<br>', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32714 AS Decimal(18, 0)), NULL, N'Other languages are available with extra cost upon your request .
<br>
<br>', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32715 AS Decimal(18, 0)), NULL, N'A child less than 6 years is not allowed for the balloon trip.
<br>
<br>', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32716 AS Decimal(18, 0)), NULL, N'If you want to have your own room, then you need to book for a single room .
<br>
<br>', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32717 AS Decimal(18, 0)), NULL, N'Camera is not allowed on the balloon basket, you can only use your cellphone to take pictures.
<br>
<br>', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32718 AS Decimal(18, 0)), NULL, N'This Tour is not private but in a small group.
<br>
<br>
', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32719 AS Decimal(18, 0)), NULL, N'Optional tours such as Abu Simbel Or Nubian village are available upon your request .
<br>
<br>
Wi fi is Available on board your Nile Dahabiya.
<br>
<br>
Alcohol on board is available with extra cost upon your request.
<br>
<br>', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32720 AS Decimal(18, 0)), NULL, N'Suits in our calendar booking applies only to our Dahabiya accommodation not to hotels in Cairo,red sea,etc
<br>
<br>', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32735 AS Decimal(18, 0)), NULL, N'Confirmation will be received at time of booking
<br>
<br>

', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32736 AS Decimal(18, 0)), NULL, N'This itinerary is flexible so we can amend any part of it upon your request.
<br>
<br>', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32737 AS Decimal(18, 0)), NULL, N'Other languages are available with extra cost upon your request .
<br>
<br>', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32721 AS Decimal(18, 0)), NULL, N'Children policy:
<br>
(Up to 2 years free of charge.)
<br>
(Age from 2 and below 5 years : 15% of adult price)

<br>
(Age from 5 up to 11 years : 50% of adult price )

<br>
(Ages 12 years and up : adult price)

<br>
<br>

Note:
<br>
 Child pricing applies to children who share rooms with their parents (max 1 children in each room)
', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32722 AS Decimal(18, 0)), NULL, N'<br>
<br>
Cancellation policy :
<br>

you can cancel 5 days before the travel date and you will get full refund.

<br>

between 4 and 2 days before the travel date a fee of 30% of the total price.
<br>
less than 2 days before the travel date a fee of 50% of the total price.

<br>', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32733 AS Decimal(18, 0)), NULL, N'<br>
<br>
Cancellation policy :
<br>

you can cancel 5 days before the travel date and you will get full refund.

<br>

between 4 and 2 days before the travel date a fee of 30% of the total price.
<br>
less than 2 days before the travel date a fee of 50% of the total price.

<br>', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32738 AS Decimal(18, 0)), NULL, N'A child less than 6 years is not allowed for the balloon trip.
<br>
<br>', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32739 AS Decimal(18, 0)), NULL, N'If you want to have your own room, then you need to book for a single room .
<br>
<br>', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32740 AS Decimal(18, 0)), NULL, N'Camera is not allowed on the balloon basket, you can only use your cellphone to take pictures.
<br>
<br>', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32741 AS Decimal(18, 0)), NULL, N'This Tour is not private but in a small group.
<br>
<br>
', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32742 AS Decimal(18, 0)), NULL, N'Optional tours such as Abu Simbel Or Nubian village are available upon your request .
<br>
<br>
Wi fi is Available on board your Nile Dahabiya.
<br>
<br>
Alcohol on board is available with extra cost upon your request.
<br>
<br>', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32743 AS Decimal(18, 0)), NULL, N'Suits in our calendar booking applies only to our Dahabiya accommodation not to hotels in Cairo,red sea,etc
<br>
<br>', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32744 AS Decimal(18, 0)), NULL, N'Children policy:
<br>
(Up to 2 years free of charge.)
<br>
(Age from 2 and below 5 years : 15% of adult price)

<br>
(Age from 5 up to 11 years : 50% of adult price )

<br>
(Ages 12 years and up : adult price)

<br>
<br>

Note:
<br>
 Child pricing applies to children who share rooms with their parents (max 1 children in each room)', CAST(35 AS Decimal(18, 0)))
GO
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32745 AS Decimal(18, 0)), NULL, N'<br>
<br>
Cancellation policy :
<br>

you can cancel 5 days before the travel date and you will get full refund.

<br>

between 4 and 2 days before the travel date a fee of 30% of the total price.
<br>
less than 2 days before the travel date a fee of 50% of the total price.

<br>', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32746 AS Decimal(18, 0)), NULL, N'Prices are quoted in US Dollars per person per trip except during 
Christmas, New Year & Easter holidays.
<br>
<br>', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32747 AS Decimal(18, 0)), NULL, N'Confirmation will be received at time of booking
<br>
<br>', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32748 AS Decimal(18, 0)), NULL, N'This itinerary is flexible so we can amend any part of it upon your request.
<br>
<br>', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32749 AS Decimal(18, 0)), NULL, N'Other languages are available with extra cost upon your request .
<br>
<br>', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32750 AS Decimal(18, 0)), NULL, N'A child less than 6 years is not allowed for the balloon trip.
<br>
<br>', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32751 AS Decimal(18, 0)), NULL, N'If you want to have your own room, then you need to book for a single room .
<br>
<br>', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32752 AS Decimal(18, 0)), NULL, N'Camera is not allowed on the balloon basket, you can only use your cellphone to take pictures.
<br>
<br>', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32753 AS Decimal(18, 0)), NULL, N'This Tour is not private but in a small group.
<br>
<br>
', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32754 AS Decimal(18, 0)), NULL, N'Optional tours such as Abu Simbel Or Nubian village are available upon your request .
<br>
<br>
Wi fi is Available on board your Nile Dahabiya.
<br>
<br>
Alcohol on board is available with extra cost upon your request.
<br>
<br>', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32755 AS Decimal(18, 0)), NULL, N'Suits in our calendar booking applies only to our Dahabiya accommodation not to hotels in Cairo,red sea,etc
<br>
<br>', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[additionalInformations] ([additionalInfoId], [title], [details], [tourId]) VALUES (CAST(32756 AS Decimal(18, 0)), NULL, N'Children policy:
<br>
(Up to 2 years free of charge.)
<br>
(Age from 2 and below 5 years : 15% of adult price)

<br>
(Age from 5 up to 11 years : 50% of adult price )

<br>
(Ages 12 years and up : adult price)

<br>
<br>

Note:
<br>
 Child pricing applies to children who share rooms with their parents (max 1 children in each room)
', CAST(37 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[additionalInformations] OFF
GO
SET IDENTITY_INSERT [dbo].[blockedDates] ON 

INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(78 AS Decimal(18, 0)), N'14-10-2024', 44, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(178 AS Decimal(18, 0)), N'03-01-2025', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(179 AS Decimal(18, 0)), N'10-01-2025', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(180 AS Decimal(18, 0)), N'17-01-2025', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(181 AS Decimal(18, 0)), N'25-10-2024', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(182 AS Decimal(18, 0)), N'25-10-2024', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(183 AS Decimal(18, 0)), N'01-11-2024', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(80 AS Decimal(18, 0)), N'', 45, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(184 AS Decimal(18, 0)), N'18-10-2024', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(185 AS Decimal(18, 0)), N'08-11-2024', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(186 AS Decimal(18, 0)), N'15-11-2024', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(187 AS Decimal(18, 0)), N'22-11-2024', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(188 AS Decimal(18, 0)), N'29-11-2024', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(189 AS Decimal(18, 0)), N'06-12-2024', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(190 AS Decimal(18, 0)), N'13-12-2024', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(191 AS Decimal(18, 0)), N'20-12-2024', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(192 AS Decimal(18, 0)), N'27-12-2024', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(193 AS Decimal(18, 0)), N'03-01-2025', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(194 AS Decimal(18, 0)), N'10-01-2025', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(195 AS Decimal(18, 0)), N'17-01-2025', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(196 AS Decimal(18, 0)), N'24-01-2025', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(197 AS Decimal(18, 0)), N'31-01-2025', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(198 AS Decimal(18, 0)), N'07-02-2025', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(199 AS Decimal(18, 0)), N'14-02-2025', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(200 AS Decimal(18, 0)), N'21-02-2025', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(201 AS Decimal(18, 0)), N'28-02-2025', 42, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(355 AS Decimal(18, 0)), N'20-10-2024', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(356 AS Decimal(18, 0)), N'27-10-2024', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(357 AS Decimal(18, 0)), N'03-11-2024', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(358 AS Decimal(18, 0)), N'10-11-2024', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(359 AS Decimal(18, 0)), N'17-11-2024', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(360 AS Decimal(18, 0)), N'24-11-2024', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(361 AS Decimal(18, 0)), N'01-12-2024', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(362 AS Decimal(18, 0)), N'08-12-2024', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(363 AS Decimal(18, 0)), N'15-12-2024', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(364 AS Decimal(18, 0)), N'22-12-2024', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(365 AS Decimal(18, 0)), N'29-12-2024', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(366 AS Decimal(18, 0)), N'05-01-2025', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(367 AS Decimal(18, 0)), N'12-01-2025', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(368 AS Decimal(18, 0)), N'19-01-2025', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(369 AS Decimal(18, 0)), N'26-01-2025', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(370 AS Decimal(18, 0)), N'02-02-2025', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(371 AS Decimal(18, 0)), N'09-02-2025', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(372 AS Decimal(18, 0)), N'16-02-2025', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(373 AS Decimal(18, 0)), N'23-02-2025', 34, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(240 AS Decimal(18, 0)), N'16-10-2024', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(202 AS Decimal(18, 0)), N'23-10-2024', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(203 AS Decimal(18, 0)), N'30-10-2024', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(204 AS Decimal(18, 0)), N'06-11-2024', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(205 AS Decimal(18, 0)), N'13-11-2024', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(206 AS Decimal(18, 0)), N'20-11-2024', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(207 AS Decimal(18, 0)), N'27-11-2024', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(208 AS Decimal(18, 0)), N'04-12-2024', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(209 AS Decimal(18, 0)), N'11-12-2024', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(210 AS Decimal(18, 0)), N'18-12-2024', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(211 AS Decimal(18, 0)), N'25-12-2024', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(212 AS Decimal(18, 0)), N'01-01-2025', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(213 AS Decimal(18, 0)), N'08-01-2025', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(214 AS Decimal(18, 0)), N'15-01-2025', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(215 AS Decimal(18, 0)), N'22-01-2025', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(216 AS Decimal(18, 0)), N'29-01-2025', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(217 AS Decimal(18, 0)), N'05-02-2025', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(218 AS Decimal(18, 0)), N'12-02-2025', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(219 AS Decimal(18, 0)), N'19-02-2025', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(220 AS Decimal(18, 0)), N'26-02-2025', 41, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(221 AS Decimal(18, 0)), N'25-10-2024', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(222 AS Decimal(18, 0)), N'01-11-2024', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(223 AS Decimal(18, 0)), N'08-11-2024', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(224 AS Decimal(18, 0)), N'15-11-2024', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(225 AS Decimal(18, 0)), N'22-11-2024', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(226 AS Decimal(18, 0)), N'29-11-2024', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(227 AS Decimal(18, 0)), N'06-12-2024', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(228 AS Decimal(18, 0)), N'13-12-2024', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(229 AS Decimal(18, 0)), N'20-12-2024', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(230 AS Decimal(18, 0)), N'27-12-2024', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(231 AS Decimal(18, 0)), N'03-01-2025', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(232 AS Decimal(18, 0)), N'10-01-2025', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(233 AS Decimal(18, 0)), N'17-01-2025', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(234 AS Decimal(18, 0)), N'24-01-2025', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(235 AS Decimal(18, 0)), N'31-01-2025', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(236 AS Decimal(18, 0)), N'07-02-2025', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(237 AS Decimal(18, 0)), N'14-02-2025', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(238 AS Decimal(18, 0)), N'21-02-2025', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(239 AS Decimal(18, 0)), N'28-02-2025', 35, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(241 AS Decimal(18, 0)), N'23-10-2024', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(242 AS Decimal(18, 0)), N'30-10-2024', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(243 AS Decimal(18, 0)), N'06-11-2024', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(244 AS Decimal(18, 0)), N'13-11-2024', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(245 AS Decimal(18, 0)), N'20-11-2024', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(246 AS Decimal(18, 0)), N'27-11-2024', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(247 AS Decimal(18, 0)), N'04-12-2024', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(248 AS Decimal(18, 0)), N'11-12-2024', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(249 AS Decimal(18, 0)), N'18-12-2024', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(250 AS Decimal(18, 0)), N'25-12-2024', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(251 AS Decimal(18, 0)), N'01-01-2025', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(252 AS Decimal(18, 0)), N'08-01-2025', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(253 AS Decimal(18, 0)), N'15-01-2025', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(254 AS Decimal(18, 0)), N'22-01-2025', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(255 AS Decimal(18, 0)), N'29-01-2025', 37, NULL)
GO
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(256 AS Decimal(18, 0)), N'05-02-2025', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(257 AS Decimal(18, 0)), N'12-02-2025', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(258 AS Decimal(18, 0)), N'19-02-2025', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(259 AS Decimal(18, 0)), N'26-02-2025', 37, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(260 AS Decimal(18, 0)), N'24-10-2024', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(261 AS Decimal(18, 0)), N'31-10-2024', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(262 AS Decimal(18, 0)), N'07-11-2024', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(263 AS Decimal(18, 0)), N'14-11-2024', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(264 AS Decimal(18, 0)), N'21-11-2024', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(265 AS Decimal(18, 0)), N'28-11-2024', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(266 AS Decimal(18, 0)), N'05-12-2024', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(267 AS Decimal(18, 0)), N'12-12-2024', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(268 AS Decimal(18, 0)), N'19-12-2024', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(269 AS Decimal(18, 0)), N'26-12-2024', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(270 AS Decimal(18, 0)), N'02-01-2025', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(271 AS Decimal(18, 0)), N'09-01-2025', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(272 AS Decimal(18, 0)), N'16-01-2025', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(273 AS Decimal(18, 0)), N'23-01-2025', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(274 AS Decimal(18, 0)), N'30-01-2025', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(275 AS Decimal(18, 0)), N'06-02-2025', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(276 AS Decimal(18, 0)), N'13-02-2025', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(277 AS Decimal(18, 0)), N'20-02-2025', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(278 AS Decimal(18, 0)), N'27-02-2025', 40, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(374 AS Decimal(18, 0)), N'19-10-2024', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(375 AS Decimal(18, 0)), N'26-10-2024', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(376 AS Decimal(18, 0)), N'02-11-2024', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(377 AS Decimal(18, 0)), N'09-11-2024', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(378 AS Decimal(18, 0)), N'16-11-2024', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(379 AS Decimal(18, 0)), N'23-11-2024', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(380 AS Decimal(18, 0)), N'30-11-2024', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(381 AS Decimal(18, 0)), N'07-12-2024', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(382 AS Decimal(18, 0)), N'14-12-2024', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(383 AS Decimal(18, 0)), N'21-12-2024', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(384 AS Decimal(18, 0)), N'28-12-2024', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(385 AS Decimal(18, 0)), N'04-01-2025', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(386 AS Decimal(18, 0)), N'11-01-2025', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(387 AS Decimal(18, 0)), N'18-01-2025', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(388 AS Decimal(18, 0)), N'25-01-2025', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(389 AS Decimal(18, 0)), N'01-02-2025', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(390 AS Decimal(18, 0)), N'08-02-2025', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(391 AS Decimal(18, 0)), N'15-02-2025', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(392 AS Decimal(18, 0)), N'22-02-2025', 43, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(298 AS Decimal(18, 0)), N'25-10-2024', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(299 AS Decimal(18, 0)), N'01-11-2024', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(300 AS Decimal(18, 0)), N'08-11-2024', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(301 AS Decimal(18, 0)), N'15-11-2024', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(302 AS Decimal(18, 0)), N'22-11-2024', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(303 AS Decimal(18, 0)), N'29-11-2024', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(304 AS Decimal(18, 0)), N'06-12-2024', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(305 AS Decimal(18, 0)), N'13-12-2024', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(306 AS Decimal(18, 0)), N'20-12-2024', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(307 AS Decimal(18, 0)), N'27-12-2024', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(308 AS Decimal(18, 0)), N'03-01-2025', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(309 AS Decimal(18, 0)), N'10-01-2025', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(310 AS Decimal(18, 0)), N'17-01-2025', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(311 AS Decimal(18, 0)), N'24-01-2025', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(312 AS Decimal(18, 0)), N'31-01-2025', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(313 AS Decimal(18, 0)), N'07-02-2025', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(314 AS Decimal(18, 0)), N'14-02-2025', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(315 AS Decimal(18, 0)), N'21-02-2025', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(316 AS Decimal(18, 0)), N'28-02-2025', 29, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(336 AS Decimal(18, 0)), N'21-10-2024', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(337 AS Decimal(18, 0)), N'28-10-2024', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(338 AS Decimal(18, 0)), N'04-11-2024', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(339 AS Decimal(18, 0)), N'11-11-2024', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(340 AS Decimal(18, 0)), N'18-11-2024', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(341 AS Decimal(18, 0)), N'25-11-2024', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(342 AS Decimal(18, 0)), N'02-12-2024', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(343 AS Decimal(18, 0)), N'09-12-2024', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(344 AS Decimal(18, 0)), N'16-12-2024', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(345 AS Decimal(18, 0)), N'23-12-2024', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(346 AS Decimal(18, 0)), N'30-12-2024', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(347 AS Decimal(18, 0)), N'06-01-2025', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(348 AS Decimal(18, 0)), N'13-01-2025', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(349 AS Decimal(18, 0)), N'20-01-2025', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(350 AS Decimal(18, 0)), N'27-01-2025', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(351 AS Decimal(18, 0)), N'03-02-2025', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(352 AS Decimal(18, 0)), N'10-02-2025', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(353 AS Decimal(18, 0)), N'17-02-2025', 36, NULL)
INSERT [dbo].[blockedDates] ([blockedDatesID], [date], [tourId], [isPublic]) VALUES (CAST(354 AS Decimal(18, 0)), N'24-02-2025', 36, NULL)
SET IDENTITY_INSERT [dbo].[blockedDates] OFF
GO
SET IDENTITY_INSERT [dbo].[blogs] ON 

INSERT [dbo].[blogs] ([blogId], [seoTitle], [seoDescription], [seokeyWords], [viewport], [title], [description], [languageId], [creationDate], [isActive]) VALUES (1, N'first article', N'dasaasdsasdas', N'blog,article', NULL, N'Dress Code and culture behavior while traveling in Egypt', N'Egyptian society is conservative, in some places more than in others. Exposed arms, legs, and more are accepted in big city nightclubs and in tourist', 1, CAST(N'2024-11-02T18:08:24.897' AS DateTime), N'Y')
INSERT [dbo].[blogs] ([blogId], [seoTitle], [seoDescription], [seokeyWords], [viewport], [title], [description], [languageId], [creationDate], [isActive]) VALUES (2, N'bring', N'test', N'test', NULL, N'What to wear and what to bring when you travel to Egypt?', N'What to Wear and do to travel comfortably – how to avoid dehydration, heat stroke and heat rash, and maintain your energy to really enjoy', 1, CAST(N'2024-11-02T17:26:08.463' AS DateTime), N'Y')
INSERT [dbo].[blogs] ([blogId], [seoTitle], [seoDescription], [seokeyWords], [viewport], [title], [description], [languageId], [creationDate], [isActive]) VALUES (3, N'', N'', N'', NULL, N'A brief  introduction to Ancient Egypt', N'Ancient Egyptian history is a long and complex one with more than 3,000 years of details. Throughout these 3,000 years Ancient Egyptians lived under around
Ancient Egyptian history is a long and complex one with more than 3,000 years of details. Throughout these 3,000 years Ancient Egyptians lived under around', 1, CAST(N'2024-11-04T16:07:59.813' AS DateTime), N'Y')
INSERT [dbo].[blogs] ([blogId], [seoTitle], [seoDescription], [seokeyWords], [viewport], [title], [description], [languageId], [creationDate], [isActive]) VALUES (4, N'wwqw', N'asda', N'asda,ss,sss,Ancient', NULL, N'Egypt’s tourist visa information', N'Entry Visa requirements vary depending on your nationality. You must check the Egyptian Government Visa website for the Visa requirements See the page FAQ –', 1, CAST(N'2024-11-04T16:51:57.390' AS DateTime), N'Y')
INSERT [dbo].[blogs] ([blogId], [seoTitle], [seoDescription], [seokeyWords], [viewport], [title], [description], [languageId], [creationDate], [isActive]) VALUES (5, N'wwqw', N'asda', N'asda', NULL, N'Entry fees for all Egypt attractions and Egypt Pass', N'Entry fees for all Egypt attractions and Egypt Pass Cairo & Around Adult Price EGP Student Price EGP EGP Giza pyramids and the Sphinx 360', 1, CAST(N'2024-11-02T17:28:37.063' AS DateTime), N'Y')
INSERT [dbo].[blogs] ([blogId], [seoTitle], [seoDescription], [seokeyWords], [viewport], [title], [description], [languageId], [creationDate], [isActive]) VALUES (6, N'', N'', N'', NULL, N'q', N'q', 1, CAST(N'2024-11-03T19:56:43.120' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[blogs] OFF
GO
SET IDENTITY_INSERT [dbo].[bookAdditionalActivities] ON 

INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (1, CAST(10002 AS Decimal(18, 0)), 1)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (2, CAST(60 AS Decimal(18, 0)), 1)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (3, CAST(61 AS Decimal(18, 0)), 1)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (4, CAST(62 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (5, CAST(63 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (6, CAST(64 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (7, CAST(65 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (8, CAST(66 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (9, CAST(67 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (10, CAST(68 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (11, CAST(69 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (12, CAST(74 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (13, CAST(75 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (14, CAST(76 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (15, CAST(77 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (18, CAST(81 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (19, CAST(82 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (20, CAST(82 AS Decimal(18, 0)), 3)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (21, CAST(83 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (22, CAST(83 AS Decimal(18, 0)), 3)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (23, CAST(85 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (24, CAST(86 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (25, CAST(89 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (26, CAST(112 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (27, CAST(113 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (28, CAST(114 AS Decimal(18, 0)), 6)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (29, CAST(116 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (30, CAST(117 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (31, CAST(123 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (32, CAST(124 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (33, CAST(124 AS Decimal(18, 0)), 3)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (34, CAST(130 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (35, CAST(130 AS Decimal(18, 0)), 3)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (36, CAST(136 AS Decimal(18, 0)), 4)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (37, CAST(136 AS Decimal(18, 0)), 3)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (42, CAST(1035 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (53, CAST(1042 AS Decimal(18, 0)), 4)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (54, CAST(1043 AS Decimal(18, 0)), 6)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (55, CAST(1043 AS Decimal(18, 0)), 5)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (63, CAST(1046 AS Decimal(18, 0)), 5)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (64, CAST(1046 AS Decimal(18, 0)), 4)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (65, CAST(1047 AS Decimal(18, 0)), 6)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (66, CAST(1047 AS Decimal(18, 0)), 5)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (16, CAST(78 AS Decimal(18, 0)), 3)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (17, CAST(79 AS Decimal(18, 0)), 3)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (38, CAST(137 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (39, CAST(137 AS Decimal(18, 0)), 3)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (40, CAST(1020 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (41, CAST(1034 AS Decimal(18, 0)), 3)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (43, CAST(1036 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (44, CAST(1036 AS Decimal(18, 0)), 5)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (45, CAST(1036 AS Decimal(18, 0)), 6)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (46, CAST(1037 AS Decimal(18, 0)), 6)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (51, CAST(1040 AS Decimal(18, 0)), 4)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (52, CAST(1041 AS Decimal(18, 0)), 4)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (56, CAST(1044 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (57, CAST(1044 AS Decimal(18, 0)), 6)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (58, CAST(1044 AS Decimal(18, 0)), 5)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (59, CAST(1044 AS Decimal(18, 0)), 4)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (60, CAST(1045 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (61, CAST(1045 AS Decimal(18, 0)), 6)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (62, CAST(1045 AS Decimal(18, 0)), 5)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (67, CAST(1050 AS Decimal(18, 0)), 6)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (68, CAST(1051 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (69, CAST(1051 AS Decimal(18, 0)), 6)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (47, CAST(1038 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (48, CAST(1038 AS Decimal(18, 0)), 6)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (49, CAST(1039 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (50, CAST(1039 AS Decimal(18, 0)), 6)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (71, CAST(1055 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (70, CAST(1052 AS Decimal(18, 0)), 4)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (72, CAST(1059 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (73, CAST(1059 AS Decimal(18, 0)), 3)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (74, CAST(1059 AS Decimal(18, 0)), 4)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (75, CAST(1059 AS Decimal(18, 0)), 5)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (76, CAST(1059 AS Decimal(18, 0)), 6)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (77, CAST(1060 AS Decimal(18, 0)), 2)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (78, CAST(1060 AS Decimal(18, 0)), 3)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (79, CAST(1060 AS Decimal(18, 0)), 5)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (80, CAST(1060 AS Decimal(18, 0)), 4)
INSERT [dbo].[bookAdditionalActivities] ([id], [bookId], [tourActivityId]) VALUES (81, CAST(1060 AS Decimal(18, 0)), 6)
SET IDENTITY_INSERT [dbo].[bookAdditionalActivities] OFF
GO
SET IDENTITY_INSERT [dbo].[booking] ON 

INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1000 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'Beninese', CAST(N'2025-03-07T00:00:00.000' AS DateTime), 1, 0, 0, N'a', NULL, 1, N'english', CAST(1890.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1001 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'Belizean', CAST(N'2025-04-04T00:00:00.000' AS DateTime), 2, 0, 0, N'a', NULL, 1, N'english', CAST(2360.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1002 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'Belizean', CAST(N'2025-03-07T00:00:00.000' AS DateTime), 2, 0, 0, N'a', NULL, 1, N'english', CAST(2360.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1003 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'American', CAST(N'2025-05-02T00:00:00.000' AS DateTime), 2, 0, 0, N'a', NULL, 2, N'french', CAST(3780.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1004 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'American', CAST(N'2025-03-14T00:00:00.000' AS DateTime), 2, 0, 0, N'a', NULL, 2, N'french', CAST(3780.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1005 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'American', CAST(N'2025-04-11T00:00:00.000' AS DateTime), 2, 0, 0, N'a', NULL, 2, N'french', CAST(3780.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1006 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'American', CAST(N'2025-05-02T00:00:00.000' AS DateTime), 2, 0, 0, N'a', NULL, 2, N'french', CAST(3780.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1007 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'American', CAST(N'2025-05-02T00:00:00.000' AS DateTime), 1, 0, 0, N'a', NULL, 1, N'english', CAST(1890.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1008 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'American', CAST(N'2025-03-07T00:00:00.000' AS DateTime), 1, 0, 0, N'a', N'complete', 1, N'french', CAST(1890.00 AS Decimal(18, 2)), N'SESSION0002205085170G2501790M31', N'complete', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1009 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'American', CAST(N'2025-04-04T00:00:00.000' AS DateTime), 1, 0, 0, N'a', N'complete', 1, N'english', CAST(1890.00 AS Decimal(18, 2)), N'SESSION0002389325324H3438299K41', N'complete', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1010 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'Belizean', CAST(N'2025-04-04T00:00:00.000' AS DateTime), 1, 0, 0, N'a', NULL, 1, N'Spanish', CAST(1890.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1011 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'American', CAST(N'2025-05-02T00:00:00.000' AS DateTime), 1, 0, 0, N'a', NULL, 1, N'english', CAST(1890.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1012 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'American', CAST(N'2025-04-11T00:00:00.000' AS DateTime), 1, 0, 0, N'a', N'complete', 1, N'english', CAST(1890.00 AS Decimal(18, 2)), N'SESSION0002242973508F5143848H40', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1013 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'Afghan', CAST(N'2025-05-02T00:00:00.000' AS DateTime), 1, 0, 0, N'a', N'cancel', 1, N'english', CAST(1890.00 AS Decimal(18, 2)), N'SESSION0002941393019J1105138F81', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1014 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'Beninese', CAST(N'2025-04-04T00:00:00.000' AS DateTime), 1, 0, 0, N'a', NULL, 1, N'french', CAST(1890.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1015 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'Bolivian', CAST(N'2025-05-09T00:00:00.000' AS DateTime), 2, 0, 0, N'a', NULL, 2, N'english', CAST(3780.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1016 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'Albanian', CAST(N'2025-04-11T00:00:00.000' AS DateTime), 1, 0, 0, N'a', NULL, 1, N'english', CAST(1890.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1017 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'American', CAST(N'2025-04-04T00:00:00.000' AS DateTime), 1, 0, 0, N'a', N'cancel', 1, N'english', CAST(1890.00 AS Decimal(18, 2)), N'SESSION0002135822593H8941484F40', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1018 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'121', N'amrheshmat95@gmail.com', N'a', N'Barbadian', CAST(N'2025-04-04T00:00:00.000' AS DateTime), 1, 1, 0, N'q', N'complete', 1, N'french', CAST(2480.00 AS Decimal(18, 2)), N'SESSION0002688233498E4366551E42', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1019 AS Decimal(18, 0)), CAST(42 AS Decimal(18, 0)), N'01003051936', N'amrheshmat95@gmail.com', N'amr heshmat', N'Andorran', CAST(N'2025-04-18T00:00:00.000' AS DateTime), 1, 0, 0, N'اا', N'cancel', 1, N'english', CAST(1860.00 AS Decimal(18, 2)), N'SESSION0002570083626N3758179M44', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1020 AS Decimal(18, 0)), CAST(41 AS Decimal(18, 0)), N'01157553375', N'booking@anoushdahabiya.com', N'Salwa abd al ftah ', N'Argentinian', CAST(N'2025-03-12T00:00:00.000' AS DateTime), 1, 0, 0, N'aswan', NULL, 1, N'english', CAST(2051.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1021 AS Decimal(18, 0)), CAST(41 AS Decimal(18, 0)), N'01157553375', N'booking@anoushdahabiya.com', N'Salwa abd al ftah ', N'Argentinian', CAST(N'2025-04-09T00:00:00.000' AS DateTime), 1, 0, 0, N'aswan', NULL, 1, N'english', CAST(2016.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1022 AS Decimal(18, 0)), CAST(43 AS Decimal(18, 0)), N'01026044358', N'salwahere1@gmail.com', N'Salwa abd al ftah ', N'Bangladeshi', CAST(N'2025-03-22T00:00:00.000' AS DateTime), 1, 0, 0, N'aswan', N'complete', 1, N'english', CAST(2.00 AS Decimal(18, 2)), N'SESSION0002303750481N9303328L65', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1023 AS Decimal(18, 0)), CAST(43 AS Decimal(18, 0)), N'01157553375', N'lola12345abdo@gmail.com', N'Salwa abd al ftah ', N'Andorran', CAST(N'2025-05-03T00:00:00.000' AS DateTime), 1, 0, 0, N'aswan', N'complete', 1, N'english', CAST(2.00 AS Decimal(18, 2)), N'SESSION0002898247818M1120156G40', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1024 AS Decimal(18, 0)), CAST(43 AS Decimal(18, 0)), N'01157553375', N'lola12345abdo@gmail.com', N'Salwa abd al ftah ', N'Egyptian', CAST(N'2025-03-15T00:00:00.000' AS DateTime), 2, 0, 0, N'luxor', N'complete', 1, N'english', CAST(800.00 AS Decimal(18, 2)), N'SESSION0002673833359M4892019F28', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1025 AS Decimal(18, 0)), CAST(42 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'Belizean', CAST(N'2025-04-11T00:00:00.000' AS DateTime), 1, 0, 0, N'a', N'complete', 1, N'english', CAST(1860.00 AS Decimal(18, 2)), N'SESSION0002424562067G9925138F51', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1026 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'Belgian', CAST(N'2025-05-02T00:00:00.000' AS DateTime), 1, 0, 0, N'a', N'complete', 1, N'english', CAST(1890.00 AS Decimal(18, 2)), N'SESSION0002156525671E8247141M63', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1027 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'American', CAST(N'2025-06-13T00:00:00.000' AS DateTime), 1, 0, 0, N'a', N'complete', 1, N'english', CAST(1890.00 AS Decimal(18, 2)), N'SESSION0002943263600L0076581M79', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1029 AS Decimal(18, 0)), CAST(43 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'American', CAST(N'2025-08-02T00:00:00.000' AS DateTime), 1, 0, 0, N'a', N'complete', 1, N'english', CAST(2.00 AS Decimal(18, 2)), N'SESSION0002656620509L1737105F10', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1030 AS Decimal(18, 0)), CAST(40 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'Belgian', CAST(N'2025-04-10T00:00:00.000' AS DateTime), 1, 0, 0, N'a', N'complete', 1, N'english', CAST(1760.00 AS Decimal(18, 2)), N'SESSION0002219487301M7278000L04', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1032 AS Decimal(18, 0)), CAST(43 AS Decimal(18, 0)), N'01157553375', N'lola12345abdo@gmail.com', N'Salwa abd al ftah ', N'Egyptian', CAST(N'2025-04-12T00:00:00.000' AS DateTime), 1, 0, 0, N'aswan', N'complete', 1, N'english', CAST(2.00 AS Decimal(18, 2)), N'SESSION0002114995538I5103816E27', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1034 AS Decimal(18, 0)), CAST(43 AS Decimal(18, 0)), N'01157553375', N'lola12345abdo@gmail.com', N'Salwa abd al ftah ', N'Egyptian', CAST(N'2025-03-15T00:00:00.000' AS DateTime), 1, 0, 0, N'aswan', N'complete', 1, N'english', CAST(97.00 AS Decimal(18, 2)), N'SESSION0002781217625I8663537I61', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1035 AS Decimal(18, 0)), CAST(41 AS Decimal(18, 0)), N'01157553375', N'lola12345abdo@gmail.com', N'Salwa abd al ftah ', N'Azerbaijani', CAST(N'2025-03-19T00:00:00.000' AS DateTime), 2, 0, 0, N'aswan', NULL, 1, N'english', CAST(2590.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1028 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'a', N'American', CAST(N'2025-06-13T00:00:00.000' AS DateTime), 1, 0, 0, N'a', N'complete', 1, N'english', CAST(1890.00 AS Decimal(18, 2)), N'SESSION0002082785514L3184181K90', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1031 AS Decimal(18, 0)), CAST(43 AS Decimal(18, 0)), N'121', N'amrheshmat95@gmail.com', N'a', N'Belizean', CAST(N'2025-04-05T00:00:00.000' AS DateTime), 1, 0, 0, N'q', N'complete', 1, N'english', CAST(2.00 AS Decimal(18, 2)), N'SESSION0002270086542N2588564J20', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1033 AS Decimal(18, 0)), CAST(43 AS Decimal(18, 0)), N'01157553375', N'lola12345abdo@gmail.com', N'Salwa abd al ftah ', N'Egyptian', CAST(N'2025-03-08T00:00:00.000' AS DateTime), 1, 0, 0, N'aswan', N'complete', 1, N'english', CAST(2.00 AS Decimal(18, 2)), N'SESSION0002444127361M4153350J86', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1036 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'121', N'amrheshmat95@gmail.com', N'a', N'Argentinian', CAST(N'2025-04-04T00:00:00.000' AS DateTime), 1, 0, 0, N'test pick', N'complete', 1, N'english', CAST(1980.00 AS Decimal(18, 2)), N'SESSION0002312174392F59182780J3', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1037 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'121', N'amrheshmat95@gmail.com', N'a', N'American', CAST(N'2025-04-04T00:00:00.000' AS DateTime), 3, 0, 0, N'q', N'complete', 3, N'english', CAST(5745.00 AS Decimal(18, 2)), N'SESSION0002591240184E19053086I6', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1038 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'121', N'amrheshmat95@gmail.com', N'a', N'Belizean', CAST(N'2025-03-14T00:00:00.000' AS DateTime), 1, 0, 0, N'test pick', NULL, 1, N'english', CAST(1950.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1039 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'121', N'amrheshmat95@gmail.com', N'a', N'Albanian', CAST(N'2025-04-04T00:00:00.000' AS DateTime), 1, 1, 0, N'test pick', N'complete', 1, N'english', CAST(2540.00 AS Decimal(18, 2)), N'SESSION0002244546709N96371208F3', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1040 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'121', N'amrheshmat95@gmail.com', N'a', N'Beninese', CAST(N'2025-04-04T00:00:00.000' AS DateTime), 2, 1, 0, N'test pick', N'complete', 2, N'english', CAST(4550.00 AS Decimal(18, 2)), N'SESSION0002917580594N98501971G9', N'', NULL)
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1041 AS Decimal(18, 0)), CAST(42 AS Decimal(18, 0)), N'121', N'amrheshmat95@gmail.com', N'a', N'Bosnian', CAST(N'2025-04-04T00:00:00.000' AS DateTime), 1, 0, 0, N'test pick', N'complete', 1, N'english', CAST(1950.00 AS Decimal(18, 2)), N'SESSION0002208144293K99827431I0', N'', N'1 single ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1042 AS Decimal(18, 0)), CAST(41 AS Decimal(18, 0)), N'0100', N'rehamhegazi676@gmail.com', N'amr', N'Beninese', CAST(N'2025-05-07T00:00:00.000' AS DateTime), 2, 1, 0, N'test', N'complete', 2, N'english', CAST(4842.00 AS Decimal(18, 2)), N'SESSION0002340149056G30314808N9', N'', N'1 single ,1 single + child ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1043 AS Decimal(18, 0)), CAST(41 AS Decimal(18, 0)), N'0100', N'rehamhegazi676@gmail.com', N'amr', N'American', CAST(N'2025-04-09T00:00:00.000' AS DateTime), 2, 1, 0, N'rew', N'complete', 2, N'english', CAST(4772.00 AS Decimal(18, 2)), N'SESSION0002183781099J84400233N1', N'', N'1 single ,1 single + child ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1044 AS Decimal(18, 0)), CAST(41 AS Decimal(18, 0)), N'0100', N'rehamhegazi676@gmail.com', N'amr', N'Beninese', CAST(N'2025-04-09T00:00:00.000' AS DateTime), 3, 1, 0, N'test pick', N'complete', 2, N'english', CAST(5706.00 AS Decimal(18, 2)), N'SESSION0002833642049I9436960K75', N'', N'1 single ,1 double + child ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1045 AS Decimal(18, 0)), CAST(41 AS Decimal(18, 0)), N'0100', N'rehamhegazi676@gmail.com', N'amr', N'Beninese', CAST(N'2025-05-14T00:00:00.000' AS DateTime), 3, 0, 0, N'test pick', N'complete', 2, N'english', CAST(4806.00 AS Decimal(18, 2)), N'SESSION0002168171089L7481404E53', N'', N'1 single ,1 double ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1046 AS Decimal(18, 0)), CAST(41 AS Decimal(18, 0)), N'0100', N'rehamhegazi676@gmail.com', N'amr', N'American', CAST(N'2025-03-12T00:00:00.000' AS DateTime), 2, 1, 0, N'test pick', N'complete', 1, N'english', CAST(3390.00 AS Decimal(18, 2)), N'SESSION0002937260032H2385607F59', N'', N'1 double + child ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1047 AS Decimal(18, 0)), CAST(41 AS Decimal(18, 0)), N'0100', N'rehamhegazi676@gmail.com', N'amr', N'Bangladeshi', CAST(N'2025-04-02T00:00:00.000' AS DateTime), 2, 0, 0, N'pick test', N'complete', 2, N'english', CAST(4142.00 AS Decimal(18, 2)), N'SESSION0002368120218M8149806K96', N'', N'2 single ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1048 AS Decimal(18, 0)), CAST(41 AS Decimal(18, 0)), N'0100', N'rehamhegazi676@gmail.com', N'amr', N'American', CAST(N'2025-04-09T00:00:00.000' AS DateTime), 2, 0, 0, N'rew', N'complete', 2, N'english', CAST(4032.00 AS Decimal(18, 2)), N'SESSION0002412847942F3589110G05', N'', N'2 single ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1049 AS Decimal(18, 0)), CAST(41 AS Decimal(18, 0)), N'0100', N'amrheshmat95@gmail.com', N'amr', N'American', CAST(N'2025-04-09T00:00:00.000' AS DateTime), 1, 0, 0, N'pick test', N'complete', 1, N'english', CAST(2016.00 AS Decimal(18, 2)), N'SESSION0002495429878H2283297K38', N'', N'1 single ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1050 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'0100', N'rehamhegazi676@gmail.com', N'amr', N'American', CAST(N'2025-04-04T00:00:00.000' AS DateTime), 2, 0, 0, N'test pick', N'complete', 2, N'english', CAST(3830.00 AS Decimal(18, 2)), N'SESSION0002323250441K7510993N17', N'', N'2 single ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1051 AS Decimal(18, 0)), CAST(41 AS Decimal(18, 0)), N'0100', N'amrheshmat95@gmail.com', N'amr', N'American', CAST(N'2025-04-02T00:00:00.000' AS DateTime), 1, 0, 0, N'test pick', N'complete', 1, N'english', CAST(2076.00 AS Decimal(18, 2)), N'SESSION0002834117030I0199378M91', N'', N'1 single ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1052 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'0100', N'amrheshmat95@gmail.com', N'amr', N'American', CAST(N'2025-04-04T00:00:00.000' AS DateTime), 2, 0, 0, N'test pick', N'complete', 2, N'english', CAST(3960.00 AS Decimal(18, 2)), N'SESSION0002228214625I8675351J20', N'', N'2 single ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1053 AS Decimal(18, 0)), CAST(43 AS Decimal(18, 0)), N'+12513095985', N'mostafaalymostafa91@gmail.com', N'Andrew', N'Bangladeshi', CAST(N'2025-03-08T00:00:00.000' AS DateTime), 1, 0, 0, N'luxor ', N'complete', 1, N'english', CAST(2.00 AS Decimal(18, 2)), N'SESSION0002382016758K08512372G0', N'', N'1 single ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1054 AS Decimal(18, 0)), CAST(43 AS Decimal(18, 0)), N'+12513095985', N'mostafaalymostafa91@gmail.com', N'Andrew', N'Austrian', CAST(N'2025-03-15T00:00:00.000' AS DateTime), 1, 0, 0, N'luxor ', NULL, 1, N'english', CAST(600.00 AS Decimal(18, 2)), NULL, NULL, N'1 single ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1055 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'01003051936', N'amrheshmat95@gmail.com', N'amr heshmat', N'Bhutanese', CAST(N'2025-03-07T00:00:00.000' AS DateTime), 1, 1, 0, N'a', NULL, 1, N'english', CAST(2515.00 AS Decimal(18, 2)), NULL, NULL, N'1 single + child ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1056 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'01003051936', N'amrheshmat95@gmail.com', N'amr heshmat', N'Beninese', CAST(N'2025-04-04T00:00:00.000' AS DateTime), 1, 0, 0, N'a', NULL, 1, N'english', CAST(1890.00 AS Decimal(18, 2)), NULL, NULL, N'1 single ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1057 AS Decimal(18, 0)), CAST(43 AS Decimal(18, 0)), N'+12513095985', N'mostafaalymostafa91@gmail.com', N'Andrew', N'Armenian', CAST(N'2025-03-15T00:00:00.000' AS DateTime), 1, 0, 0, N'luxor ', N'cancel', 1, N'english', CAST(600.00 AS Decimal(18, 2)), N'SESSION0002839021328G4886736M85', N'', N'1 single ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1058 AS Decimal(18, 0)), CAST(35 AS Decimal(18, 0)), N'+12513095985', N'mostafaalymostafa91@gmail.com', N'Andrew', N'Austrian', CAST(N'2025-03-14T00:00:00.000' AS DateTime), 1, 0, 0, N'luxor ', NULL, 1, N'english', CAST(1890.00 AS Decimal(18, 2)), NULL, NULL, N'1 single ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1059 AS Decimal(18, 0)), CAST(36 AS Decimal(18, 0)), N'01116660327', N'techhossamwork@gmail.com', N'TecHossam', N'American', CAST(N'2025-03-31T00:00:00.000' AS DateTime), 2, 1, 0, N'123', NULL, 1, N'english', CAST(3210.00 AS Decimal(18, 2)), NULL, NULL, N'1 double + child ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1060 AS Decimal(18, 0)), CAST(36 AS Decimal(18, 0)), N'01116660327', N'techhossamwork@gmail.com', N'TecHossam', N'American', CAST(N'2025-03-17T00:00:00.000' AS DateTime), 2, 1, 0, N'123', NULL, 1, N'english', CAST(3210.00 AS Decimal(18, 2)), NULL, NULL, N'1 double + child ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(1061 AS Decimal(18, 0)), CAST(41 AS Decimal(18, 0)), N'q121', N'amrheshmat95@gmail.com', N'test anoush', N'American', CAST(N'2025-05-14T00:00:00.000' AS DateTime), 1, 0, 0, N'sd', NULL, 1, N'english', CAST(2016.00 AS Decimal(18, 2)), NULL, NULL, N'1 single ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(11053 AS Decimal(18, 0)), CAST(42 AS Decimal(18, 0)), N'01003051936', N'amrheshmat95@gmail.com', N'amr heshmat', N'American', CAST(N'2025-03-07T00:00:00.000' AS DateTime), 1, 0, 0, N'اا', NULL, 1, N'english', CAST(1860.00 AS Decimal(18, 2)), NULL, NULL, N'1 single ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(11055 AS Decimal(18, 0)), CAST(42 AS Decimal(18, 0)), N'01027052000', N'mmohamady@techvillageco.com', N'Mohamed El Mohamady', N'American', CAST(N'2025-03-07T00:00:00.000' AS DateTime), 1, 0, 0, N'cairo', NULL, 1, N'english', CAST(1860.00 AS Decimal(18, 2)), NULL, NULL, N'1 single ')
INSERT [dbo].[booking] ([requestId], [tourId], [phone], [email], [name], [countryName], [tourDate], [numberOfAdult], [numberOfChild], [numberOfInfant], [pickup], [status], [numberOfRoom], [languageName], [totalPrice], [sessionReference], [paymentErrorDesc], [roomType]) VALUES (CAST(11056 AS Decimal(18, 0)), CAST(42 AS Decimal(18, 0)), N'01027052000', N'mmohamady@techvillageco.com', N'Mohamed El Mohamady', N'American', CAST(N'2025-03-07T00:00:00.000' AS DateTime), 1, 0, 0, N'cairo', N'complete', 1, N'english', CAST(1860.00 AS Decimal(18, 2)), N'SESSION0002168744746H46208063E7', N'', N'1 single ')
SET IDENTITY_INSERT [dbo].[booking] OFF
GO
SET IDENTITY_INSERT [dbo].[contacts] ON 

INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(1 AS Decimal(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(2 AS Decimal(18, 0)), N'q', N'q', N'q', N'q', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(3 AS Decimal(18, 0)), N'qe', N'e', N'e', N'qe', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(4 AS Decimal(18, 0)), N'q', N'ww', N'wwwww', N'w', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(5 AS Decimal(18, 0)), N'q', N'w1', N'w', N'r', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(6 AS Decimal(18, 0)), N'q', N'w1', N'w', N'r', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(7 AS Decimal(18, 0)), N'te', N're', N're', N're', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(8 AS Decimal(18, 0)), N'h', N'h', N'h', N'h', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(12 AS Decimal(18, 0)), N'1', N'2', N'5', N'5', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(13 AS Decimal(18, 0)), N'o', N'o', N'o', N'o', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(10002 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat@gmail.com', N'0595959549', N'test amr heshmat', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(10003 AS Decimal(18, 0)), N'yasser mahmoud', N'yasserah9595@gmail.com', N'77', N'77', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(10004 AS Decimal(18, 0)), N'yasser mahmoud', N'yasserah9595@gmail.com', N'77', N'asa', 7, 7, 7)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(10005 AS Decimal(18, 0)), N'yasser mahmoud', N'yasserah9595@gmail.com', N'77', N'sa', 7, 7, 7)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(10006 AS Decimal(18, 0)), N'q', N'yasserah9595@gmail.com', N'2252544040', N'4', 4, 4, 4)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(10007 AS Decimal(18, 0)), N'yasser mahmoud', N'yasserah9595@gmail.com', N'0595959549', N'i need new request', 4, 4, 4)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(10009 AS Decimal(18, 0)), N'yasserah9595', N'yasserah9595@gmail.com', N'2252544040', N'dsa
dasd
dass', 2, 2, 3)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(10010 AS Decimal(18, 0)), N'yasser mahmoud', N'yasserah9595@gmail.com', N'0595959549', N'33', 3, 3, 3)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(10013 AS Decimal(18, 0)), N'تركي محمد احمد باوزير', N'amrheshmat@gmail.com', N'0595959549', N'da', 7, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(20002 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'test', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(20003 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'test', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(20004 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'11', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(20005 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'1', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(20006 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'1', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(20007 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'1', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(20008 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'1', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(20009 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'1', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(20010 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'test', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(20011 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'1', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(20012 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'1', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(20013 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'dd', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(20014 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'1', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30003 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'aaa', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(9 AS Decimal(18, 0)), N'k', N'k', N'k', N'k', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(10 AS Decimal(18, 0)), N'k', N'k', N'k', N'k', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(11 AS Decimal(18, 0)), N'p', N'p', N'p', N'p', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(14 AS Decimal(18, 0)), N'7', N'1', N'01003051936', N'7', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(15 AS Decimal(18, 0)), N'q', N'q', N'1', N'w', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(16 AS Decimal(18, 0)), N't', N'test@gmail.com', N'7', N't', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(17 AS Decimal(18, 0)), N't', N'te', N'7', N't', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(18 AS Decimal(18, 0)), N'1', N'1', N'2', N'2', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(10008 AS Decimal(18, 0)), N'yasser mahmoud', N'yasserah9595@gmail.com', N'0595959549', N'wwwwwwwwwwwwwwwwwwwwwwwww
aaaaaaaaaaaaaaa', 2, 2, 2)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(10014 AS Decimal(18, 0)), N'amrheshmat', N'amrheshmat95@gmail.com', N'01003051936', N'i want to make special tour with you.', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(10011 AS Decimal(18, 0)), N'تركي محمد احمد باوزير', N'amrheshmat@gmail.com', N'0595959549', N'sadklsa', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(10012 AS Decimal(18, 0)), N'تركي محمد احمد باوزير', N'amrheshmat@gmail.com', N'0595959549', N'asdawew', 1, 22, 2)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(20015 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'test', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(20016 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'test', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30004 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'فثسف', 1, 2, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30005 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'فثسف', 1, 2, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30006 AS Decimal(18, 0)), N'q', N'yasserah9595@gmail.com', N'2252544040', N'ثثصص', 2, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30010 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'1q', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30011 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'tyuuu', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30013 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'tretre', 2, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30014 AS Decimal(18, 0)), N'amrheshmat', N'amrheshmat95@gmail.com', N'01003051936', N'test', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30015 AS Decimal(18, 0)), N'تركي محمد احمد باوزير', N'amrheshmat@gmail.com', N'0595959549', N'ww', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30016 AS Decimal(18, 0)), N'amrheshmat', N'amrheshmat95@gmail.com', N'01003051936', N'qwq', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30017 AS Decimal(18, 0)), N'amrheshmat', N'amrheshmat95@gmail.com', N'01003051936', N'as', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30018 AS Decimal(18, 0)), N'amrheshmat', N'amrheshmat95@gmail.com', N'01003051936', N'test', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30019 AS Decimal(18, 0)), N'amrheshmat', N'amrheshmat95@gmail.com', N'01003051936', N'test', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30021 AS Decimal(18, 0)), N'amrheshmat', N'amrheshmat95@gmail.com', N'01003051936', N'test1', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30024 AS Decimal(18, 0)), N'test', N'amrheshmat95@gmail.com', N'01003051936', N'test contact', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30027 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'test', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30028 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'test', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40024 AS Decimal(18, 0)), N'Salwa abd al ftah ', N'salwahere1@gmail.com', N'01026044358', N'i want to book 8 nights 
', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40027 AS Decimal(18, 0)), N'Salwa abd al ftah ', N'salwahere1@gmail.com', N'01026044358', N'hi contact me', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40028 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'1212', N'سيس', 2, 3, 2)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40029 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'1212', N'asa', 1, 1, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30007 AS Decimal(18, 0)), N'q', N'yasserah9595@gmail.com', N'2252544040', N'شس', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30008 AS Decimal(18, 0)), N'تركي محمد احمد باوزير', N'amrheshmat95@gmail.com', N'0595959549', N'ش', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30009 AS Decimal(18, 0)), N'amrheshmat', N'amrheshmat95@gmail.com', N'01003051936', N'ف', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30012 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'uyuy', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30020 AS Decimal(18, 0)), N'amrheshmat', N'amrheshmat95@gmail.com', N'01003051936', N'test', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40025 AS Decimal(18, 0)), N'Salwa abd al ftah ', N'salwahere1@gmail.com', N'01026044358', N'want to bbo dahaviya', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40026 AS Decimal(18, 0)), N'Salwa abd al ftah ', N'salwahere1@gmail.com', N'01026044358', N'want to book 10 nights', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40030 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'1212', N'as', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40031 AS Decimal(18, 0)), N'a', N'amrheshmat95@gmail.com', N'1212', N'ضثص', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40032 AS Decimal(18, 0)), N'شس', N'amrheshmat95@gmail.com', N'1212', N'ضصضص', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40033 AS Decimal(18, 0)), N'شس', N'amrheshmat95@gmail.com', N'1212', N'qwe2e', 1, 1, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40034 AS Decimal(18, 0)), N'شس', N'amrheshmat95@gmail.com', N'1212', N'qwqq', 1, 1, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40035 AS Decimal(18, 0)), N'شس', N'amrheshmat95@gmail.com', N'1212', N'asda', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40036 AS Decimal(18, 0)), N'Salwa abd al ftah ', N'lola12345abdo@gmail.com', N'01026044358', N'Is there an internet on the Dahabiya ', 2, 1, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40037 AS Decimal(18, 0)), N'Nayera', N'nairamohammed286@gmail.com', N'01285766571', N'Is there an internet on the Dahabiya ?', 2, 1, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40039 AS Decimal(18, 0)), N'dahabyia egypt1', N'lola12345abdo@gmail.com', N'01157553375', N' i need a detailed program for 2 night 3 day', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40044 AS Decimal(18, 0)), N'amr', N'rehamhegazi676@gmail.com', N'0100', N'test contact', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40045 AS Decimal(18, 0)), N'amr', N'amrheshmat95@gmail.com', N'0100', N'ree', 1, 0, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40046 AS Decimal(18, 0)), N'amr', N'amrheshmat95@gmail.com', N'0100', N'ssss', 1, 1, 1)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40047 AS Decimal(18, 0)), N'test anoush', N'amrheshmat95@gmail.com', N'2121', N'daewqaedas', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(50047 AS Decimal(18, 0)), N'Salwa abd al ftah ', N'salwahere1@gmail.com', N'01157553375', N'اىاهىعالالا بل ي', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(50048 AS Decimal(18, 0)), N'Salwa abd al ftah ', N'salwahere1@gmail.com', N'01157553375', N'hi my name is salws um 22 years old', NULL, NULL, NULL)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30022 AS Decimal(18, 0)), N'amrheshmat', N'amrheshmat95@gmail.com', N'01003051936', N'as', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30023 AS Decimal(18, 0)), N'amrheshmat', N'amrheshmat95@gmail.com', N'01003051936', N'as', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30025 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'test', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30026 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N't', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30029 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'test', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30030 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'ww', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(30031 AS Decimal(18, 0)), N'amr heshmat', N'amrheshmat95@gmail.com', N'01003051936', N'test', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40038 AS Decimal(18, 0)), N'Salwa abd al ftah ', N'lola12345abdo@gmail.com', N'01157553375', N'I need a detailed program for 2 nights 3 Days nile Dahabiya', 1, 0, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40040 AS Decimal(18, 0)), N'amr', N'rehamhegazi676@gmail.com', N'121', N'send', 1, 1, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40041 AS Decimal(18, 0)), N'a', N'rehamhegazi676@gmail.com', N'121', N're', 1, 1, 0)
GO
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40042 AS Decimal(18, 0)), N'a', N'rehamhegazi676@gmail.com', N'1254', N'jjkk', 1, 1, 0)
INSERT [dbo].[contacts] ([contactId], [name], [email], [phone], [message], [NumberOfAdult], [NumberOfChild], [numberOfInfant]) VALUES (CAST(40043 AS Decimal(18, 0)), N'a', N'rehamhegazi676@gmail.com', N'121', N'sfsada', 1, 1, 0)
SET IDENTITY_INSERT [dbo].[contacts] OFF
GO
INSERT [dbo].[days] ([dayId], [dayName]) VALUES (1, N'Mon')
INSERT [dbo].[days] ([dayId], [dayName]) VALUES (2, N'Tue')
INSERT [dbo].[days] ([dayId], [dayName]) VALUES (3, N'Wed')
INSERT [dbo].[days] ([dayId], [dayName]) VALUES (4, N'Thu')
INSERT [dbo].[days] ([dayId], [dayName]) VALUES (5, N'Fri')
INSERT [dbo].[days] ([dayId], [dayName]) VALUES (6, N'Sat')
INSERT [dbo].[days] ([dayId], [dayName]) VALUES (0, N'Sun')
GO
SET IDENTITY_INSERT [dbo].[excludes] ON 

INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70709 AS Decimal(18, 0)), N're', CAST(44 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70711 AS Decimal(18, 0)), N'j', CAST(45 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70892 AS Decimal(18, 0)), N'Entrance fees for the mentioned sites.

', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70893 AS Decimal(18, 0)), N'tipping(recommended)
', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70894 AS Decimal(18, 0)), N'Any thing did not mentioned in itinerary', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70865 AS Decimal(18, 0)), N'Entrance fees for the mentioned sites.', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70866 AS Decimal(18, 0)), N'tipping(recommended)', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70867 AS Decimal(18, 0)), N'Any thing did not mentioned in itinerary', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70868 AS Decimal(18, 0)), N'Entrance fees for the mentioned sites.', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70869 AS Decimal(18, 0)), N'tipping(recommended)', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70870 AS Decimal(18, 0)), N'Any thing did not mentioned in itinerary', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70871 AS Decimal(18, 0)), N'Entrance fees for the mentioned sites.
', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70872 AS Decimal(18, 0)), N'tipping(recommended)', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70873 AS Decimal(18, 0)), N'Any thing did not mentioned in itinerary', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70874 AS Decimal(18, 0)), N'Entrance fees for the mentioned sites.
', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70875 AS Decimal(18, 0)), N'tipping(recommended)', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70876 AS Decimal(18, 0)), N'Any thing did not mentioned in itinerary', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70877 AS Decimal(18, 0)), N'Entrance fees for the mentioned sites.', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70878 AS Decimal(18, 0)), N'tipping(recommended)', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70879 AS Decimal(18, 0)), N'Any thing did not mentioned in itinerary', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70883 AS Decimal(18, 0)), N'Entrance fees for the mentioned sites.

', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70884 AS Decimal(18, 0)), N'tipping(recommended)
', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70885 AS Decimal(18, 0)), N'Any thing did not mentioned in itinerary', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70889 AS Decimal(18, 0)), N'Entrance fees for the mentioned sites.

', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70890 AS Decimal(18, 0)), N'tipping(recommended)', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70891 AS Decimal(18, 0)), N'Any thing did not mentioned in itinerary', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70895 AS Decimal(18, 0)), N'Entrance fees for the mentioned sites.

', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70896 AS Decimal(18, 0)), N'tipping(recommended)', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[excludes] ([excludeId], [excludeText], [tourId]) VALUES (CAST(70897 AS Decimal(18, 0)), N'Any thing did not mentioned in itinerary', CAST(43 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[excludes] OFF
GO
SET IDENTITY_INSERT [dbo].[expects] ON 

INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(71620 AS Decimal(18, 0)), NULL, N'Disembark from Esna after your delicious breakfast.
<br><br>
Tour to west bank Valley of the kings Queen hatshepsut temple Colossi of Memnon (optional tour with extra charge upon your request)
<br><br>
A final transfer depends on your destination in Luxor but definitely with great memories and unique photos', CAST(44 AS Decimal(18, 0)), 1)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(71621 AS Decimal(18, 0)), NULL, N'While you are enjoying the sundeck we are going to reveal the secret of Genel El-Silsila.
( The mother of all temples where you can see the remains of the temples and tombs listen well to your tour guide and know the story of how only a chisel and hammer could cut the giant stones).
<br><br>
Your adventure is still alive by sailing towards one of the local villages to discover one of the most pure and natural areas where you can enjoy the stunning views,the daily life and touch the Egyptian simplicity in this village
<br><br>
Listen to the the Nile whispers and discover the Nile River secrets during sailing. 
<br><br>
Stop by Edfu temple ( to explore the second-largest temple in Egypt which is still in amazing condition until now Explore the land of victory to see the attractive story of how Horus defeated the evil god set ).
<br><br>
Sail over towards Luxor.
<br><br>
A unique and simple goodbye party from The Dahabiya staff will be operated onboard. 
<br><br>
Overnight Dahabiya.', CAST(44 AS Decimal(18, 0)), 2)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(71622 AS Decimal(18, 0)), NULL, N'Our representative will pick you up from Aswan hotel,train station or airport depending on your pick-up point in Aswan (pick up time should be maximum 7:30 am)
<br><br>
Transfer in comfort to your Nille Dahabiya. 
<br><br>
Enjoy your sailing and the natural views of the Nile River.
 <br><br>
Then stop to visit the Temple of Kom Ombo.
(let''s learn about Nubian culture this is a unique temple in that it has two identical gods, again one more attractive story of how the Egyptians avoided the danger of the crocodiles).
 <br><br>
Swimming in the Nile River is a unique and enjoyable experience and you can swim in a safe and warm area as you wish.
<br><br>
Enjoy your local Egyptian drink on cruise sun deck during sailing. 
<br><br>
Overnight Dahabiya.', CAST(44 AS Decimal(18, 0)), 4)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72081 AS Decimal(18, 0)), NULL, N'You will find our expert representative waiting for you, holding sign with your name at Cairo Airport.
<br>
<br>
Welcome to Cairo.
(The capital of Egypt and the Nile River, its heart is a country of seven wonders, enchanting places, and eternal monuments).
<br>
<br>
Overnight at Cairo Hotel.', CAST(41 AS Decimal(18, 0)), 1)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72082 AS Decimal(18, 0)), NULL, N'Enjoy your breakfast at your hotel. 
<br>
<br>
Are you ready to spend a unique day and visit the most important archaeological places in the world?
<br>
<br>
(Our amazing first tour will be Giza which holds one of the seven wonders of the world the Great Pyramids).
<br>
<br>
Move to see the biggest statue in the world, the Great Sphinx.
(That guards over the great pyramids in Egypt).
<br>
<br>
Now it is time to discover the oldest archaeological museum, the Egyptian Museum, which includes the largest collection of Egyptian antiquities in the world).
<br>
<br>
 After the amazing Cairo trip, drive to Cairo airport for your flight to Aswan. 
<br>
<br>
Arrive Aswan the beautiful city and the Nile bride located in upper Egypt.
<br>
<br>
 Overnight at Aswan hotel.', CAST(41 AS Decimal(18, 0)), 2)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72083 AS Decimal(18, 0)), NULL, N'Morning enjoy your breakfast at your hotel.
<br>
<br>
Visit the temple of Philae.
( the first thing that will catch your eye is, to say the least, it''s an architectural miracle from the time of our ancestors and enjoys the island of Philae in the middle of the Nile River).
<br>
<br>
Now time is coming to check in your Nile Dahabiya. 
<br>
<br>
Enjoy your handmade lunch onboard. 
<br>
<br>
Rest and refresh. 
<br>
<br>
Listen to your Expert tour guide who will explain by details the hidden culture of Egypt. 
<br>
<br>
Overnight Dahabiya. ', CAST(41 AS Decimal(18, 0)), 3)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72084 AS Decimal(18, 0)), NULL, N'Enjoy your sailing and the natural views of the Nile River.
 <br>
<br>
Then stop to visit the Temple of Kom Ombo.
(let''s learn about Nubian culture this is a unique temple in that it has two identical gods, again one more attractive story of how the Egyptians avoided the danger of the crocodiles).
 <br>
<br>
Swimming in the Nile River is a unique and enjoyable experience and you can swim in a safe and warm area as you wish.
<br>
<br>
Enjoy your local Egyptian drink on cruise sun deck during sailing. 
<br>
<br>
Overnight Dahabiya.', CAST(41 AS Decimal(18, 0)), 4)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72090 AS Decimal(18, 0)), NULL, N'Final transfer and upon your request drive in comfort to cairo airport or your destination in Cairo but definitely with memories will last forever. 
<br>
<br>
Have a nice trip', CAST(41 AS Decimal(18, 0)), 10)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72078 AS Decimal(18, 0)), NULL, N'Early morning we will drive in comfort from your hotel in Cairo to Oasis Bahariya, 
<br><br>
Bahariya is the nearest oasis to Cairo, surrounded by black hills made up of ferruginous quartzite and dolerite, and famous for its 398 mineral & sulfur springs, some of which have temperatures reaching up to 45 degrees and are famous for their healing effects.
<br><br>
Arrive in Bawiti the capital of the Oasis occupying a hillside. 
<br><br>
Enjoy your lunch then you will start your tour to visit the Black Desert surrounding Bahariya Oasis, where the iron in the desert is one of the reasons for the black rocks.
<br><br>
Camping and overnight at desert ', CAST(42 AS Decimal(18, 0)), 9)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72079 AS Decimal(18, 0)), NULL, N'Enjoy your breakfast. 
<br><br>
You will walk to explore Gabal el Marsos (Divided Mountain)
<br><br>
Then drive towards the small Bedouin village El Hez

Then Making your way to the White Desert 160-km on/off road, 
<br><br>
You will stop by the Crystal Mountain & Agabat el Sharkia, El Santa tree, 
<br><br>
Go across the sands of the White Desert with its chalky, cream landscape, and the wind carved mushroom-shaped formations that resemble both human and animal faces. 
<br><br>
Tonight you will watch the sunset over the exquisite sands of the desert, 
<br><br>
Dine under the stars and overnight in camping.', CAST(42 AS Decimal(18, 0)), 10)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72080 AS Decimal(18, 0)), NULL, N'Wake up from a peaceful night.
<br><br>
Breakfast and return all over the road across the White Desert.
<br><br>
Return to Bahariya, break and head off back to Cairo.
<br><br>
 Arrive to Cairo then Final transfer upon your request to cairo airport or your destination in Cairo but definitely with memories will last forever. 
<br><br>
Have a nice trip', CAST(42 AS Decimal(18, 0)), 11)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72085 AS Decimal(18, 0)), NULL, N'While you are enjoying the sundeck we are going to reveal the secret of Genel El-Silsila.
( The mother of all temples where you can see the remains of the temples and tombs listen well to your tour guide and know the story of how only a chisel and hammer could cut the giant stones).
<br>
<br>
Your adventure is still alive by sailing towards one of the local villages to discover one of the most pure and natural areas where you can enjoy the stunning views,
the daily life and touch the Egyptian simplicity in this village
<br>
<br>
Listen to the the Nile whispers and discover the Nile River secrets during sailing. 
<br>
<br>
Stop by Edfu temple ( to explore the second-largest temple in Egypt which is still in amazing condition until now Explore the land of victory to see the attractive story of how Horus defeated the evil god set ).
<br>
<br>
Sail over towards Luxor.
<br>
<br>
A unique and simple goodbye party from The Dahabiya staff will be operated onboard. 
<br>
<br>
Overnight Dahabiya.
', CAST(41 AS Decimal(18, 0)), 5)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72086 AS Decimal(18, 0)), NULL, N'Disembark from Esna after your delicious breakfast.
<br>
<br>
(open your eyes Now you are in Luxor which owns one-third of the world''s monuments ).
<br>
<br>
Visit the Valley of the Kings.
(Now you are in the most exciting and mysterious place that has more than 60 tombs, it''s not just burial cemeteries as everyone knows but palaces for the afterlife).
<br>
<br>
Move to visit the Mortuary Temple of Hatshepsut.
(Now come closer and see the queen who suffered a lot until she became the only Female pharaoh).
<br>
<br>
Our last tour will be the Memnon Statue.
(Now let us reveal the secret of the giant statue of Memnon and its mysterious voice).
<br>
<br>
After the fabulous luxor west bank tour Check-in at Luxor Hotel.
<br>
<br>
Today you have time to make an optional tours upon your requst with your expert guide.
<br>
<br>
Overnight Luxor hotel. ', CAST(41 AS Decimal(18, 0)), 6)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72091 AS Decimal(18, 0)), NULL, N'you will find our expert representative waiting for you holding sign with your name at Cairo Airport.
<br>
<br>
Welcome to Cairo
(The capital of Egypt and the Nile River, its heart is a country of seven wonders, enchanting places, and eternal monuments).
<br>
<br>
Overnight at Cairo Hotel.', CAST(35 AS Decimal(18, 0)), 1)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72092 AS Decimal(18, 0)), NULL, N'Are you ready to spend a unique day and visit the most important archaeological places in the world?
<br>
<br>
(Our amazing first tour will be Giza which holds one of the seven wonders of the world the Great Pyramids).
<br>
<br>
Move to see the biggest statue in the world, the Great Sphinx.
(That guards over the great pyramids in Egypt).
<br>
<br>
Now it is time to discover the oldest archaeological museum, the Egyptian Museum, which includes the largest collection of Egyptian antiquities in the world).
<br>
<br>
After the fabulous day tour drive in comfort to cairo airport for your flight to Luxor. 
<br>
<br>
Arrival in Luxor. 
(Open your eyes you are in Luxor which owns one-third of the world''s monuments).
<br>
<br>
Rest and Refresh 
<br>
<br>
Overnight at Luxor Hotel
', CAST(35 AS Decimal(18, 0)), 2)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72093 AS Decimal(18, 0)), NULL, N'Enjoy your breakfast at your hotel.
<br>
<br>
Cross the fabulous west bank of Luxor.
<br>
<br>
Visit the valley of the kings.
(Now you are in the most exciting and mysterious place that has more than 60 tombs, it is not just burial cemeteries as everyone knows but palaces for the afterlife).
<br>
<br>
Move to visit the mortuary temple of Hatshepsut.
(Now come closer and see the queen who suffered a lot until she became the only female pharaoh) .
<br>
<br>
Our last tour today will be the Memnon statue.
(  Now let us reveal the secret of the giant statue of Memnon and its mysterious voice) .
 <br>
<br>
After the west bank tour drive to check in your hotel.
<br>
<br>
Overnight hotel in Luxor.
', CAST(35 AS Decimal(18, 0)), 3)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72094 AS Decimal(18, 0)), NULL, N'Enjoy your open buffet breakfast at your hotel.
<br>
<br>
 Now the sun is shining with its golden rays while we are driving to the amazing Karnak temple.
( you will see with your own eyes where history comes alive, the Karnak temples are considered one of the greatest temples ever in Egypt) .
<br>
<br>
After Karnak temple drive to Esna.
<br>
<br>
Now time is coming to check in your Nille Dahabiya. 
<br>
<br>
Enjoy your handmade fresh lunch abroad.
<br>
<br>
Rest and refresh. 
<br>
<br>
Enjoy sailing and prepare yourself to have unique photos of the splendid Egyptian River Nile during sailing (unique islands, fields, gardens)
Pure nature is around you everywhere. 
<br>
<br>
Evening After dinner listen quit to your Expert tour guide who will give you a general idea about the hidden culture of Egypt. 
<br>
<br>

Overnight Dahabiya.
', CAST(35 AS Decimal(18, 0)), 4)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72095 AS Decimal(18, 0)), NULL, N'Breakfast during sailing is a great opportunity to discover the whispers of the immortal Egyptian River Nile. 
<br>
<br>
Stop by Edfu temple to explore the second largest temple in Egypt that is still in its amazing condition until now, Explore the land of victory to see the attractive story of how Horus defeats the evil god Set ).
<br>
<br>
Enjoy sailing and listen to the Nile secrets.
<br>
<br>
Your adventure is still alive by sailing towards one of the local villages to discover
 one of the most pure and natural areas where you can enjoy the stunning views,
the daily life and touch the Egyptian simplicity in this village
<br>
<br>
After the unique cultural tour back to your Nile Dahabiya. 
<br>
<br>
Enjoy an oriental party and Egyptian folklore music with an Egyptian band onboard.
 <br>
<br>
Overnight Dahabiya.', CAST(35 AS Decimal(18, 0)), 5)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72108 AS Decimal(18, 0)), NULL, N'You will find our expert representative waiting for you, holding sign with your name at Cairo Airport.
<br>
<br>
Welcome to Cairo.
(The capital of Egypt and the Nile River, its heart is a country of seven wonders, enchanting places, and eternal monuments).
<br>
<br>
Overnight at Cairo Hotel.', CAST(40 AS Decimal(18, 0)), 1)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72109 AS Decimal(18, 0)), NULL, N'Morning our friendly representative will pick you up from your hotel. 
<br>
<br>
Drive in comfort to cairo airport for your flight to Aswan. 
<br>
<br>
Arrive aswan the beautiful city and the Nile bride located in upper Egypt.
<br>
<br>
Visit the temple of Philae.
( The first thing that will catch your eye is, to say the least, it''s an architectural miracle from the time of our ancestors and enjoys the island of Philae in the middle of the Nile River).
<br>
<br>
Now time is coming to check in your Nile Dahabiya. 
<br>
<br>
Enjoy your handmade lunch on board. 
<br>
<br>
Rest and refresh. 
<br>
<br>
Listen to your Expert tour guide who will explain in details the hidden culture of Egypt. 
<br>
<br>
Overnight Dahabiya. 
', CAST(40 AS Decimal(18, 0)), 2)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72100 AS Decimal(18, 0)), NULL, N'You will find our expert representative waiting for you ,holding sign with your name at Cairo Airport.<br><br>
Welcome to Cairo.
(The capital of Egypt and the Nile River, its heart is a country of seven wonders, enchanting places, and eternal monuments).<br><br>
Overnight at Cairo Hotel.', CAST(37 AS Decimal(18, 0)), 1)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72101 AS Decimal(18, 0)), NULL, N'Are you ready to spend a unique day and visit the most important archaeological places in the world?<br><br>(Our amazing first tour will be Giza which holds one of the seven wonders of the world the Great Pyramids).<br><br>Move to see the biggest statue in the world, the Great Sphinx.
(That guards over the great pyramids in Egypt).<br><br>Now it is time to discover the oldest archaeological museum, the Egyptian Museum, which includes the largest collection of Egyptian antiquities in the world).<br><br>After the fabulous day tour drive in comfort to cairo airport for your flight to Aswan.<br><br>Arrival in Aswan.<br><br>Look around you, it is the bride of the Nile, Aswan, which is considered one of the most important landmarks in the world, and its true magic is its people, its Nubian culture, and its warm weather).<br><br>Overnight at Aswan Hotel.<br><br>', CAST(37 AS Decimal(18, 0)), 2)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72102 AS Decimal(18, 0)), NULL, N'Enjoy your breakfast at your hotel. <br><br>Then visit the temple of Philae.
( the first thing that will catch your eye is, to say the least, it''s an architectural miracle from the time of our ancestors and enjoys the island of Philae in the middle of the Nile River).<br><br>Now time is coming to check in your Nile Dahabiya. <br><br>Enjoy your handmade lunch onboard. <br><br>Rest and refresh. 
<br><br>
Listen to your Expert tour guide who will explain by details the hidden culture of Egypt. 
<br><br>
Overnight Dahabiya.', CAST(37 AS Decimal(18, 0)), 3)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72105 AS Decimal(18, 0)), NULL, N'Disembark from Esna after your delicious breakfast.
<br><br>
Now we are in Luxor one of the most historical cities in the world. 
<br><br>
Visit the Valley of the Kings.
(Now you are in the most exciting and mysterious place that has more than 60 tombs, it''s not just burial cemeteries as everyone knows but palaces for the afterlife).
<br><br>
Move to visit the mortuary temple of Hatshepsut.<br>
(Now come closer and see the queen who suffered a lot until she became the only female pharaoh) .
<br><br>
Our last tour today will be the Memnon statue.<br>
( Now let us reveal the secret of the giant statue of Memnon and its mysterious voice) .
<br><br>
After the fabulous west bank tour in luxor drive in comfort to your hotel in Luxor. 
<br><br>
Rest and refresh. 
<br><br>
Overnight at Luxor Hotel.', CAST(37 AS Decimal(18, 0)), 6)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72106 AS Decimal(18, 0)), NULL, N'Enjoy your breakfast at your hotel. 
<br><br>
Now the sun is shining with its golden rays while we are driving to the amazing Karnak temple.
( you will see with your own eyes where history comes alive, the Karnak temples are considered one of the greatest temples ever in Egypt) . 
<br><br>
After your unique tour drive in comfort to Luxor airport for your flight back to Cairo. 
 <br><br>
Arrive at Cairo Airport. 
<br><br>
Overnight at Cairo Hotel.', CAST(37 AS Decimal(18, 0)), 7)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72107 AS Decimal(18, 0)), NULL, N'After your breakfast at hotel and upon your request drive to your destination in Cairo or Cairo airport for your final departure with memories will last forever 
<br><br>
Have a nice trip', CAST(37 AS Decimal(18, 0)), 8)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72111 AS Decimal(18, 0)), NULL, N'While you are enjoying the sundeck we are going to reveal the secret of Gebel El-Silsila.
( The mother of all temples where you can see the remains of the temples and tombs listen well to your tour guide and know the story of how only a chisel and hammer could cut the giant stones).
<br>
<br>
Your adventure is still alive by sailing towards one of the local villages to discover one of the most pure and natural areas where you can enjoy the stunning views,
the daily life and touch the Egyptian simplicity in this village
<br>
<br>
Listen to the the Nile whispers and discover the Nile River secrets during sailing. 
<br>
<br>
Stop by Edfu temple ( to explore the second-largest temple in Egypt which is still in amazing condition until now Explore the land of victory to see the attractive story of how Horus defeated the evil god set ).
<br>
<br>
Sail over towards Luxor.
<br>
<br>
A unique and simple goodbye party from The Dahabiya staff will be operated onboard. 
<br>
<br>
Overnight Dahabiya.', CAST(40 AS Decimal(18, 0)), 4)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72112 AS Decimal(18, 0)), NULL, N'Disembark from Esna after your delicious breakfast.
<br>
<br>
(open your eyes Now you are in Luxor which owns one-third of the world''s monuments ).
<br>
<br>
Visit the Valley of the Kings.
(Now you are in the most exciting and mysterious place that has more than 60 tombs, it''s not just burial cemeteries as everyone knows but palaces for the afterlife).
<br>
<br>
Move to visit the Mortuary Temple of Hatshepsut.
(Now come closer and see the queen who suffered a lot until she became the only Female pharaoh).
<br>
<br>
Our last tour in the west bank will be the Memnon Statue.
(Now let us reveal the secret of the giant statue of Memnon and its mysterious voice).
<br>
<br>
 
Cross the east bank of Luxor to visit Karnak temple. 
(you will see with your own eyes where history comes alive, the Karnak temples are considered one of the greatest temples ever in Egypt).
<br>
<br>
After the fabulous tours in Luxor Transfer by A/C private car to Hurghada. 
<br>
<br>
Arrive to Hurghada the charming city located on the red sea. 
<br>
<br>
Overnight Hurghada hotel.', CAST(40 AS Decimal(18, 0)), 5)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72143 AS Decimal(18, 0)), NULL, N'Our representative will pick you up from Aswan hotel,train station or airport depending on your pick-up point in Aswan (pick up time should be maximum 7:30 am)
<br><br>
Transfer in comfort to your Nille Dahabiya. 
<br><br>
Enjoy your sailing and the natural views of the Nile River.
 <br><br>
Then stop to visit the Temple of Kom Ombo.
(let''s learn about Nubian culture this is a unique temple in that it has two identical gods, again one more attractive story of how the Egyptians avoided the danger of the crocodiles).
 <br><br>
Swimming in the Nile River is a unique and enjoyable experience and you can swim in a safe and warm area as you wish.
<br><br>
Enjoy your local Egyptian drink on cruise sun deck during sailing. 
<br><br>
Overnight Dahabiya.', CAST(43 AS Decimal(18, 0)), 1)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72070 AS Decimal(18, 0)), NULL, N'You will find our expert
 representative waiting for you, holding sign with your name at Cairo Airport.
<br/>
<br/>
Welcome to Cairo.
(The capital of Egypt and the Nile River, its heart is a country of seven wonders, enchanting places, and eternal monuments).
<br/><br/>
Overnight at Cairo Hotel.', CAST(42 AS Decimal(18, 0)), 1)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72071 AS Decimal(18, 0)), NULL, N'Enjoy your breakfast at your hotel. 
<br/>
Are you ready to spend a unique day and visit the most important archaeological places in the world?
<br/><br/>
(Our amazing first tour will be Giza which holds one of the seven wonders of the world the Great Pyramids).
<br/><br/>
Move to see the biggest statue in the world, the Great Sphinx.
(That guards over the great pyramids in Egypt).
<br/><br/>
Now it is time to discover the oldest archaeological museum, the Egyptian Museum, which includes the largest collection of Egyptian antiquities in the world).
<br/><br/>
 After the amazing Cairo trip, drive to Cairo airport for your flight to Luxor. 
<br/><br/>
Arrive Luxor the most famous historical city in Egypt. 
<br/><br/>
Overnight at Luxor hotel.', CAST(42 AS Decimal(18, 0)), 2)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72072 AS Decimal(18, 0)), NULL, N'(Open your eyes you are in Luxor which owns one-third of the world''s monuments ) .
<br><br>
Cross the fabulous west bank of Luxor.
<br><br>
Visit the valley of the kings.
(Now you are in the most exciting and mysterious place that has more than 60 tombs, it is not just burial cemeteries as everyone knows but palaces for the afterlife).
<br><br>
Move to visit the mortuary temple of Hatshepsut.<br>
(Now come closer and see the queen who suffered a lot until she became the only female pharaoh) .<br><br>

Our last tour today will be the Memnon statue.
( Now let us reveal the secret of the giant statue of Memnon and its mysterious voice) .
 <br><br>
Back to the hotel to rest and Refresh. 
<br><br>
Today you have time to do optional tours with your expert tour guide. 
<br><br>
Overnight hotel in Luxor.', CAST(42 AS Decimal(18, 0)), 3)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72076 AS Decimal(18, 0)), NULL, N'Arrive in Aswan the beautiful and amazing city famous for its Nubian history and the city which has a lot to offer.
<br><br>
Visit the love place The Temple of Philae.<br><br>
(The first thing that will catch your eye is the most famous legends of love and loyalty).
<br><br>
Evening simple departure party will be operated by the cruise staff 
<br><br>
Overnight Dahabiya', CAST(42 AS Decimal(18, 0)), 7)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72077 AS Decimal(18, 0)), NULL, N'Disembark from your nile Dahabiya after breakfast. 
<br><br>
You can discover one of the most important temples in Egypt which is Abu simbel temple (optional trip with extra cost upon your request)
<br><br>
Drive in comfort to aswan Airport for your flight back to Cairo .
<br><br>
Overnight hotel in Cairo ', CAST(42 AS Decimal(18, 0)), 8)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72087 AS Decimal(18, 0)), NULL, N'Enjoy your open buffet breakfast at your hotel. 
 <br>
<br>
Now the sun is shining with its golden rays while we are driving to the amazing Karnak temple. 
(you will see with your own eyes where history comes alive, the Karnak temples are considered one of the greatest temples ever in Egypt).
<br>
<br>
After the fabulous tours in Luxor Transfer by A/C car to Hurghada. 
<br>
<br>
Arrive at Hurghada the charming city located on the red sea. 
<br>
<br>
Overnight Hurghada hotel.', CAST(41 AS Decimal(18, 0)), 7)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72088 AS Decimal(18, 0)), NULL, N'(Look around you, you are now in the city of Hurghada, which is distinguished by its beautiful turquoise beaches with white sand, colorful fish, coral reefs, stunning landscapes and islands).
<br>
<br>
Snorkeling is the most wonderful and best way to explore the underwater world in Hurghada,the Red sea''s coral reefs and relax while you can see these beautiful views. 
<br>
<br>
Overnight Hurghada hotel.', CAST(41 AS Decimal(18, 0)), 8)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72121 AS Decimal(18, 0)), NULL, N'Morning your expert representative will pick you up from Aswan Airport, station, or your hotel in Aswan depending on your pick-up point.
<br>
<br>
Visit the temple of Philae.
( the first thing that will catch your eye is, to say the least, it''s an architectural miracle from the time of our ancestors and enjoys the island of Philae in the middle of the Nile River).
<br>
<br>
Now time is coming to check in your Nile Dahabiya. 
<br>
<br>
Enjoy your handmade lunch onboard. 
<br>
<br>
Rest and refresh. 
<br>
<br>
Listen to your Expert tour guide who will explain by details the hidden culture of Egypt. 
<br>
<br>
Overnight Dahabiya. 
', CAST(29 AS Decimal(18, 0)), 1)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72122 AS Decimal(18, 0)), NULL, N'Enjoy your sailing and the natural views of the Nile River.
 <br>
<br>
Then stop to visit the Temple of Kom Ombo.
(let''s learn about Nubian culture this is a unique temple in that it has two identical gods, again one more attractive story of how the Egyptians avoided the danger of the crocodiles).
  <br>
<br>
Swimming in the Nile River is a unique and enjoyable experience and you can swim in a safe and warm area as you wish.
 <br>
<br>
Enjoy your local Egyptian drink on cruise sun deck during sailing. 
 <br>
<br>
Overnight Dahabiya.', CAST(29 AS Decimal(18, 0)), 2)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72123 AS Decimal(18, 0)), NULL, N'While you are enjoying the sundeck we are going to reveal the secret of Gebel El-Silsila.
( The mother of all temples where you can see the remains of the temples and tombs listen well to your tour guide and know the story of how only a chisel and hammer could cut the giant stones).
<br>
<br>
Listen to the Nile whispers and discover the Nile River secrets during sailing. 
<br>
<br>
Your adventure is still alive by sailing towards one of the local villages 
to discover one of the most pure and natural areas where you can enjoy the stunning views,
the daily life and touch the Egyptian simplicity in this village
<br>
<br>
Stop by Edfu temple ( to explore the second-largest temple in Egypt which is still in amazing condition until now Explore the land of victory to see the attractive story of how Horus defeated the evil god set ).
<br>
<br>
Sail over towards Luxor.
<br>
<br>
A unique and simple goodbye party from The Dahabiya staff will be operated onboard. 

Overnight Dahabiya.
', CAST(29 AS Decimal(18, 0)), 3)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72124 AS Decimal(18, 0)), NULL, N'Check out from Esna after your delicious breakfast.
<br>
<br>
(open your eyes Now you are in Luxor which owns one-third of the world''s monuments ).
<br>
<br>
Visit the Valley of the Kings.
(Now you are in the most exciting and mysterious place that has more than 60 tombs, it''s not just burial cemeteries as everyone knows but palaces for the afterlife).
<br>
<br>
Move to visit the Mortuary Temple of Hatshepsut.
(Now come closer and see the queen who suffered a lot until she became the only Female pharaoh).
<br>
<br>
Our last tour will be the Memnon Statue.
(Now let us reveal the secret of the giant statue of Memnon and its mysterious voice).
<br>
<br>
After the fabulous luxor west bank tour Check-in at Luxor Hotel.
<br>
<br>
Today you have time to make an optional tours upon your requst with your expert guide.
<br>
<br>
Overnight Luxor hotel. 
', CAST(29 AS Decimal(18, 0)), 4)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72136 AS Decimal(18, 0)), NULL, N'Disembark from Esna after your delicious breakfast.
<br>
<br>
Now we are in Luxor again one of the most historical cities in the world. 
<br>
<br>
Visit the Valley of the Kings.
(Now you are in the most exciting and mysterious place that has more than 60 tombs, it''s not just burial cemeteries as everyone knows but palaces for the afterlife).
<br>
<br>
Move to visit the mortuary temple of Hatshepsut.
(Now come closer and see the queen who suffered a lot until she became the only female pharaoh) .
<br>
<br>
Our last tour today will be the Memnon statue.
( Now let us reveal the secret of the giant statue of Memnon and its mysterious voice) .
<br>
<br>
 Finally, transfer to your destination in Luxor but of course with unique photos and unforgettable memories. 
<br>
<br>
Have a nice trip.', CAST(36 AS Decimal(18, 0)), 8)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72113 AS Decimal(18, 0)), NULL, N'(Look around you, you are now in the city of Hurghada, which is distinguished by its beautiful turquoise beaches with white sand, colorful fish, coral reefs, stunning landscapes and islands).
<br>
<br>
And Snorkeling is the most wonderful and best way to explore the underwater world in Hurghada,the Red sea''s coral reefs and relax while you can see these beautiful views.
<br>
<br>
 After the trip ends drive to Hurghada airport for your flight back to Cairo. 
<br>
<br>
 Overnight at Cairo hotel.', CAST(40 AS Decimal(18, 0)), 6)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72114 AS Decimal(18, 0)), NULL, N'Enjoy your breakfast at your hotel. 
<br>
<br>
Are you ready to spend a unique day and visit the most important archaeological places in the world?
<br>
<br>
(Our amazing first tour will be Giza which holds one of the seven wonders of the world the Great Pyramids).
<br>
<br>
Move to see the biggest statue in the world, the Great Sphinx.
(That guards over the great pyramids in Egypt).
<br>
<br>
Now it is time to discover the oldest archaeological museum, the Egyptian Museum, which includes the largest collection of Egyptian antiquities in the world).
<br>
<br>
After the amazing day tour in Cairo and upon your request drive in comfort to cairo airport or your destination in Cairo but definitely with splendid memories and unique photos. 
<br>
<br>
Have a nice trip', CAST(40 AS Decimal(18, 0)), 7)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72125 AS Decimal(18, 0)), NULL, N'Enjoy your open buffet breakfast at your hotel. 
 <br>
<br>
Now the sun is shining with its golden rays while we are driving to the amazing Karnak temple. 
(you will see with your own eyes where history comes alive, the Karnak temples are considered one of the greatest temples ever in Egypt).
<br>
<br>
A final transfer depends on your destination in Luxor but definitely with great memories and unique photos.
<br><br>
Have a nice trip 
', CAST(29 AS Decimal(18, 0)), 5)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72144 AS Decimal(18, 0)), NULL, N'While you are enjoying the sundeck we are going to reveal the secret of Gebel El-Silsila.
( The mother of all temples where you can see the remains of the temples and tombs listen well to your tour guide and know the story of how only a chisel and hammer could cut the giant stones).
<br><br>
Your adventure is still alive by sailing towards one of the local villages to discover one of the most pure and natural areas where you can enjoy the stunning views,the daily life and touch the Egyptian simplicity in this village
<br><br>
Listen to the the Nile whispers and discover the Nile River secrets during sailing. 
<br><br>
Stop by Edfu temple ( to explore the second-largest temple in Egypt which is still in amazing condition until now Explore the land of victory to see the attractive story of how Horus defeated the evil god set ).
<br><br>
Sail over towards Luxor.
<br><br>
A unique and simple goodbye party from The Dahabiya staff will be operated onboard. 
<br><br>
Overnight Dahabiya.', CAST(43 AS Decimal(18, 0)), 2)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72145 AS Decimal(18, 0)), NULL, N'Disembark from Esna after your delicious breakfast.
<br><br>
Tour to west bank Valley of the kings Queen hatshepsut temple Colossi of Memnon (optional tour with extra charge upon your request)
<br><br>
A final transfer depends on your destination in Luxor but definitely with great memories and unique photos.
<br><br>
Have a nice trip', CAST(43 AS Decimal(18, 0)), 3)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(71626 AS Decimal(18, 0)), NULL, N'1', CAST(45 AS Decimal(18, 0)), 1)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(71627 AS Decimal(18, 0)), NULL, N'٤٣<br>
Sfg', CAST(45 AS Decimal(18, 0)), 5)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72137 AS Decimal(18, 0)), NULL, N'Morning your expert representative will pick you up from Luxor airport, station, or your hotel in Luxor depending on your pick-up point. 
<br>
<br>
(Open your eyes you are in Luxor which owns one-third of the world''s monuments ) .
<br>
<br>
Cross the fabulous west bank of Luxor.
<br>
<br>
Visit the valley of the kings.
(Now you are in the most exciting and mysterious place that has more than 60 tombs, it is not just burial cemeteries as everyone knows but palaces for the afterlife).
<br>
<br>
Move to visit the mortuary temple of Hatshepsut.
(Now come closer and see the queen who suffered a lot until she became the only female pharaoh) 
.<br>
<br>
Our last tour today will be the Memnon statue.
(  Now let us reveal the secret of the giant statue of Memnon and its mysterious voice) .
<br>
<br>
After the west bank tour drive to check in your hotel.
<br>
<br>

Overnight hotel in Luxor.', CAST(34 AS Decimal(18, 0)), 1)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72138 AS Decimal(18, 0)), NULL, N'Enjoy your open buffet breakfast at your hotel.
<br>
<br>
Now the sun is shining with its golden rays while we are driving to the amazing Karnak temple.
( you will see with your own eyes where history comes alive, the Karnak temples are considered one of the greatest temples ever in Egypt) .
<br>
<br>
After Karnak temple drive to Esna.
<br>
<br>
Now time is coming to check in your Nile Dahabiya. 
<br>
<br>
Enjoy your handmade fresh lunch abroad.
<br>
<br>
Rest and refresh. 
<br>
<br>
Enjoy sailing and prepare yourself to have unique photos of the splendid Egyptian River Nile during sailing (unique islands, fields, gardens)
Pure nature is around you everywhere. 
<br>
<br>
Evening After dinner listen quit to your Expert tour guide who will give you a general idea about the hidden culture of Egypt. 
<br>
<br>
Overnight Dahabiya.
', CAST(34 AS Decimal(18, 0)), 2)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72139 AS Decimal(18, 0)), NULL, N'Breakfast during sailing is a great opportunity to discover the whispers of the immortal Egyptian River Nile. 
<br>
<br>
Stop by Edfu temple to explore the second largest temple in Egypt that is still in its amazing condition until now, Explore the land of victory to see the attractive story of how Horus defeats the evil god Set ).
<br>
<br>
Enjoy sailing and listen to the Nile secrets.
<br>
<br>
Your adventure is still alive by sailing towards one of the local villages 
to discover one of the most pure and natural areas where you can enjoy the stunning views,
the daily life and touch the Egyptian simplicity in this village
<br>
<br>
After the unique cultural tour back to your Nile Dahabiya. 
<br>
<br>
Enjoy an oriental party and Egyptian folklore music with an Egyptian band onboard.
 <br>
<br>
Overnight Dahabiya.', CAST(34 AS Decimal(18, 0)), 3)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72140 AS Decimal(18, 0)), NULL, N'While we''re enjoying the sundeck we are going to reveal the secret of Gebel El-Silsila.
(The mother of all temples where you can see the remains of the temples and tombs, listen well to your tour guide and know the story of how Only a chisel and a hammer could cut the giant stones).
<br>
<br>
Back to your Nile Dahabiya. 
<br>
<br>
Enjoy your drink on the Dahabiya sundeck during sailing. 
 <br>
<br>
Stop once again to visit the Temple of Kom Ombo.
(Let''s learn about Nubian culture this is a unique temple in that it has two identical entrances dedicated to two different gods, again one more attractive story of how the Egyptians avoid the danger of the crocodiles ).
 <br>
<br>
Overnight Dahabiya.
', CAST(34 AS Decimal(18, 0)), 4)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72141 AS Decimal(18, 0)), NULL, N'Arrive in Aswan the beautiful and amazing city famous for its Nubian history and the city which has a lot to offer.
<br>
<br>
Visit the love place The Temple of Philae.
(The first thing that will catch your eye is the most famous legends of love and loyalty).
<br>
<br>
Today you can do several optional activities with your expert tour guide.
<br>
<br>
Evening simple departure party will be operated by the Dahabiya staff.
<br>
<br>
Overnight Dahabiya', CAST(34 AS Decimal(18, 0)), 5)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72142 AS Decimal(18, 0)), NULL, N'Disembark after breakfast. 
<br>
<br>
Finally, transfer to your destination in Aswan but of course with unique photos and unforgettable memories. 
<br>
<br>
Have a nice trip.', CAST(34 AS Decimal(18, 0)), 6)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72130 AS Decimal(18, 0)), NULL, N'Enjoy your handmade breakfast while sailing enjoy the Nile breeze and listen to the secrets of the Nile River.
<br>
<br>
Stop by Edfu temple to explore the second largest temple in Egypt that is still in its amazing condition until now, Explore the land of victory to see the attractive story of how Horus defeats the evil god Set ).
<br>
<br>
Enjoy sailing and listen and get the great opportunity to have unique photos of the splendid views at both sides of the amazing Egyptian Nile. 
<br>
<br>
Enjoy an oriental party and Egyptian folklore music with an Egyptian band onboard.
<br>
<br>
Overnight Dahabiya.', CAST(36 AS Decimal(18, 0)), 2)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72131 AS Decimal(18, 0)), NULL, N'Enjoy your drink on the Dahabiya sundeck during sailing. 
 <br>
<br>
While we''re enjoying the sundeck we are going to reveal the secret of Gebel El-Silsila <br>
(the mother of all temples where you can see the remains of the temples and tombs,
listen well to your tour guide and know the story of how only a chisel and a hammer could cut the giant stones)
<br>
<br>
Enjoy sailing and talking with the Nile River and its waves are like feelings. 
<br>
<br>
Overnight Dahabiya', CAST(36 AS Decimal(18, 0)), 3)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72132 AS Decimal(18, 0)), NULL, N'(Look around you, it is the bride of the Nile, Aswan, which is considered one of the most important landmarks in the world, and its true magic is its people, its Nubian culture, and its warm weather).
<br>
<br>
Visit the love place The Temple of Philae.
(The first thing that will catch your eye is the most famous legends of love and loyalty).

<br>
<br>
Evening simple party will be operated by the Dahabiya staff and enjoy the beautiful view of the Nile 
River.
<br>
<br>
Overnight Dahabiya.
', CAST(36 AS Decimal(18, 0)), 4)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72133 AS Decimal(18, 0)), NULL, N'Now is the time to discover the most beautiful city. Aswan, 
get to know its people and culture closely.
<br>
<br>
you can do several optional activities with your expert tour guide.
<br>
<br>
Overnight Dahabiya.', CAST(36 AS Decimal(18, 0)), 5)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72134 AS Decimal(18, 0)), NULL, N'Enjoy sailing most of the day and share your stories with the Nile. 
<br><br>
Enjoy your unique experience by swimming in the waters of the Nile and enjoying it and its atmosphere.
<br><br>
Stop once again to visit the Temple of Kom Ombo 
(lets learn about Nubian culture this is a unique temple in that it has
 two identical entrances dedicated to two different gods,again one more 
attractive story of how the Egyptians avoid the danger of crocodiles).
<br><br>

Enjoy your local Egyptian drink on Dahabiya sundeck during sailing. 
<br><br>
Open your eyes here is egypt in the best way you can see.
<br><br>
Overnight Dahabiya.', CAST(36 AS Decimal(18, 0)), 6)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72110 AS Decimal(18, 0)), NULL, N'Enjoy your sailing and the natural views of the Nile River.
 <br>
<br>
Then stop to visit the Temple of Kom Ombo.
(Let''s learn about Nubian culture this is a unique temple in that it has two identical gods, again one more attractive story of how the Egyptians avoided the danger of the crocodiles).
 
Swimming in the Nile River is a unique and enjoyable experience, and you can swim in a safe and warm area as you wish.
<br>
<br>
Enjoy your local Egyptian drink on cruise sun deck during sailing. 
<br>
<br>
Overnight Dahabiya.
', CAST(40 AS Decimal(18, 0)), 3)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72135 AS Decimal(18, 0)), NULL, N'Enjoy your oriental breakfast onboard during sailing.
<br>
<br>
Your adventure is still alive by sailing towards one of the local villages to discover one of the most pure and natural areas where you can enjoy the stunning views,
the daily life and touch the Egyptian simplicity in this village.
<br>
<br>
After the unique cultural tour back to your Nile Dahabiya. 
<br>
<br>
Enjoy sailing. 
<br>
<br>
Enjoy an oriental party and Egyptian folklore music with an Egyptian band onboard.
 <br>
<br>
Overnight Dahabiya.', CAST(36 AS Decimal(18, 0)), 7)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72089 AS Decimal(18, 0)), NULL, N'Enjoy your open buffet breakfast at your hotel. 
<br>
<br>
Day at leisure. 
<br>
<br>
During the day enjoy the incredible beaches are  well-known for its stunning coral reefs, crystal-clear oceans, and fine white sand. Because of the calm, shallow seas, the area around the beach is ideal for swimming and other water activities and the nature around that will catch your eyes .
<br>
<br>
Evening drive to Hurghada airport for your flight back to Cairo. 
<br>
<br>
 Overnight at Cairo hotel.', CAST(41 AS Decimal(18, 0)), 9)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72096 AS Decimal(18, 0)), NULL, N'While we''re enjoying the sundeck we are going to reveal the secret of Gebel El-Silsila.
(The mother of all temples where you can see the remains of the temples and tombs, listen well to your tour guide and know the story of how Only a chisel and a hammer could cut the giant stones).
<br>
<br>
Back to your Nile Dahabiya. 
<br>
<br>
Enjoy your drink on the Dahabiya sundeck during sailing. 
 <br>
<br>
Stop once again to visit the Temple of Kom Ombo.
(Let''s learn about Nubian culture this is a unique temple in that it has two identical entrances dedicated to two different gods, again one more attractive story of how the Egyptians avoid the danger of the crocodiles ).
 <br>
<br>
Overnight Dahabiya.
', CAST(35 AS Decimal(18, 0)), 6)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72097 AS Decimal(18, 0)), NULL, N'Arrive in Aswan the beautiful and amazing city famous for its Nubian history and the city which has a lot to offer.
<br>
<br>
Visit the love place The Temple of Philae.
(The first thing that will catch your eye is the most famous legends of love and loyalty).
<br>
<br>
Today you can do several optional activities with your expert tour guide.
<br>
<br>
Evening simple departure party will be operated by the Dahabiya staff.
<br>
<br>
Overnight Dahabiya', CAST(35 AS Decimal(18, 0)), 7)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72098 AS Decimal(18, 0)), NULL, N'Disembark after breakfast.
Transfer to aswan Airport for your flight to Cairo. 
<br>
<br>
Overnight hotel in Cairo ', CAST(35 AS Decimal(18, 0)), 8)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72099 AS Decimal(18, 0)), NULL, N'After your breakfast and upon your request drive to Cairo airport for your final transfer or your destination in Cairo but definitely with memories will last forever 
<br>
<br>
Have a nice trip.', CAST(35 AS Decimal(18, 0)), 9)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72103 AS Decimal(18, 0)), NULL, N'Enjoy your breakfast on the Dahabiya sundeck during sailing. 
 <br><br>
Stop once again to visit the Temple of Kom Ombo.<br>
(Let''s learn about Nubian culture this is a unique temple in that it has two identical entrances dedicated to two different gods, again one more attractive story of how the Egyptians avoid the danger of the crocodiles ).
<br><br>
Enjoy sailing and discover more secrets of the Egyptian River Nile.
<br><br>
Experience the Egyptian hidden culture and swim in the warmest water ever during the day time and under the magical sun rayes. 
<br><br>
Relax on sun deck this is the real Egypt in the best way you can see. 
<br><br>
Overnight Dahabiya. ', CAST(37 AS Decimal(18, 0)), 4)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72104 AS Decimal(18, 0)), NULL, N'Enjoy your breakfast onboard. 
<br><br>
While we''re enjoying the sundeck we are going to reveal the secret of Gebel El-Silsila.<br>
(The mother of all temples where you can see the remains of the temples and tombs, listen well to your tour guide and know the story of how Only a chisel and a hammer could cut the giant stones).
<br><br>
Stop by Edfu temple to explore the second largest temple in Egypt that is still in its amazing condition until now, Explore the land of victory to see the attractive story of how Horus defeats the evil god Set ).
<br><br>
 Enjoy sailing. 

<br><br>
Evening a unique and simple goodbye party will be operated by the cruise staff. 
<br><br>
Overnight Dahabiya.', CAST(37 AS Decimal(18, 0)), 5)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72129 AS Decimal(18, 0)), NULL, N'Morning your expert representative will pick you up from Luxor airport, station, or your hotel in Luxor depending on your pick-up point.
<br>
<br>
Now the sun is with its golden rays while we are driving to the amazing Karnak temple.
( you will see with your own eyes where history comes alive, the Karnak temples are considered one of the greatest temples ever in Egypt) . 
<br>
<br>
drive in comfort to Esna.

Enjoy sailing there is nothing more wonderful than sitting and looking at the Nile and sharing your feelings with it Enjoy the islands'' natural views and the fresh air. 
<br>
<br>
After your special Egyptian dinner abroad with the guide and reviling some secrets about the hidden culture in Egypt.
<br>
<br>
Overnight Dahabiya.

', CAST(36 AS Decimal(18, 0)), 1)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72073 AS Decimal(18, 0)), NULL, N'Enjoy your open buffet breakfast at your hotel.
<br><br>
 Now the sun is shining with its golden rays while we are driving to the amazing Karnak temple.
( you will see with your own eyes where history comes alive, the Karnak temples are considered one of the greatest temples ever in Egypt) .
<br><br>
After Karnak temple drive to Esna.
<br><br>
Now time is coming to check in your Nille Dahabiya. 
<br><br>
Enjoy your handmade fresh lunch abroad.
<br><br>
Rest and refresh. 
<br><br>
Enjoy sailing and prepare yourself to have unique photos of the splendid Egyptian River Nile during sailing (unique islands, fields, gardens)
Pure nature is around you everywhere. 
<br><br>
Evening After dinner listen quit to your Expert tour guide who will give you a general idea about the hidden culture of Egypt. 
<br><br>
Overnight Dahabiya.', CAST(42 AS Decimal(18, 0)), 4)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72074 AS Decimal(18, 0)), NULL, N'Breakfast during sailing is a great opportunity to discover the whispers of the immortal Egyptian River Nile. 
<br><br>
Stop by Edfu temple to explore the second largest temple in Egypt that is still in its amazing condition until now, Explore the land of victory to see the attractive story of how Horus defeats the evil god Set ).
<br><br>
Enjoy sailing and listen to the Nile secrets.
<br><br>
Your adventure is still alive by sailing towards one of the local villages to touch the most pure natural areas where you can enjoy the stunning views,the daily life and touch the Egyptian simplicity in the Nile).
<br><br>
After the unique cultural tour back to your Nile Dahabiya. 
<br><br>
Overnight Dahabiya.', CAST(42 AS Decimal(18, 0)), 5)
INSERT [dbo].[expects] ([expectId], [title], [details], [tourId], [order]) VALUES (CAST(72075 AS Decimal(18, 0)), NULL, N'While we''re enjoying the sundeck we are going to reveal the secret of Gebel El-Silsila.<br>
(The mother of all temples where you can see the remains of the temples and tombs, listen well to your tour guide and know the story of how Only a chisel and a hammer could cut the giant stones).
<br><br>
Back to your Nile Dahabiya. 
<br><br>
Enjoy your drink on the Dahabiya sundeck during sailing. 
 <br><br>
Stop once again to visit the Temple of Kom Ombo.<br>
(Let''s learn about Nubian culture this is a unique temple in that it has two identical entrances dedicated to two different gods, again one more attractive story of how the Egyptians avoid the danger of the crocodiles ).
 <br><br>
Overnight Dahabiya.', CAST(42 AS Decimal(18, 0)), 6)
SET IDENTITY_INSERT [dbo].[expects] OFF
GO
SET IDENTITY_INSERT [dbo].[facebookTokens] ON 

INSERT [dbo].[facebookTokens] ([id], [appId], [appSecret], [shortToken], [longToken], [expiryDate]) VALUES (24, N'2427532220918195', N'2680a68ba45e3fffce2cd5e36775b99f', N'EAAif0ZBO1abMBO4vbNZAnKJmZCMvKq2BvqIBBsTnaUtB7K9j1JULPB4QcZBWAmRZBM246MCbL9AOZAW6tTLZC4RDwTK1lQZA5GCF8ECdXbBSm0siWcOX9DZAlDyqhZBt94sXr4t6boCNe479GMuRNG5haYT0rZCkZBvwqlI8gahwBkZBMBc0wZBGYZAyzxtXAEe8rZB2gjfshYDZAaUvK4qa0bERZCv8xaOQ1s0g1gZARyrik46JVbNP26bDq7xwfD7340nnesPhJW4hryEgUl61adlUVzhwOZBKAWtTidg3iDA0n3qk4OO3ZCEcUsgZDZD', N'EAAif0ZBO1abMBOZBZAAkxr1oicof48vv8LwCsX8Y0fIX9yRwfr8K3wbf1NLNzLrlrQYtKrUESGDMcU6wEPLcQQx1tj5h07SNlHDZAdiOwvtotxZBz077IYUlmAPrpOdmHuDXZBEcLvwcovIkXMiQSszdvluZAMD8ZAouR0PUCBFYqvqUKMujcr6edoWu', CAST(N'2025-02-02T18:20:52.517' AS DateTime))
SET IDENTITY_INSERT [dbo].[facebookTokens] OFF
GO
SET IDENTITY_INSERT [dbo].[facilities] ON 

INSERT [dbo].[facilities] ([facilitiesId], [title], [description], [imagePath], [orderId], [languageId]) VALUES (1, N'24 Hours Service', N'Round-the-clock assistance ensures your needs are met anytime.', NULL, 6, 1)
INSERT [dbo].[facilities] ([facilitiesId], [title], [description], [imagePath], [orderId], [languageId]) VALUES (2, N'Professional Egyptologists', N'Expert Egyptologists enrich your journey with insights into ancient history and culture.', NULL, 3, 1)
INSERT [dbo].[facilities] ([facilitiesId], [title], [description], [imagePath], [orderId], [languageId]) VALUES (3, N'Medical Service', N'Onboard medical services provide peace of mind during your voyage.', NULL, 1, 1)
INSERT [dbo].[facilities] ([facilitiesId], [title], [description], [imagePath], [orderId], [languageId]) VALUES (4, N'Customised Tours', N'Expertly guided tours tailored to your preferences ensure an immersive exploration of Egypt''s wonders.', NULL, 2, 1)
INSERT [dbo].[facilities] ([facilitiesId], [title], [description], [imagePath], [orderId], [languageId]) VALUES (5, N'Internet Service', N'Stay connected with high-speed internet available throughout your cruise.', NULL, 5, 1)
INSERT [dbo].[facilities] ([facilitiesId], [title], [description], [imagePath], [orderId], [languageId]) VALUES (6, N' Environmentally Friendly', N'Anoush Dahabiya is committed to eco-friendly practices for a sustainable cruise.', NULL, 6, 1)
INSERT [dbo].[facilities] ([facilitiesId], [title], [description], [imagePath], [orderId], [languageId]) VALUES (7, N'Sun Deck ', N'Relax and enjoy panoramic views on the sun deck .', NULL, 7, 1)
INSERT [dbo].[facilities] ([facilitiesId], [title], [description], [imagePath], [orderId], [languageId]) VALUES (8, N'Local party onboard', N'All our packages include local party onboard with oriental music.', NULL, 8, 1)
INSERT [dbo].[facilities] ([facilitiesId], [title], [description], [imagePath], [orderId], [languageId]) VALUES (9, N'Local Village', N'All our packages include tour to local Village to discover the hidden culture side of Egypt.', NULL, 9, 1)
SET IDENTITY_INSERT [dbo].[facilities] OFF
GO
SET IDENTITY_INSERT [dbo].[faqs] ON 

INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (1, N'Is there a special rate for private groups booking', N'Yes,our travel company does provide a discount for private trips booked with groups. 
<br><br>
And we provide discount as well for repeated customers.', 2, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (2, N'Is Egypt considered a safe destination', N' Egypt has served as one of the best and safest tourist destinations for decades. Surrounded by warm Egyptian hospitality, courteous and kind-hearted locals you''re gonna feel at home and as safe as you''ll ever be.
<br><br>
 With some Sensible precautions and preparations, you will be able to explore Egypt tours and trips and enjoy Egypt''s generally very safe cities with your mind at ease.

Visitors will be more than safe especially in areas frequently visited by tourists.', 1, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (3, N'What time do we embark/disembark the Dahabiya and also check in and check out from hotels', N'Embark on board at 11 am.

Disembark on board after breakfast around 8 am .
<BR><BR>
At hotels check in time 1:30 pm.
Check out time 11:30 am
', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (4, N'How can I book a tour or contact you', N'Full details about how to get in touch with us by phone,request form and email are available on our Contact Us page.
<br>
<br>
To book a tour you have two options .
<br><br>
the first option to book automatically through our booking calendar which you will find it in each of our tours.
<br><br>
the second option to contact us through our contact us page (by email,request form or phone)', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (37, N'i noticed that the entrance fees does not include in the price how much does it cost me', N'

Here is all the entrance fees for all places in our tours.
<br><br>
The pyramids 540 Egyptian pounds. 
<br><br>
The Egyptian museum 450 Egyptian pounds. 
<br><br>
Valley of the kings 610 Egyptian pounds.
<br><br>
Queen Hatshepsut temple 360 Egyptian pounds.
<br><br>
Karnak temple 450 Egyptian pounds.
<br><br>
Gebel El-Silsila 100 Egyptian pounds. 
<br><br>
Edfu temple 450 Egyptian pounds. 
<br><br>
Kom Ombo temple 360 Egyptian pounds. 
<br><br>
Philae temple 450 Egyptian pounds. 
<br><br>
Abu Simple temples 615 Egyptian pounds. 
<br><br>
Desert oasis 250 Egyptian pounds. 
<br><br>
Children pay half of the previous prices.
<br><br>
All the entrance fees must be payed by credit card not cash. 
<br><br>
Finally our guide will help our guests to buy the entrance fees in each tour
<br><br>
', 38, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (43, N'Are the meals included in the price on board or in hotel and What are the meals like', N'On board with no more than maximum 30 guests to cater for, and fresh supplies delivered each morning from the nearby mainland, 
<br>
<br>
Our chefs have the time and facilities to create an exquisite dining experience each day. 
They serve authentic dishes with Egyptian and Mediterranean-inspired flavors. 
<br>
<br>
Individual dietary requirements and vegetarians can easily be catered for. 
<br>
<br>
The following meals are included on bard: Breakfast, Lunch and Dinner.
<br>
<br>
 At hotels only breakfast included but of course there is restaurant in each hotel to provide food with extra charge. 
<br>
<br>
Please check (the include and not include section)of each tour', 1, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (7, N'Will there by a guide on tour and in which language', N'Yes, an English,French or Spanish speaking Egyptologist will accompany all the guests during the entire trip. 
<BR><BR>
If you prefer a guide who speaks another foreign language than the previous 3 languages, we can easily arrange that with extra cost', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (30, N'What is the best time to travel to Egypt', N'From beginning of September till end of May', 32, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (31, N'Can i amend any part of the web site tours which i want to book and can i upgrade my hotel if i want', N'All our tours are flexible so we can amend any part of it upon your request,however you can easily contact our customer service and if the amend will fit your tour we will be happy to assist you.
<br><br>
Also you can upgrade your hotel if you book tour package through our customer service  ', 33, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (44, N'Are there any parties on board ', N'Yes there is one party on board', 10, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (12, N'If i want to book an optional tour such as Abu Simble,Nubian village,Hot air balloon or other what shall i do', N'You can simply add your optional tour at time of booking through our booking calendar.
<br><br>
Or contact our customer service .
', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (13, N' What happens if there is no wind or the wind blows hard on board', N'There are no engines on board our Dahabiya boats; they are designed for sailing the Nile. Due to the prevailing wind, more sailing is possible upstream towards Aswan than downstream towards Esna. 
<BR><BR>
Even the ancient hieroglyphs show this: a boat with a sail is sailing south (=upstream), a boat with oars is heading north (=downstream). 
<BR><BR>
Luckily our Dahabiya has its own small tug that can help if the natural elements fail.', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (45, N'What is a Dahabiya Nile cruise', N'A Dahabiya simply is a Wooden traditional Egyptian sailing boat that offers a unique and intimate way to explore the Nile River. Unlike larger cruise ships, Dahabiyas are smaller and more exclusive, providing a serene experience with personalized service and access to less crowded sites along the Nile.', 1, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (15, N'Are there exchange offices in the towns visited', N' Yes, there are exchange offices in the towns visited. There are banks too.', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (16, N'Is there Wi-Fi available on boats or hotels', N'Yes, Wi-Fi is available on boats free of charge, 
How ever it is only available at certain times so that passengers can enjoy their trip in peace and limit the use of connected devices.
<BR><BR>
At hotel it is available with extra charge 
<BR><BR>
Or simply we can help you to buy a local sim', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (46, N'What makes a Dahabiya Nile Cruise different from other Nile cruises', N'A Dahabiya Nile Cruise offers an unparalleled level of privacy and exclusivity. With fewer passengers, often only 16-28, the experience is more personalized and intimate. The slow-paced sailing allows for a more relaxed exploration of the Nile, with stops at smaller, less touristy sites that larger ships cannot access.', 2, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (18, N' Is the Dahabiya Nile cruise suitable for children', N'Yes, the boats and daily activities are suitable for children.', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (19, N' Is there any social etiquette to keep in mind', N' In Egypt, public displays of affection should be kept to a minimum.
<br><br>
 Caution should be taken regarding picture taking in Egypt. Always ask if it’s OK to take pictures of someone or something before doing so. People in rural areas are not familiar with foreigners taking pictures of them, so it’s best to ask and be friendly first.
<br><br>
 At museums, signs will guide you. Do not take pictures of military people, soldiers or government-looking places.
<br><br>
 There is no dress code on board the boat. Feel free to wear casual and comfortable clothes to fit your individual preference.
<br><br>
 How ever please be advised that in general Egyptians are conservative, especially in smaller villages, therefore, do not to wear tight-fitting or revealing clothing, mainly when going on excursions.
<br><br>
Rather than this, you will get amazed by the amazing Egyptian civilization and the traditions of the Egyptians', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (20, N'What do you recommend that we bring for our trip to Egypt', N'The main things you need to bring includes the following:
<BR><BR>
 Sun hat, sunglasses, sunscreen, insect repellent, shoes for walking through water (sandals), walking shoes, warm socks, camera, a small flashlight, a small backpack if wanted, personal toiletries & medicine.
<BR><BR>
 On board the Dahabiya and also in hotels, we provide all bed linen and bath towels,etc', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (21, N' Is it safe to swim in the Nile River', N'Not everywhere, but the crew knows exactly where it’s safe to swim in the Nile and they will advice you', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (22, N'Is the Dahabiya more suitable for people travelling privately or with a group', N'The choice is yours, depending on what you feel more comfortable with Travelling with a group can be very fulfilling.
<br><br>
 Many guests find it very easy to mix and chat with others. At the same time, the setting on board allows couples the privacy they may want, even when travelling with others. Because of the relaxed, personal atmosphere, with communal dining and plenty of interesting activities and tours throughout the journey, 
<br><br>
many of our guests choose to travel privately as well.', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (23, N' Can we stay less than 3 nights on board', N'Yes we have only one tour for 2 nights which starts from Aswan weekly.
Please check it in our tours', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (24, N'Can we charter the Dahabiya boat for a private journey', N'Yes, it is also possible to book our Dahabiya boat privately for your group for a minimum number of 3 nights.
<br>
<br>
 Different trips and itineraries can be tailored to families or small private groups.
<br>
<br>
 Early booking is highly recommended for private journeys, especially in the high season, September through May. 
<br>
<br>
Please contact us for more detailed information and suggested itineraries.', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (26, N' What currency is accepted on board or in hotels', N'We accept EUR€, US$ and GBP£ on board, and credit cards.', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (27, N' Is there electricity and air-conditioning on board', N'There are 220-volt power points all over the boat. As electricity is provided by a generator, we have to switch the generator off at night time.
<br><br>
The entire boat is air-conditioned.', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (28, N' How many guests does our Dahabiya accommodate and how many cabins on board', N' Our Dahabiya can accommodate up to 32 guests plus 16 child with 12 cabins and 4 suits on board', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (33, N'What is the cancelation policy ', N'Please read the cancelation policy of each tour in (additional information)
And also in our terms and conditions', 35, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (34, N'Is alcohol available on board or in hotels', N'Yes available with extra charge ', 36, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (35, N'I want to book different tour in Egypt than the tours in the web site what shall i do ', N'You can simply contact us through Special request top right of the home page', 37, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (47, N'What amenities can I expect on board?', N'Our Dahabiya boats are equipped with nice cabins featuring with bathrooms, air conditioning, and décor. Onboard amenities include a sun deck, a dining area offering gourmet meals, and attentive staff dedicated to your comfort and enjoyment.', 3, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (48, N'How long is a typical Dahabiya Nile Cruise', N'A typical Dahabiya Nile Cruise lasts between 3 to 7 nights, depending on the itinerary you choose. We offer various routes between Luxor and Aswan, each designed to showcase the best of Egypt''s ancient wonders along the Nile.', 4, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (49, N'If i book a package and choose suite do i have suite also in hotels', N'suite in our calendar booking applies only to our Dahabiya accommodation not to hotels in Cairo,Red sea,etc ', 30, 1)
INSERT [dbo].[faqs] ([faqId], [question], [answer], [orderId], [languageId]) VALUES (36, N'Where can we picked up or dropped off', N'Once you book your tour and write your pick up details we will be happy to pick you up from any where.
<BR><BR>
However we pick up or drop off all our guests from or to airports ,train stations ,hotels or any another notes', 38, 1)
SET IDENTITY_INSERT [dbo].[faqs] OFF
GO
SET IDENTITY_INSERT [dbo].[hotelRoomPricing] ON 

INSERT [dbo].[hotelRoomPricing] ([hotelRoomId], [roomTypeId], [price], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (2002, 1, NULL, 1, 0, 0)
INSERT [dbo].[hotelRoomPricing] ([hotelRoomId], [roomTypeId], [price], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (2003, 2, NULL, 1, 1, 0)
INSERT [dbo].[hotelRoomPricing] ([hotelRoomId], [roomTypeId], [price], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (2004, 3, NULL, 2, 0, 0)
INSERT [dbo].[hotelRoomPricing] ([hotelRoomId], [roomTypeId], [price], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (2005, 4, NULL, 2, 1, 0)
INSERT [dbo].[hotelRoomPricing] ([hotelRoomId], [roomTypeId], [price], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (2006, 5, NULL, 2, 0, 0)
INSERT [dbo].[hotelRoomPricing] ([hotelRoomId], [roomTypeId], [price], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (2007, 6, NULL, 2, 1, 0)
SET IDENTITY_INSERT [dbo].[hotelRoomPricing] OFF
GO
SET IDENTITY_INSERT [dbo].[hotelType] ON 

INSERT [dbo].[hotelType] ([hotelTypeId], [hotelTypeName]) VALUES (1, N'three stars')
INSERT [dbo].[hotelType] ([hotelTypeId], [hotelTypeName]) VALUES (2, N'four stars')
INSERT [dbo].[hotelType] ([hotelTypeId], [hotelTypeName]) VALUES (3, N'five stars')
SET IDENTITY_INSERT [dbo].[hotelType] OFF
GO
SET IDENTITY_INSERT [dbo].[includes] ON 

INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74191 AS Decimal(18, 0)), N'3 nights accommodation in Nile 
dahabiya From Aswan to Luxor starting with Lunch first day end with Breakfast last day', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74192 AS Decimal(18, 0)), N'1 night at 4 stars hotel in Luxor includes breakfast', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74193 AS Decimal(18, 0)), N'Aswan tours
', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74194 AS Decimal(18, 0)), N'Luxor tours
', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74195 AS Decimal(18, 0)), N'Kom Ombo and Edfu temples', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74196 AS Decimal(18, 0)), N'Gebel El-Silsila.', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74197 AS Decimal(18, 0)), N'Expert tour guide
', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74198 AS Decimal(18, 0)), N'Professional licensed drivers', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74199 AS Decimal(18, 0)), N' 
A/C transportation 
', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74200 AS Decimal(18, 0)), N'Door to Door transfers from and to your destinations in Aswan And Luxor
', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74201 AS Decimal(18, 0)), N'Soft and Hot drinks during your stay at your Nile Dahabiya', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74202 AS Decimal(18, 0)), N'Taxes and Charges', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74213 AS Decimal(18, 0)), N'7 nights accommodation in Nile dahabiya From Luxor to Luxor starting with Lunch first day end with Breakfast last day', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74214 AS Decimal(18, 0)), N'Luxor tours', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74215 AS Decimal(18, 0)), N'Aswan tours', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74216 AS Decimal(18, 0)), N'Kom Ombo and Edfu temples', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74217 AS Decimal(18, 0)), N'local island', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74218 AS Decimal(18, 0)), N'Gebel El-Silsila.', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74219 AS Decimal(18, 0)), N'Expert tour guide', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74220 AS Decimal(18, 0)), N'Professional licensed drivers', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74221 AS Decimal(18, 0)), N'A/C transportation ', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74222 AS Decimal(18, 0)), N'Door to Door transfers from and to your destinations in Aswan And Luxor
', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74223 AS Decimal(18, 0)), N'Soft and Hot drinks during your stay at your Nile Dahabiya', CAST(36 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(73336 AS Decimal(18, 0)), N're', CAST(44 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(73338 AS Decimal(18, 0)), N'm', CAST(45 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74099 AS Decimal(18, 0)), N'4 nights accommodation in Nile 
dahabiya From Luxor to Aswan starting with Lunch first day end with Breakfast last day
', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74100 AS Decimal(18, 0)), N'2 night at 4 stars hotel in Cairo include breakfast', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74101 AS Decimal(18, 0)), N'2 nights camping at Desert Oasis include breakfast and dinner', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74102 AS Decimal(18, 0)), N'2 night at 4 stars hotel in Luxor include breakfast ', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74103 AS Decimal(18, 0)), N'Flights Cairo \ Luxor \ Aswan
/ Cairo', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74104 AS Decimal(18, 0)), N'Cairo tours', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74105 AS Decimal(18, 0)), N'Luxor tours', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74106 AS Decimal(18, 0)), N'Aswan tours', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74107 AS Decimal(18, 0)), N'local island', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74108 AS Decimal(18, 0)), N'Gebel El-Silsila.', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74109 AS Decimal(18, 0)), N'Expert tour guide
', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74110 AS Decimal(18, 0)), N'Professional licensed drivers', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74111 AS Decimal(18, 0)), N'A/C transportation 
', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74112 AS Decimal(18, 0)), N'Door to Door transfers from and to your destinations in Cairo 
', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74113 AS Decimal(18, 0)), N'Soft and Hot drinks during your stay at your Nile Dahabiya', CAST(42 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74114 AS Decimal(18, 0)), N'3 nights accommodation in Nile 
dahabiya From Aswan to Luxor starting with Lunch first day end with Breakfast last day', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74115 AS Decimal(18, 0)), N'2 night at 4 stars hotel in Cairo includes breakfast', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74116 AS Decimal(18, 0)), N'2 night at 4 stars hotel in Hurghada, includes breakfast and dinner', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74117 AS Decimal(18, 0)), N'1 night at 4 stars hotel in Aswan, includes breakfast', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74118 AS Decimal(18, 0)), N'1 night at 4 stars hotel in Luxor, includes breakfast', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74119 AS Decimal(18, 0)), N'Flights Cairo \ Aswan\Hurghada\Cairo', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74120 AS Decimal(18, 0)), N'Cairo tours', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74121 AS Decimal(18, 0)), N'Aswan tours', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74122 AS Decimal(18, 0)), N'Luxor tours', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74123 AS Decimal(18, 0)), N'Hurghada tours', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74124 AS Decimal(18, 0)), N'local island', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74125 AS Decimal(18, 0)), N'Gebel El-Silsila.', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74126 AS Decimal(18, 0)), N'Expert tour guide
', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74127 AS Decimal(18, 0)), N'Professional licensed drivers', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74128 AS Decimal(18, 0)), N'A/C transportation 
', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74129 AS Decimal(18, 0)), N'Door to Door transfers from and to your destinations in Aswan And Luxor
', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74130 AS Decimal(18, 0)), N'Soft and Hot drinks during your stay at your Nile Dahabiya', CAST(41 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74131 AS Decimal(18, 0)), N'4 nights accommodation in Nile 
dahabiya From Luxor to Aswan starting with Lunch first day end with Breakfast last day', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74132 AS Decimal(18, 0)), N'2 night at 4 stars hotel in Cairo includes breakfast', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74133 AS Decimal(18, 0)), N'2 night at 4 stars hotel in luxor 
 includes breakfast', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74134 AS Decimal(18, 0)), N'Flights Cairo /Luxor /Aswan / Cairo', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74135 AS Decimal(18, 0)), N'Cairo tours', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74136 AS Decimal(18, 0)), N'Luxor tours', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74137 AS Decimal(18, 0)), N'Aswan tours', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74138 AS Decimal(18, 0)), N'Kom Ombo and Edfu temples', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74139 AS Decimal(18, 0)), N'local island', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74140 AS Decimal(18, 0)), N'Gebel El-Silsila.', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74141 AS Decimal(18, 0)), N'Expert tour guide', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74142 AS Decimal(18, 0)), N'Professional licensed drivers', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74143 AS Decimal(18, 0)), N'A/C transportation ', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74144 AS Decimal(18, 0)), N'Door to Door transfers from and to your destinations in Aswan And Luxor
', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74145 AS Decimal(18, 0)), N'Soft and Hot drinks during your stay at your Nile Dahabiya', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74146 AS Decimal(18, 0)), N'Taxes and charges', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74147 AS Decimal(18, 0)), N'3 nights accommodation in Nile 
dahabiya From Aswan to Luxor starting with Lunch first day end with Breakfast last day', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74148 AS Decimal(18, 0)), N'2 night at 4 stars hotel in Cairo  includes breakfast', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74149 AS Decimal(18, 0)), N'1 night at 4 stars hotel in Luxor  includes breakfast', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74150 AS Decimal(18, 0)), N'1 night at 4 stars hotel in Aswan  includes breakfast', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74151 AS Decimal(18, 0)), N'Flights Cairo /Aswan /Luxor / Cairo', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74152 AS Decimal(18, 0)), N'Cairo tours', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74153 AS Decimal(18, 0)), N'Luxor tours', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74154 AS Decimal(18, 0)), N'Aswan tours', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74155 AS Decimal(18, 0)), N'Kom Ombo and Edfu temples', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74156 AS Decimal(18, 0)), N'local island', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74157 AS Decimal(18, 0)), N'Gebel El-Silsila.', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74158 AS Decimal(18, 0)), N'Expert tour guide', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74159 AS Decimal(18, 0)), N'Professional licensed drivers', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74160 AS Decimal(18, 0)), N'A/C transportation ', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74161 AS Decimal(18, 0)), N'Door to Door transfers from and to your destinations in Aswan And Luxor
', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74162 AS Decimal(18, 0)), N'Soft and Hot drinks during your stay at your Nile Dahabiya', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74163 AS Decimal(18, 0)), N'Taxes and charges', CAST(37 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74164 AS Decimal(18, 0)), N'3 nights accommodation in Nile 
dahabiya From Aswan to Luxor starting with Lunch first day end with Breakfast last day', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74165 AS Decimal(18, 0)), N'2 night at 4 stars hotel in Cairo includes breakfast', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74166 AS Decimal(18, 0)), N'1 night at 4 stars hotel in Hurghada, includes breakfast and diiner', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74167 AS Decimal(18, 0)), N'Flights Cairo \Aswan\Hurghada\Cairo', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74168 AS Decimal(18, 0)), N'Cairo tours
', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74169 AS Decimal(18, 0)), N'Aswan tours
', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74170 AS Decimal(18, 0)), N'Luxor tours
', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74171 AS Decimal(18, 0)), N'Hurghada tours', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74172 AS Decimal(18, 0)), N'local island', CAST(40 AS Decimal(18, 0)))
GO
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74173 AS Decimal(18, 0)), N'Gebel El-Silsila.', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74174 AS Decimal(18, 0)), N'Expert tour guide
', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74175 AS Decimal(18, 0)), N'Professional licensed drivers', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74176 AS Decimal(18, 0)), N'A/C transportation 
', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74177 AS Decimal(18, 0)), N'Door to Door transfers from and to your destinations in Aswan And Luxor
', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74178 AS Decimal(18, 0)), N'Soft and Hot drinks during your stay at your Nile Dahabiya', CAST(40 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74224 AS Decimal(18, 0)), N'1 night at 4 stars hotel in Luxor includes breakfast', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74225 AS Decimal(18, 0)), N'4 nights accommodation in Nile dahabiya From  Luxor to Aswan starting with Lunch first day end with Breakfast last day', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74226 AS Decimal(18, 0)), N'Luxor tours
', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74227 AS Decimal(18, 0)), N'Aswan tours
', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74228 AS Decimal(18, 0)), N'Kom Ombo and Edfu temples', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74229 AS Decimal(18, 0)), N'local island', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74230 AS Decimal(18, 0)), N'Gebel El-Silsila.', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74231 AS Decimal(18, 0)), N'Expert tour guide', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74232 AS Decimal(18, 0)), N'Professional licensed drivers', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74233 AS Decimal(18, 0)), N'A/C transportation ', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74234 AS Decimal(18, 0)), N'Door to Door transfers from and to your destinations in Aswan And Luxor
', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74235 AS Decimal(18, 0)), N'Soft and Hot drinks during your stay at your Nile Dahabiya', CAST(34 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74236 AS Decimal(18, 0)), N'2 nights accommodation in Nile 
dahabiya From Aswan to Luxor starting with Lunch first day end with Breakfast last day', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74237 AS Decimal(18, 0)), N'Kom Ombo and Edfu temples', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74238 AS Decimal(18, 0)), N'Local village', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74239 AS Decimal(18, 0)), N'Gebel El-Silsila.', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74240 AS Decimal(18, 0)), N'Expert tour guide', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74241 AS Decimal(18, 0)), N'Professional licensed drivers', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74242 AS Decimal(18, 0)), N'A/C transportation 
', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74243 AS Decimal(18, 0)), N'Door to Door transfers from and to your destinations in Aswan And Luxor
', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74244 AS Decimal(18, 0)), N'Soft and Hot drinks during your stay at your Nile Dahabiya', CAST(43 AS Decimal(18, 0)))
INSERT [dbo].[includes] ([includeId], [includeText], [tourId]) VALUES (CAST(74245 AS Decimal(18, 0)), N'Taxes and Charges', CAST(43 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[includes] OFF
GO
SET IDENTITY_INSERT [dbo].[languages] ON 

INSERT [dbo].[languages] ([languageId], [languageName], [creationDate], [createdBy], [code]) VALUES (CAST(1 AS Decimal(18, 0)), N'english', NULL, NULL, N'en')
INSERT [dbo].[languages] ([languageId], [languageName], [creationDate], [createdBy], [code]) VALUES (CAST(2 AS Decimal(18, 0)), N'french', NULL, NULL, N'fr')
INSERT [dbo].[languages] ([languageId], [languageName], [creationDate], [createdBy], [code]) VALUES (CAST(10003 AS Decimal(18, 0)), N'Spanish', NULL, NULL, N'es')
SET IDENTITY_INSERT [dbo].[languages] OFF
GO
SET IDENTITY_INSERT [dbo].[localizations] ON 

INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(1 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'user', N'المستخدمين')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(2 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'user', N'users')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(3 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'role', N'role')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(4 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'role', N'الادوار')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(5 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'tour', N'tour')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(6 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'tour', N'الرحلات')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(7 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'request', N'الحجوزات')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(8 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'request', N'reservation')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(9 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'SpecialRequests', N'special requests')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(10 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'SpecialRequests', N'الطلبات الخاصة')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(11 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'contact', N'التواصل')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(12 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'contact', N'contact')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(13 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'localization', N'localization')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(14 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'localization', N'الترجمه')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(15 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'currency', N'العملة')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(16 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'currency', N'currency')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(20012 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'DeleteLocalization', N'تم حذف الترجمة بنجاح')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(10003 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'language', N'اللغات')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(20002 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'pricing', N'pricing')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(20003 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'pricing', N'التسعير')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(20013 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'DeleteLocalization', N'Delete Localization')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(20014 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'DeleteLocalizationError', N'error when delete localization')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(20006 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Delete', N'حذف')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(20015 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'DeleteLocalizationError', N'خطأ اثناء حذف الترجمة')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(20016 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'language', N'language')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(20017 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Add', N'add')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(20018 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Add', N'اضافة')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(20019 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'edit', N'تعديل')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(20020 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'edit', N'edit')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40005 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Added', N'Added successfully')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40006 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Added', N'تم الاضافة بنجاح')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40007 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'SpecialRequest', N'Special Request')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40008 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'SpecialRequest', N'طلب خاص')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40009 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'SentMessage', N'Message sent  successfully')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40010 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'SentMessage', N'تم الارسال بنجاح')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40011 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'SentMessageError', N'Error When Sent Request')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40012 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'SentMessageError', N'حدث خطا')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40013 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'ThankYou', N'Thank You')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40014 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'ThankYou', N'شكراّ لك')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40015 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'ThanksForContactWithUs', N'Thank you for contacting us')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40016 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'ThanksForContactWithUs', N'شكرا علي تواصلك معنا')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40017 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'CheckSoon', N'One of our team will contact you as soon as possible.')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40018 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'CheckSoon', N'سنقوم بفحص طلبك والتواصل معك في اقرب وقت ممكن')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40019 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Regards', N'Regards')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40020 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Regards', N'مع اطيب التمنيات')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40021 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Phone', N'Phone')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40022 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Phone', N'رقم الموبايل')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40023 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Message', N'Message')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40024 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Message', N'الرسالة')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40025 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'NumberOfAdult', N'Number Of Adult')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40026 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'NumberOfAdult', N'عدد البالغين')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40027 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'NumberOfChild', N'Number Of Child')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40028 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'NumberOfChild', N'عدد الاطفال')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40029 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'NumberOfInfant', N'Number Of Infant')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40030 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'NumberOfInfant', N'عدد الصغار')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40033 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Dear', N'Dear our guest,')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40034 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Dear', N'عزيزي')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40035 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'ChangePassword', N'Change Password')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40036 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'ChangePassword', N'تغير كلمة المرور')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40037 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'ChangePasswordError', N'Error Change Password')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40038 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'ChangePasswordError', N'خطأ في تغير كلمة المرور')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40039 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'ContactSent', N'Contact Sent')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40040 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'ContactSent', N'تواصل معنا')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40041 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'AddedError', N'failed to add')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40042 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'AddedError', N'خطأ في الاضافة')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40043 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Update', N'Update')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40044 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Update', N'تعديل')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40045 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Updated', N'Updated successfully')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40046 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Updated', N'تم التعديل بنجاح')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40047 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'UpdatedError', N'failed to update')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40048 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'UpdatedError', N'فشل في التعديل')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40049 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Delete', N'Delete')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40050 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Delete', N'حذف')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40051 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Deleted', N'Deleted successfully')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40052 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Deleted', N'تم الحذف بنجاح')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40053 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'DeletedError', N'failed to delete')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40054 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'DeletedError', N'فشل في الحذف')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40055 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Exsits', N'Exsits')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40056 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Exsits', N'موجود بالفعل')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40057 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Actions', N'Actions')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40058 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Actions', N'أجراءات')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40059 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Email', N'email')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40060 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Email', N'البريد الالكتروني')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40061 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Cancel', N'Cancel')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40062 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Cancel', N'الغاء')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80071 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'TourAvailability', N'Tour Availability')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80072 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'WhatIncludes', N'What''s include')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40065 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'LanguageCode', N'Language Code')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40066 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'LanguageCode', N'كود اللغة')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40067 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Save', N'Save')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40069 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Translations', N'Translations')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40070 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Translations', N'الترجمة')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40071 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Key', N'Key')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40072 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Key', N'المفتاح')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40073 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Value', N'Value')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40074 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Value', N'القيمة')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40075 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'HotelType', N'Hotel Type')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40076 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'HotelType', N'نوع الفندق')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40077 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'RoomType', N'Room Type')
GO
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40078 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'RoomType', N'نوع الغرفة')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40079 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Price', N'Price')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40080 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Price', N'السعر')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40081 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'MaxNumberOfAdult', N'Maxium Number Of Adult')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40082 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'MaxNumberOfAdult', N'اقصى عدد للبالغين')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40083 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'MaxNumberOfChild', N'Maxium Number Of Child')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40084 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'MaxNumberOfChild', N'اقصى عدد للاطفال')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40085 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'MaxNumberOfInfant', N'Maxium Number Of Infant')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40086 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'MaxNumberOfInfant', N'اقصى عدد للرضع')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40087 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Request', N'Request')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40088 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Request', N'الطلب')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40089 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'RequestName', N'Request Name')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40090 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'RequestName', N'اسم الطلب')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40091 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'RoleName', N'Role Name')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40092 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'RoleName', N'اسم الدور')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40093 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Nights', N'Nights')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40094 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Nights', N'عدد الليالي')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40095 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'CountryName', N'Country Name')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40096 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'CountryName', N'اسم البلد')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40097 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'ArriveDate', N'Arrive Date')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40098 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'ArriveDate', N'تاريخ الوصول')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40099 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'LeaveDate', N'Leave Date')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40100 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'LeaveDate', N'تاريخ المغادرة')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40101 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'title', N'Title')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40102 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'title', N'العنوان')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40103 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Duration', N'Tour Duration')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40104 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'Duration', N'المدة')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40105 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'TourLocation', N'Tour Location')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40106 AS Decimal(18, 0)), NULL, CAST(10002 AS Decimal(18, 0)), N'TourLocation', N'مكان الرحلة')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40107 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'PickupLocation', N'Pickup Location')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40108 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'DropOff', N'Drop Off')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40109 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'TourType', N'Tour Type')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40110 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Overview', N'Overview')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40111 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Highlights', N'Highlights')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40112 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Capacity', N'Capacity')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40113 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'AvaliableDays', N'Avaliable Days')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40114 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Includes', N'Includes')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40115 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Excludes', N'Excludes')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40116 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Expects', N'Expects')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40117 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Packups', N'Packups')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40118 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'TourName', N'Tour Name')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40119 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'UploadFile', N'Upload File')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40120 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'UserName', N'User Name')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40121 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Password', N'Password')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(40122 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'User', N'User')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50005 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Cancellation', N'Cancellation')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50006 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'CancellationText', N'Cancellation requests should be sent via fax or emailed to provide the Company with written confirmation that your reservation should be cancelled.<br>
In case you cancel your trip, the following scale of charges will be applied')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50007 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Refunds', N'Refunds')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50008 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'RefundsText', N'A refund will normally be made to the same account and using the same method used for the original payment.&nbsp;<br> No refunds are possible in the event of a no show for an existing reservation.')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50009 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Accommodation', N'Accommodation')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50010 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'AccommodationText', N'Unless otherwise stated, prices are based on two persons sharing a room (twin sharing). Rooms for single occupants are available with an additional of supplementary rate. Hotels and lodges are named as an indication of quality and rooms may be reserved at an establishment of similar quality. Published prices are inclusive of tariffs and other costs at the time of printing and are subject to change without notice.')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50011 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Responsibility', N'Responsibility')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50014 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'ChildrenPolicy', N'Children Policy')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50016 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Tipping', N'Tipping')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50018 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Complaints', N'Complaints')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50020 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'AcceptanceAagreement', N'Acceptance of the agreement')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50022 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'term', N'term')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50023 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'about', N'about')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50024 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'faq', N'Important questions ')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50025 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'subject', N'subject')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50026 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'order', N'order')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50027 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'infantPrice', N'infant price')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(60022 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'AdditionalInformation', N'Additional Information')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(70022 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Calculated', N'total price')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(70023 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'CalculatedError', N'error in calculated')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(70024 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'NumberOfSelectedRoomNotMatched', N'room number not mathched with number of persons')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50012 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'ResponsibilityText', N'The Company acts only as an agent for the participants in regard to travel, whether by rail road, boat, aircraft, or any other mode of transport, and assume no liability for injury, 
illness, damage, loss, accident, delay, or irregularity to person or property resulting directly or indirectly from any of the following causes: weather, acts of God, force major, acts of government or other authorities, wars, civil disturbances, labor disputes, riots, theft, mechanical breakdowns, quarantines or acts of default, delays, cancellations or changes made by any hotel, carrier, or restaurant.
No responsibility is accepted for any additional expenses.')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50013 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'SpecialRequestsText', N'If the Client has any special requests, he should inform company at the time of booking.
The Company and its suppliers will try to satisfy such requests, but, 
as these do not form part of the contract, the company does not guarantee to do so,
including for pre-bookable seats. If the Company confirms that a special request has been noted or passed on to the supplier or refers to it on the confirmation invoice or elsewhere, this is not a guarantee to fulfill it. The Client will not be specifically notified if a special request cannot be met. The Company does not accept bookings,
which are conditional on the fulfillment of any special request.')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50015 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'ChildrenPolicyText', N'<br>
Policy 1: for packages, Nile cruises, and hotels
Under 5 years old: free of charge<br>
Under 12 years old: 50% of total tour cost for an individual<br>
All children 12 or older are considered adults.<br>
If your tour package includes flights,Trains an extra supplement for your child may apply.<br>
Policy 2: for sightseeing tours &amp; shore excursions<br>
Under 5 years old: free of charge<br>
Under 12 years old: 50% of total tour cost for an individual
All children 12 or older are considered adults.
If your sightseeing tours include domestic flights or ferry boat, an extra supplement for your child may apply.')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50017 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'TippingText', N'Tipping is customary for expressing one’s satisfaction with good services rendered 
to him by staff on duty with him. We advise you to tip as you are willing. 
This will be greatly appreciated by staff, but you are not obligated to do so.')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50019 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'ComplaintsText', N' If you have any complaints while you are in Egypt, please notify the company immediately because most problems can be solved quickly. 
 If you feel that your problem persists call the chairman of the company while you are still on your tour')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50021 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'AcceptanceAagreementText', N'The contract constituted by the company''s acceptance of the client''s booking, subject to these booking conditions, shall constitute the entire agreement between the Client and the Company.<br>
The payment by bank transfer indicates that tour participants have read and accepted all terms and conditions and agree to abide by them.')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(70025 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'CheckOut', N'CheckOut')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50028 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'childPrice', N'child price')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(50029 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'adultPrice', N'adult price')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80022 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'OldPassword', N'Old Password')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80023 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'NewPassword', N'New Password')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80024 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Statistics', N'Statistics')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80025 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Completed', N'Completed')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80026 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'UserInfoLogin', N'Please enter your user information.')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80027 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'SignIn', N'Sign In')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80028 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'ContactUs', N'Contactus')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80029 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Send', N'Send')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80030 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'PlanningForTrip', N'Save your time and pick one of our Dahabiya Nile cruise itineraries which definitely are the best   ')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80031 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'SeeMore', N'See More')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80032 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Find', N'Welcome to our Dahabiya Nile cruise(Anoush)')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80034 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'FindNext', N'Find Next Best')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80035 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'PlaceToVisit', N'Place To Visit')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80036 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'WhoWeAre', N'Who we are')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80070 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Description', N'Description')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80037 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'WhoWeAreDesc', N'Our Dahabiya Nile cruise called (Anoush) which has 12 cabins and 4 suits established on 2024.According to our experience more than 10 years we built our Nile Dahabiya for our guests who demand the best.We design our Dahabiya Nile cruise which offer to our guests the romance of the past with modern comfort and convenience.its a leisurely way to get between Luxor and Aswan and brings together superb sightseeing,Sailing,Delicious traditional meals And attentive personal service.We care when we made our itineraries all our guests categories so they can choose their itinerary with easy way such as their time in Egypt,The most interested places to visit,Add packages includes Cairo,Red sea,Desert oasis and much more so we can meet all our guests satisfaction.Enjoy our Dahabiya facilities,Meals,Drinks and Entertainment.Welcome to (Anoush Dahabiys)')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80038 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'ToursPackages', N'Our Dahabiya itineraries ')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80039 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Booking', N'Booking')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80040 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'PickupDetails', N'Pickup Details')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80041 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Nationality', N'Nationality')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80042 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Date', N'Date')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80043 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Children', N'Children')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80044 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'MaxChildrenAge', N' max age 12')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80045 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'MaxInfantAge', N'max age 3')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80046 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Infant', N'Infant')
GO
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80047 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'NumberOfRoom', N'Number Of Rooms ')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80048 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'PriceForPerson', N'Prices for person.')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80049 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'BookNow', N'Book Now')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80050 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Home', N'Home')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80051 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'OurTours', N'Our Dahabiya itineraries ')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80052 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'TermsAndconditions', N'Terms and conditions')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80053 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'AboutUs', N'About Us')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80054 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'AccountSettings', N'Account Settings')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80055 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'SignOut', N'Sign Out')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80056 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Contact', N'Contact')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80057 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'whyChooseUs', N'why choose us')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80058 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'exceededCapcity', N'number of selected room exceed remaining room fro this day')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80059 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'BookTour', N'Book Tour')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80064 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'GetCode', N'Get Code')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80060 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'ThanksForBookTour', N'Thanks for booking with us.<br><br>Your booking is confirmed and below is your booking details:')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80061 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'wishHappyTour', N'we wish you happy tour and will contact with you before tour')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80062 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'TourName', N'Tour Name')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80063 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Permission', N'Permission')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80076 AS Decimal(18, 0)), NULL, CAST(2 AS Decimal(18, 0)), N'about', N'aaa')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90067 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'additionalActivity', N'additional activity')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90068 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'activity', N'activity')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90069 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'adultPriceForSuite', N'adult Price For Suite')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90070 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'adultPriceForDouble', N'adult Price For Double')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90071 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'TourAvailableLangauges', N'Tour Langauges')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90072 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'AvaliableLanguages', N'Avaliable Languages')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90073 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'SelectAdditionalActivities', N'Select Additional Activities')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90074 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Adults', N'Adults')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90075 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'facilities', N'facilities')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90076 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'description', N'description')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90078 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'BlockedDates', N'Blocked Dates')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90079 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'sessionReference', N'session Reference')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90080 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'keyWords', N'key words')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90081 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'viewport', N'viewport')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90082 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'SeoTools', N'Seo')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90083 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'blog', N'blog')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90085 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'seokeyWords', N'seo key words')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90086 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'seoDescription', N'seo description')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90087 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Tags', N'Tags')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90088 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'RecentBlog', N'Recent Article')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90089 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Articles', N'Articles')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90090 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'DahabyiaSignture', N'Have a nice trip<br> 
Anoush Dahabiya<br> 
booking@anoushdahabiya.com <br>
+201061046797')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90091 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'paymentSuccessfulTitle', N'Your payment was successful')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90092 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'paymentSuccessfulDescription', N' Thank you for your payment. we will <br>
 be in contact with more details shortly')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90093 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'paymentFailedTitle', N'Your payment failed ')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90094 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'paymentFailedDescription', N'Try again later')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90096 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'status', N'status')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90097 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'totalPrice', N'total price')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80065 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'Name', N'name')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80066 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'WhyBookingWithUs', N'Why Booking With Us?')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80073 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'WhatNotIncludes', N'What''s not included')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80074 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'WhatExpects', N'What To Expect (Itinerary)')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(80075 AS Decimal(18, 0)), NULL, CAST(2 AS Decimal(18, 0)), N'Save', N'save2')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90077 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'OurFacilities', N'Our Dahabiya facilities')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90084 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'seoTitle', N'seo title')
INSERT [dbo].[localizations] ([localizeId], [parentLocalizeId], [languageId], [keyName], [value]) VALUES (CAST(90095 AS Decimal(18, 0)), NULL, CAST(1 AS Decimal(18, 0)), N'RelatedBlog', N'Related Articles')
SET IDENTITY_INSERT [dbo].[localizations] OFF
GO
SET IDENTITY_INSERT [dbo].[packs] ON 

INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60049 AS Decimal(18, 0)), N'Visit the amazing three great pyramids of Giza', CAST(16 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60028 AS Decimal(18, 0)), N'Hat.', CAST(27 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60029 AS Decimal(18, 0)), N'Camera.', CAST(27 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60030 AS Decimal(18, 0)), N'Comfortable Shoes.', CAST(27 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60031 AS Decimal(18, 0)), N'Hat.', CAST(28 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60032 AS Decimal(18, 0)), N'Camera.', CAST(28 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60033 AS Decimal(18, 0)), N'Comfortable Shoes.', CAST(28 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60034 AS Decimal(18, 0)), N'Hat.', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60035 AS Decimal(18, 0)), N'Camera.', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60036 AS Decimal(18, 0)), N'Comfortable Shoes.', CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60037 AS Decimal(18, 0)), N'Hat.', CAST(30 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60038 AS Decimal(18, 0)), N'Camera.', CAST(30 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60039 AS Decimal(18, 0)), N'Comfortable Shoes.', CAST(30 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60043 AS Decimal(18, 0)), N'Hat.', CAST(31 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60044 AS Decimal(18, 0)), N'Camera.', CAST(31 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60045 AS Decimal(18, 0)), N'Comfortable Shoes.', CAST(31 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60050 AS Decimal(18, 0)), N'Hat.', CAST(24 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60051 AS Decimal(18, 0)), N'Camera.', CAST(24 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60052 AS Decimal(18, 0)), N'Comfortable Shoes.', CAST(24 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60053 AS Decimal(18, 0)), N'test', CAST(25 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60054 AS Decimal(18, 0)), N'Egyptology Tour Guide', CAST(25 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60055 AS Decimal(18, 0)), N'Hat.', CAST(26 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60056 AS Decimal(18, 0)), N'Camera.', CAST(26 AS Decimal(18, 0)))
INSERT [dbo].[packs] ([packId], [title], [tourId]) VALUES (CAST(60057 AS Decimal(18, 0)), N'Comfortable Shoes.', CAST(26 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[packs] OFF
GO
SET IDENTITY_INSERT [dbo].[permissions] ON 

INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(1 AS Decimal(18, 0)), N'user', N'add', NULL, N'add user', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(2 AS Decimal(18, 0)), N'role', N'role', N'Y', N'view role', N'<i class="fa fa-lock" style="margin:0px 8px;"></i>')
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(3 AS Decimal(18, 0)), N'user', N'user', N'Y', N'view user', N'<i class="fa fa-user" style="margin:0px 8px;"></i>')
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(4 AS Decimal(18, 0)), N'user', N'edit', NULL, N'edit user', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(14 AS Decimal(18, 0)), N'language', N'language', N'Y', N'view language', N'<i class="fa fa-language" style="margin:0px 8px;"></i>')
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(15 AS Decimal(18, 0)), N'language', N'add', NULL, N'add language', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(20019 AS Decimal(18, 0)), N'language', N'delete', NULL, N'delete language', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(20020 AS Decimal(18, 0)), N'language', N'edit', NULL, N'edit language', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(18 AS Decimal(18, 0)), N'user', N'delete', NULL, N'delete user', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(19 AS Decimal(18, 0)), N'role', N'add', NULL, N'add role', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(20 AS Decimal(18, 0)), N'role', N'delete', NULL, N'delete role', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(21 AS Decimal(18, 0)), N'tour', N'tour', N'Y', N'view tours', N'<i class="fa fa-plane" style="margin:0px 8px;"></i>')
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(22 AS Decimal(18, 0)), N'tour', N'add', NULL, N'add tours', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(23 AS Decimal(18, 0)), N'tour', N'edit', NULL, N'edit tours', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(24 AS Decimal(18, 0)), N'tour', N'delete', NULL, N'delete tours', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(25 AS Decimal(18, 0)), N'request', N'request', N'Y', N'view request', N'<i class="fa fa-money-check" style="margin:0px 8px;"></i>')
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(27 AS Decimal(18, 0)), N'contact', N'contact', N'Y', N'view contact', N'<i class="fa fa-users" style="margin:0px 8px;"></i>')
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(29 AS Decimal(18, 0)), N'SpecialRequest', N'SpecialRequest', N'Y', N'view specialRequest', N'<i class="fa fa-plane" style="margin:0px 8px;"></i>')
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(10014 AS Decimal(18, 0)), N'localization', N'localization', N'Y', N'view Localization', N'<i class="fa fa-language" style="margin:0px 8px;"></i>')
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(10015 AS Decimal(18, 0)), N'localization', N'add', NULL, N'add Localization', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(10016 AS Decimal(18, 0)), N'localization', N'edit', NULL, N'edit Localization', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(20014 AS Decimal(18, 0)), N'pricing', N'pricing', N'Y', N'view pricing', N'<i class="fa fa-dollar-sign" style="margin:0px 8px;"></i>')
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(20015 AS Decimal(18, 0)), N'pricing', N'add', NULL, N'add pricing', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(20016 AS Decimal(18, 0)), N'pricing', N'edit', NULL, N'edit pricing', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(20017 AS Decimal(18, 0)), N'pricing', N'delete', NULL, N'delete pricing', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(20018 AS Decimal(18, 0)), N'localization', N'delete', NULL, N'delete localization', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(30018 AS Decimal(18, 0)), N'role', N'edit', NULL, N'edit role', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40018 AS Decimal(18, 0)), N'admin', N'term', N'Y', N'view term', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40019 AS Decimal(18, 0)), N'term', N'add', NULL, N'add term', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40020 AS Decimal(18, 0)), N'term', N'edit', NULL, N'edit term', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40021 AS Decimal(18, 0)), N'term', N'delete', NULL, N'delete term', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40022 AS Decimal(18, 0)), N'admin', N'about', N'Y', N'view about', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40023 AS Decimal(18, 0)), N'about', N'add', NULL, N'add about', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40024 AS Decimal(18, 0)), N'about', N'edit', NULL, N'edit about', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40025 AS Decimal(18, 0)), N'about', N'delete', NULL, N'delete about', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40026 AS Decimal(18, 0)), N'admin', N'faq', N'Y', N'view faq', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40027 AS Decimal(18, 0)), N'faq', N'add', NULL, N'add faq', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40028 AS Decimal(18, 0)), N'faq', N'edit', NULL, N'edit faq', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40029 AS Decimal(18, 0)), N'faq', N'delete', NULL, N'delete faq', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40030 AS Decimal(18, 0)), N'setting', N'setting', NULL, N'view setting', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40031 AS Decimal(18, 0)), N'setting', N'edit', NULL, N'edit setting', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40032 AS Decimal(18, 0)), N'admin', N'whyChooseUs', N'Y', N'view whyChooseUs', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40033 AS Decimal(18, 0)), N'whyChooseUs', N'add', NULL, N'add whyChooseUs', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40034 AS Decimal(18, 0)), N'whyChooseUs', N'edit', NULL, N'edit whyChooseUs', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40035 AS Decimal(18, 0)), N'whyChooseUs', N'delete', NULL, N'delete whyChooseUs', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40036 AS Decimal(18, 0)), N'activity', N'activity', N'Y', N'view activity', N'<i class="fa fa-skating" style="margin:0px 8px;"></i>')
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40037 AS Decimal(18, 0)), N'activity', N'add', NULL, N'add activity', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40038 AS Decimal(18, 0)), N'activity', N'edit', NULL, N'edit activity', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40039 AS Decimal(18, 0)), N'activity', N'delete', NULL, N'delete activity', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40040 AS Decimal(18, 0)), N'admin', N'facilities', N'Y', N'view facilities', N'<i class="fa fa-skating" style="margin:0px 8px;"></i>
')
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40041 AS Decimal(18, 0)), N'facilities', N'add', NULL, N'add facilities', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40042 AS Decimal(18, 0)), N'facilities', N'edit', NULL, N'edit facilities', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40043 AS Decimal(18, 0)), N'facilities', N'delete', NULL, N'delete facilities', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40044 AS Decimal(18, 0)), N'blog', N'blog', N'Y', N'view blog', N'<i class="fa fa-newspaper" style="margin:0px 8px;"></i>')
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40045 AS Decimal(18, 0)), N'blog', N'add', NULL, N'add blog', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40046 AS Decimal(18, 0)), N'blog', N'edit', NULL, N'edit blog', NULL)
INSERT [dbo].[permissions] ([permissionId], [permissionArea], [permissionAction], [isMenu], [permissionName], [icon]) VALUES (CAST(40047 AS Decimal(18, 0)), N'blog', N'delete', NULL, N'delete blog', NULL)
SET IDENTITY_INSERT [dbo].[permissions] OFF
GO
SET IDENTITY_INSERT [dbo].[rolePermissions] ON 

INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100480 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100481 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100482 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100483 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(4 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100484 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(14 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100485 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(15 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100486 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(20019 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100487 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(20020 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100488 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(18 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100489 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(19 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100490 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(20 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100491 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(21 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100492 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(22 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100493 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(23 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100494 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(24 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100495 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(25 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100496 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(27 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100497 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(29 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100498 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(10014 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100499 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(10015 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100500 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(10016 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100501 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(20014 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100502 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(20015 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100503 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(20016 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100504 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(20017 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100505 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(20018 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100506 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(30018 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100507 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40018 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100508 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40019 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100509 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40020 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100510 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40021 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100511 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40022 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100512 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40023 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100513 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40024 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100514 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40025 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100515 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40026 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100516 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40027 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100517 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40028 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100518 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40029 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100519 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40030 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100520 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40031 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100521 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40032 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100522 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40033 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100523 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40034 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100524 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40035 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100525 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40036 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100526 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40037 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100527 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40038 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100528 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40039 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(90315 AS Decimal(18, 0)), CAST(30003 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(90316 AS Decimal(18, 0)), CAST(30003 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(90317 AS Decimal(18, 0)), CAST(30003 AS Decimal(18, 0)), CAST(3 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(90318 AS Decimal(18, 0)), CAST(30003 AS Decimal(18, 0)), CAST(4 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(90319 AS Decimal(18, 0)), CAST(30003 AS Decimal(18, 0)), CAST(14 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(90320 AS Decimal(18, 0)), CAST(30003 AS Decimal(18, 0)), CAST(15 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(90321 AS Decimal(18, 0)), CAST(30003 AS Decimal(18, 0)), CAST(20019 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(90322 AS Decimal(18, 0)), CAST(30003 AS Decimal(18, 0)), CAST(20020 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(90323 AS Decimal(18, 0)), CAST(30003 AS Decimal(18, 0)), CAST(18 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(90324 AS Decimal(18, 0)), CAST(30003 AS Decimal(18, 0)), CAST(19 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(90325 AS Decimal(18, 0)), CAST(30003 AS Decimal(18, 0)), CAST(20 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(90326 AS Decimal(18, 0)), CAST(30003 AS Decimal(18, 0)), CAST(21 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(90327 AS Decimal(18, 0)), CAST(30003 AS Decimal(18, 0)), CAST(22 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(90328 AS Decimal(18, 0)), CAST(30003 AS Decimal(18, 0)), CAST(23 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(90329 AS Decimal(18, 0)), CAST(30003 AS Decimal(18, 0)), CAST(24 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(90330 AS Decimal(18, 0)), CAST(30003 AS Decimal(18, 0)), CAST(30018 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100529 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40040 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100530 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40041 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100531 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40042 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100532 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40043 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100533 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40044 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100534 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40045 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100535 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40046 AS Decimal(18, 0)))
INSERT [dbo].[rolePermissions] ([rolePermissionsId], [roleId], [permissionId]) VALUES (CAST(100536 AS Decimal(18, 0)), CAST(20007 AS Decimal(18, 0)), CAST(40047 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[rolePermissions] OFF
GO
SET IDENTITY_INSERT [dbo].[roles] ON 

INSERT [dbo].[roles] ([roleId], [roleName]) VALUES (CAST(20007 AS Decimal(18, 0)), N'admin')
SET IDENTITY_INSERT [dbo].[roles] OFF
GO
SET IDENTITY_INSERT [dbo].[roomType] ON 

INSERT [dbo].[roomType] ([roomTypeId], [roomTypeName], [icon]) VALUES (1, N'single', NULL)
INSERT [dbo].[roomType] ([roomTypeId], [roomTypeName], [icon]) VALUES (2, N'single + child', NULL)
INSERT [dbo].[roomType] ([roomTypeId], [roomTypeName], [icon]) VALUES (3, N'double', NULL)
INSERT [dbo].[roomType] ([roomTypeId], [roomTypeName], [icon]) VALUES (4, N'double + child', NULL)
INSERT [dbo].[roomType] ([roomTypeId], [roomTypeName], [icon]) VALUES (5, N'Suite', NULL)
INSERT [dbo].[roomType] ([roomTypeId], [roomTypeName], [icon]) VALUES (6, N'Suite + child', NULL)
SET IDENTITY_INSERT [dbo].[roomType] OFF
GO
SET IDENTITY_INSERT [dbo].[seo] ON 

INSERT [dbo].[seo] ([seoId], [title], [description], [keyWords], [viewport]) VALUES (1, N'Anoush dahabiya', N'Anoush dahabiya Travels Agency Over all the World , the company located in egypt', N'Anoush,dahabiya,Egypt tour,Egypt trip,Tour, Travels, agency, business, corporate, tour packages, journey, trip, tailwind css, Admin, Landing', N'width=device-width, initial-scale=1, shrink-to-fit=no')
SET IDENTITY_INSERT [dbo].[seo] OFF
GO
SET IDENTITY_INSERT [dbo].[settings] ON 

INSERT [dbo].[settings] ([settingId], [keyName], [value]) VALUES (1, N'whatsapp', N'+201061046797')
INSERT [dbo].[settings] ([settingId], [keyName], [value]) VALUES (2, N'facebook', N'https://www.facebook.com/anoushdahabiya?mibextid=ZbWKwL')
INSERT [dbo].[settings] ([settingId], [keyName], [value]) VALUES (3, N'instgram', N'https://www.instagram.com/anoushdahabiya/profilecard/?igsh=MTJqcXE3b24xOTlwMw==')
INSERT [dbo].[settings] ([settingId], [keyName], [value]) VALUES (4, N'youtube', N'https://www.youtube.com/')
INSERT [dbo].[settings] ([settingId], [keyName], [value]) VALUES (5, N'twitter', N'https://x.com/Anoushdahabiya')
INSERT [dbo].[settings] ([settingId], [keyName], [value]) VALUES (7, N'email', N'booking@anoushdahabiya.com')
INSERT [dbo].[settings] ([settingId], [keyName], [value]) VALUES (1007, N'tiktok', N'https://www.tiktok.com/@anoushdahabiya?_t=8ruBATjdskX&_r=1')
INSERT [dbo].[settings] ([settingId], [keyName], [value]) VALUES (1008, N'linkedin', N'https://www.linkedin.com/company/anoush-dahabiya')
SET IDENTITY_INSERT [dbo].[settings] OFF
GO
SET IDENTITY_INSERT [dbo].[specialRequests] ON 

INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(1 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Afghan', 1, CAST(N'2024-03-22' AS Date), CAST(N'2024-03-30' AS Date), N'test', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(2 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Afghan', 1, CAST(N'2024-03-22' AS Date), CAST(N'2024-03-30' AS Date), N'test', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(3 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Afghan', 1, CAST(N'2024-03-22' AS Date), CAST(N'2024-03-30' AS Date), N'test', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(4 AS Decimal(18, 0)), N'amrheshmat@gmail.com', N'0595959549', N'تركي محمد احمد باوزير', N'American', 1, CAST(N'2024-03-30' AS Date), CAST(N'2024-03-29' AS Date), N'trest', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(5 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Belizean', 1, CAST(N'2024-03-22' AS Date), CAST(N'2024-03-23' AS Date), N'test', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(6 AS Decimal(18, 0)), N'yasserah9595@gmail.com', N'0595959549', N'yasser mahmoud', N'American', 1, CAST(N'2024-03-30' AS Date), CAST(N'2024-04-06' AS Date), N'sada', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(7 AS Decimal(18, 0)), N'yasserah9595@gmail.com', N'0595959549', N'yasser mahmoud', N'Algerian', 1, CAST(N'2024-04-05' AS Date), CAST(N'2024-04-06' AS Date), N'test', 7, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(8 AS Decimal(18, 0)), N'yasserah9595@gmail.com', N'0595959549', N'yasser mahmoud', N'Egyptian', 1, CAST(N'2024-04-06' AS Date), CAST(N'2024-01-01' AS Date), N'rewe', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(9 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Albanian', 1, CAST(N'2024-03-30' AS Date), CAST(N'2024-04-05' AS Date), N'test', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(10 AS Decimal(18, 0)), N'amrheshmat@gmail.com', N'0595959549', N'تركي محمد احمد باوزير', N'Egyptian', 1, CAST(N'2024-03-30' AS Date), CAST(N'2024-03-30' AS Date), N'test', 77, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(11 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Egyptian', 1, CAST(N'2024-02-02' AS Date), CAST(N'2025-01-01' AS Date), N'we', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(12 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Armenian', 1, CAST(N'2024-03-08' AS Date), CAST(N'2024-03-06' AS Date), N'qqq', 7, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(13 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Egyptian', 1, CAST(N'2024-03-30' AS Date), CAST(N'2024-04-05' AS Date), N'uu', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(14 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Egyptian', 1, CAST(N'2024-04-05' AS Date), CAST(N'2024-03-30' AS Date), N'dd', 5, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(15 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Eritrean', 1, CAST(N'2024-03-30' AS Date), CAST(N'2024-04-06' AS Date), N'ww', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(16 AS Decimal(18, 0)), N'yasserah9595@gmail.com', N'0595959549', N'yasser mahmoud', N'Argentinian', 1, CAST(N'2024-03-30' AS Date), CAST(N'2024-04-06' AS Date), N'?', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(17 AS Decimal(18, 0)), N'yasserah9595@gmail.com', N'0595959549', N'yasser mahmoud', N'American', 1, CAST(N'2024-03-02' AS Date), CAST(N'2024-03-02' AS Date), N'????', 1, 0, 1)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(18 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Afghan', 1, CAST(N'2024-04-06' AS Date), CAST(N'2024-04-06' AS Date), N'111', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(19 AS Decimal(18, 0)), N'yasserah9595@gmail.com', N'2252544040', N'q', N'Belizean', 4, CAST(N'2024-04-04' AS Date), CAST(N'2024-03-29' AS Date), N';;;', 1, 1, 1)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20 AS Decimal(18, 0)), N'yasserah9595@gmail.com', N'2252544040', N'q', N'Ecuadorean', 4, CAST(N'2024-03-30' AS Date), CAST(N'2024-03-15' AS Date), N'44', 4, 4, 4)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(21 AS Decimal(18, 0)), N'yasserah9595@gmail.com', N'2252544040', N'q', N'Albanian', 4, CAST(N'2024-03-30' AS Date), CAST(N'2024-04-06' AS Date), N'aa', 4, 4, 4)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(22 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'0595959549', N'تركي محمد احمد باوزير', N'Albanian', 1, CAST(N'2024-03-30' AS Date), CAST(N'2024-03-30' AS Date), N'a', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(23 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Egyptian', 1, CAST(N'2024-03-29' AS Date), CAST(N'2024-04-05' AS Date), N'???', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(24 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Bolivian', 1, CAST(N'2024-04-06' AS Date), CAST(N'2024-04-06' AS Date), N'kkkk', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(25 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Bolivian', 1, CAST(N'2024-04-06' AS Date), CAST(N'2024-04-06' AS Date), N'kkkk', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(10002 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Bahraini', 1, CAST(N'2024-03-30' AS Date), CAST(N'2024-04-06' AS Date), N'say no', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(10003 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Belizean', 1, CAST(N'2024-04-03' AS Date), CAST(N'2024-04-04' AS Date), N'test', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(10004 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Angolan', 1, CAST(N'2024-03-31' AS Date), CAST(N'2024-04-04' AS Date), N'ooooo', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(10005 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'1', N't', N'Belizean', 3, CAST(N'2024-05-10' AS Date), CAST(N'2024-05-02' AS Date), N'ttt', 1, 1, 1)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20005 AS Decimal(18, 0)), N'salwahere1@gmail.com', N'01026044358', N'Salwa abd al ftah ', N'Australian', 8, CAST(N'2024-11-01' AS Date), CAST(N'2024-11-22' AS Date), N'i want 8 nights', 2, 1, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20006 AS Decimal(18, 0)), N'salwahere1@gmail.com', N'01026044358', N'Salwa abd al ftah ', N'Azerbaijani', 8, CAST(N'2024-02-11' AS Date), CAST(N'2024-10-11' AS Date), N'hi booking dahabiya', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20007 AS Decimal(18, 0)), N'salwahere1@gmail.com', N'01026044358', N'Salwa abd al ftah ', N'Austrian', 8, CAST(N'2024-11-12' AS Date), CAST(N'2024-02-12' AS Date), N'hi hany salwa', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20008 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'1212', N'a', N'Bangladeshi', 3, CAST(N'2024-10-30' AS Date), CAST(N'2024-10-31' AS Date), N'???', 1, 1, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20009 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'1212', N'a', N'American', 2, CAST(N'2024-10-28' AS Date), CAST(N'2024-11-07' AS Date), N'???', 2, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20010 AS Decimal(18, 0)), N'nairamohammed286@gmail.com', N'01285766571', N'Nayera', N'American', 9, CAST(N'2024-11-06' AS Date), CAST(N'2024-11-13' AS Date), N'I want to go to Cairo first ', 2, 1, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20011 AS Decimal(18, 0)), N'rehamhegazi676@gmail.com', N'010', N'a', N'Beninese', 2, CAST(N'2024-11-26' AS Date), CAST(N'2024-11-29' AS Date), N'asadsa', 2, 1, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20013 AS Decimal(18, 0)), N'rehamhegazi676@gmail.com', N'121', N'amr', N'American', 1, CAST(N'2024-11-04' AS Date), CAST(N'2024-11-05' AS Date), N'send', 1, 1, 1)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20014 AS Decimal(18, 0)), N'rehamhegazi676@gmail.com', N'121', N'amr', N'American', 1, CAST(N'2024-11-04' AS Date), CAST(N'2024-11-05' AS Date), N'send', 1, 1, 1)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20015 AS Decimal(18, 0)), N'rehamhegazi676@gmail.com', N'121', N'amr', N'American', 1, CAST(N'2024-11-04' AS Date), CAST(N'2024-11-05' AS Date), N'send', 1, 1, 1)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20016 AS Decimal(18, 0)), N'rehamhegazi676@gmail.com', N'010', N'amr', N'American', 2, CAST(N'2024-11-05' AS Date), CAST(N'2024-11-06' AS Date), N'sad', 1, 1, 1)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20017 AS Decimal(18, 0)), N'rehamhegazi676@gmail.com', N'0100', N'amr', N'Egyptian', 1, CAST(N'2024-11-06' AS Date), CAST(N'2024-11-08' AS Date), N'test special request', 1, 1, 1)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20018 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'0100', N'amr', N'Bangladeshi', 1, CAST(N'2024-11-07' AS Date), CAST(N'2024-11-20' AS Date), N'ree', 1, 1, 1)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20019 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'0100', N'amr', N'American', 5, CAST(N'2024-11-06' AS Date), CAST(N'2024-11-12' AS Date), N'sfsdfg', 1, 1, 1)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20020 AS Decimal(18, 0)), N'salwahere1@gmail.com', N'01157553375', N'Salwa abd al ftah ', N'Austrian', 8, CAST(N'2025-08-06' AS Date), CAST(N'2025-06-05' AS Date), N'hi i want book cabin', 2, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20021 AS Decimal(18, 0)), N'amrheshmat95@gmail.com', N'01003051936', N'amr heshmat', N'Andorran', 2, CAST(N'2024-12-26' AS Date), CAST(N'2024-12-27' AS Date), N'Te', 1, 0, 0)
INSERT [dbo].[specialRequests] ([specialRequestId], [email], [phone], [name], [countryName], [nights], [arriveDate], [leaveDate], [message], [numberOfAdult], [numberOfChild], [numberOfInfant]) VALUES (CAST(20012 AS Decimal(18, 0)), N'rehamhegazi676@gmail.com', N'121', N'a', N'Bangladeshi', 1, CAST(N'2024-11-05' AS Date), CAST(N'2024-11-12' AS Date), N'asada', 1, 1, 1)
SET IDENTITY_INSERT [dbo].[specialRequests] OFF
GO
SET IDENTITY_INSERT [dbo].[terms] ON 

INSERT [dbo].[terms] ([termId], [title], [subject], [orderId], [languageId]) VALUES (1, N'Refunds', N'A refund will normally be made to the same account and using the same method used for the original payment.&nbsp;<br> No refunds are possible in the event of a no show for an existing reservation.', 2, 1)
INSERT [dbo].[terms] ([termId], [title], [subject], [orderId], [languageId]) VALUES (6, N'Accommodation', N'Unless otherwise stated, prices are based on two persons sharing a room (twin sharing). Rooms for single occupants are available with an additional of supplementary rate. Hotels and lodges are named as an indication of quality and rooms may be reserved at an establishment of similar quality. Published prices are inclusive of tariffs and other costs at the time of printing and are subject to change without notice.', 3, 1)
INSERT [dbo].[terms] ([termId], [title], [subject], [orderId], [languageId]) VALUES (1014, N'Cancellation:', N'Cancellation requests should be sent via email to provide the Company with written confirmation that your reservation should be cancelled.
In case you cancel your trip, the following scale of charges will be applied :

(1)You can cancel 5 days before your travel date and you will get full refund.
(2) 30% from the total amount will be charged for cancellations between 4-2 days prior to your travel date.
(3)50% from the total amount will be charged for cancellations less than 2 days prior to your travel date.
(4) In case of no show, full amount will be charged as cancellation fees.
', 0, 1)
INSERT [dbo].[terms] ([termId], [title], [subject], [orderId], [languageId]) VALUES (8, N'Responsibility', N'The Company acts only as an agent for the participants in regard to travel, whether by rail road, boat, aircraft, or any other mode of transport, and assume no liability for injury, illness, damage, loss, accident, delay, or irregularity to person or property resulting directly or indirectly from any of the following causes: weather, acts of God, force major, acts of government or other authorities, wars, civil disturbances, labor disputes, riots, theft, mechanical breakdowns, quarantines or acts of default, delays, cancellations or changes made by any hotel, carrier, or restaurant. No responsibility is accepted for any additional expenses.', 4, 1)
INSERT [dbo].[terms] ([termId], [title], [subject], [orderId], [languageId]) VALUES (9, N'Special Requests', N'If the Client has any special requests, he should inform company at the time of booking. The Company and its suppliers will try to satisfy such requests, but, as these do not form part of the contract, the company does not guarantee to do so, including for pre-bookable seats. If the Company confirms that a special request has been noted or passed on to the supplier or refers to it on the confirmation invoice or elsewhere, this is not a guarantee to fulfill it. The Client will not be specifically notified if a special request cannot be met. The Company does not accept bookings, which are conditional on the fulfillment of any special request.', 5, 1)
INSERT [dbo].[terms] ([termId], [title], [subject], [orderId], [languageId]) VALUES (10, N'Children Policy', N'Children policy:
<br>
(Up to 2 years free of charge.)
<br>
(Age from 2 and below 5 years : 15% of adult price)

<br>
(Age from 5 up to 11 years : 50% of adult price )

<br>
(Ages 12 years and up : adult price)

<br>
<br>

Note:
<br>
 Child pricing applies to children who share rooms with their parents (max 1 children in each room)', 6, 1)
INSERT [dbo].[terms] ([termId], [title], [subject], [orderId], [languageId]) VALUES (11, N'Tipping', N'
Tipping is customary for expressing one’s satisfaction with good services rendered to him by staff on duty with him. We advise you to tip as you are willing. This will be greatly appreciated by staff, but you are not obligated to do so.', 7, 1)
INSERT [dbo].[terms] ([termId], [title], [subject], [orderId], [languageId]) VALUES (12, N'Complaints', N'
If you have any complaints while you are in Egypt, please notify the company immediately because most problems can be solved quickly. If you feel that your problem persists call the chairman of the company while you are still on your tour', 8, 1)
INSERT [dbo].[terms] ([termId], [title], [subject], [orderId], [languageId]) VALUES (13, N'Acceptance of the agreement', N'The contract constituted by the company''s acceptance of the client''s booking, subject to these booking conditions, shall constitute the entire agreement between the Client and the Company.<br>
The payment by bank transfer indicates that tour participants have read and accepted all terms and conditions and agree to abide by them.<br>', 9, 1)
INSERT [dbo].[terms] ([termId], [title], [subject], [orderId], [languageId]) VALUES (14, N'test', N'te', 1, 2)
SET IDENTITY_INSERT [dbo].[terms] OFF
GO
SET IDENTITY_INSERT [dbo].[tourAdditionalActivities] ON 

INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (774, 43, 2)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (775, 43, 3)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (776, 43, 4)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (777, 43, 5)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (778, 43, 6)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (572, 44, 2)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (769, 34, 2)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (574, 45, 3)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (770, 34, 3)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (771, 34, 4)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (772, 34, 5)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (773, 34, 6)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (726, 42, 2)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (727, 42, 3)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (728, 42, 4)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (729, 42, 5)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (730, 42, 6)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (731, 41, 2)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (732, 41, 3)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (733, 41, 4)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (734, 41, 5)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (735, 41, 6)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (736, 35, 2)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (737, 35, 3)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (738, 35, 4)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (739, 35, 5)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (740, 35, 6)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (741, 37, 2)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (742, 37, 3)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (743, 37, 4)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (744, 37, 5)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (745, 37, 6)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (746, 40, 2)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (747, 40, 3)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (748, 40, 4)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (749, 40, 5)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (750, 40, 6)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (754, 29, 2)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (755, 29, 3)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (756, 29, 4)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (757, 29, 5)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (758, 29, 6)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (764, 36, 2)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (765, 36, 3)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (766, 36, 4)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (767, 36, 5)
INSERT [dbo].[tourAdditionalActivities] ([id], [tourId], [activityId]) VALUES (768, 36, 6)
SET IDENTITY_INSERT [dbo].[tourAdditionalActivities] OFF
GO
SET IDENTITY_INSERT [dbo].[tourAttachments] ON 

INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40062 AS Decimal(18, 0)), N'ef404bb4-0f2c-452e-afd3-ebcbb689a350.jpg', N'0', CAST(34 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40081 AS Decimal(18, 0)), N'1f88ffef-8c71-4f63-97cb-4b63aa86444f.jpeg', N'0', CAST(36 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40056 AS Decimal(18, 0)), N'd7f83841-5bf2-412a-8d03-87187f8d6553.jpg', N'0', CAST(29 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40057 AS Decimal(18, 0)), N'50d37a0d-af7b-4a05-97a1-e449f5224e4a.jpg', N'1', CAST(29 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40058 AS Decimal(18, 0)), N'b34ee8f0-6882-4f73-8f80-67927706f59c.jpg', N'2', CAST(29 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40059 AS Decimal(18, 0)), N'f11575ce-308e-46ab-9c67-f94533cb6c83.jpg', N'3', CAST(29 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40060 AS Decimal(18, 0)), N'f95b4164-b94a-47bd-b193-a72b23da857e.jpeg', N'4', CAST(29 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40061 AS Decimal(18, 0)), N'fda6c548-4f61-49a1-b2f5-46aee3e60ec1.jpeg', N'5', CAST(29 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40063 AS Decimal(18, 0)), N'2807c0ad-5130-49bb-95d4-718cd20b1771.jpeg', N'1', CAST(34 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40064 AS Decimal(18, 0)), N'7f11fe09-4c77-4593-a079-d86cd1278a06.jpeg', N'2', CAST(34 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40065 AS Decimal(18, 0)), N'4d6e063c-310b-45f1-9978-4b1f038fc4b0.jpeg', N'3', CAST(34 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40082 AS Decimal(18, 0)), N'2e7d64c2-a2a3-4a66-89e5-47d99b6f2444.jpeg', N'1', CAST(36 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40083 AS Decimal(18, 0)), N'1a40224b-91bf-4d98-bc9f-a1221638299e.jpeg', N'2', CAST(36 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40084 AS Decimal(18, 0)), N'd87210e6-b8aa-4c87-9473-4e5d6ad66bf7.jpeg', N'3', CAST(36 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40085 AS Decimal(18, 0)), N'74098e7c-e012-4426-9697-6accf41db672.jpeg', N'4', CAST(36 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40086 AS Decimal(18, 0)), N'c0a06cbf-1aea-4f46-9e84-06b99d865c9c.jpeg', N'0', CAST(35 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40087 AS Decimal(18, 0)), N'3ed98203-bec1-4292-9383-c79ce657a1c1.jpeg', N'1', CAST(35 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40088 AS Decimal(18, 0)), N'ecf307d0-8245-4c6d-ac1f-ebb083d4411f.jpeg', N'2', CAST(35 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40089 AS Decimal(18, 0)), N'71e27f0c-8f78-49c1-a960-2c261cf61ec2.jpeg', N'3', CAST(35 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40090 AS Decimal(18, 0)), N'537c6927-9833-4d90-add1-63e5f6a4099a.jpeg', N'4', CAST(35 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40091 AS Decimal(18, 0)), N'154930b4-af2e-4172-8dfb-610446d097e6.jpg', N'0', CAST(37 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40096 AS Decimal(18, 0)), N'784d10dc-5ae2-4d81-88d2-0bee33c0d2f3.jpeg', N'0', CAST(40 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40097 AS Decimal(18, 0)), N'57d1a783-33be-41a1-b9b3-81f7211d62f9.jpeg', N'0', CAST(41 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40098 AS Decimal(18, 0)), N'f3476704-c1c5-4669-a528-6d36f4f29454.jpeg', N'1', CAST(41 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40099 AS Decimal(18, 0)), N'f045dfed-cf30-46ae-86d3-07b9140e9925.jpeg', N'0', CAST(42 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40100 AS Decimal(18, 0)), N'5ed688ee-fdca-42b2-958b-64a2c3e57b35.jpeg', N'1', CAST(42 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40101 AS Decimal(18, 0)), N'1b2053b7-ae4d-4cd2-8414-819dd718aff3.jpeg', N'0', CAST(43 AS Decimal(18, 0)), NULL, NULL)
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40130 AS Decimal(18, 0)), N'3f06e7bb-94fd-4fbc-b261-2bcd8e51d206.jpg', N'0', CAST(4 AS Decimal(18, 0)), NULL, N'facilities')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40105 AS Decimal(18, 0)), N'e285181f-62ac-4681-9c33-dc66bf965dcd.png', N'0', CAST(2 AS Decimal(18, 0)), NULL, N'facilities')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40149 AS Decimal(18, 0)), N'c83ed0d8-f5e1-44ef-aa67-79311706cd9d.png', N'0', CAST(1 AS Decimal(18, 0)), NULL, N'facilities')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(50191 AS Decimal(18, 0)), N'7c749af3-c27e-454f-9d60-607bc4b42b4b.webp', N'0', CAST(34 AS Decimal(18, 0)), NULL, N'tour')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40108 AS Decimal(18, 0)), N'7c749af3-c27e-454f-9d60-607bc4b42b4b.webp', N'0', CAST(44 AS Decimal(18, 0)), NULL, N'tour')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40159 AS Decimal(18, 0)), N'da131533-79d5-4739-9cb5-9688795f1886.PNG', N'0', CAST(8 AS Decimal(18, 0)), NULL, N'facilities')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(50192 AS Decimal(18, 0)), N'7c749af3-c27e-454f-9d60-607bc4b42b4b.webp', N'0', CAST(40 AS Decimal(18, 0)), NULL, N'tour')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(50193 AS Decimal(18, 0)), N'7c749af3-c27e-454f-9d60-607bc4b42b4b.webp', N'0', CAST(36 AS Decimal(18, 0)), NULL, N'tour')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40135 AS Decimal(18, 0)), N'7c749af3-c27e-454f-9d60-607bc4b42b4b.webp', N'0', CAST(37 AS Decimal(18, 0)), NULL, N'tour')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(50194 AS Decimal(18, 0)), N'7c749af3-c27e-454f-9d60-607bc4b42b4b.webp', N'0', CAST(35 AS Decimal(18, 0)), NULL, N'tour')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40150 AS Decimal(18, 0)), N'7c749af3-c27e-454f-9d60-607bc4b42b4b.webp', N'0', CAST(45 AS Decimal(18, 0)), NULL, N'tour')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40156 AS Decimal(18, 0)), N'cddb4444-2537-4cc0-b5fb-61f261af45ef.png', N'0', CAST(9 AS Decimal(18, 0)), NULL, N'facilities')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40160 AS Decimal(18, 0)), N'949bd805-9168-4699-b030-426d6f0762c9.PNG', N'0', CAST(5 AS Decimal(18, 0)), NULL, N'facilities')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40169 AS Decimal(18, 0)), N'0e5a1c38-422d-47eb-992c-2e1135df040e.jpg', N'0', CAST(3 AS Decimal(18, 0)), NULL, N'blog')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40171 AS Decimal(18, 0)), N'93a4d2f8-3af8-4467-a929-4ee95063f872.jpg', N'0', CAST(4 AS Decimal(18, 0)), NULL, N'blog')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40173 AS Decimal(18, 0)), N'6e379369-15a7-4337-a787-fc5569d0dd3c.jpg', N'0', CAST(2 AS Decimal(18, 0)), NULL, N'blog')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40172 AS Decimal(18, 0)), N'dc16e464-4fc8-4b79-b7b5-68e847c3e5dc.jpg', N'0', CAST(5 AS Decimal(18, 0)), NULL, N'blog')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40170 AS Decimal(18, 0)), N'71a5110d-c742-46c1-9b13-d13e056aa636.jpg', N'0', CAST(1 AS Decimal(18, 0)), NULL, N'blog')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40187 AS Decimal(18, 0)), N'62faaf82-1012-4834-ae68-39a0a0bba30c.jpg', N'0', CAST(1 AS Decimal(18, 0)), NULL, N'language')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40184 AS Decimal(18, 0)), N'963b8e16-6aa6-4b7f-83ed-ea8d7b8ad799.jpg', N'0', CAST(2 AS Decimal(18, 0)), NULL, N'language')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40178 AS Decimal(18, 0)), N'4c9b0721-2319-4462-aed1-0209942223f7.png', N'0', CAST(10003 AS Decimal(18, 0)), NULL, N'language')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40185 AS Decimal(18, 0)), N'64014a4f-e953-42e6-91db-1e3b069b0c16.png', N'0', CAST(2 AS Decimal(18, 0)), NULL, N'aboutus')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(50195 AS Decimal(18, 0)), N'7c749af3-c27e-454f-9d60-607bc4b42b4b.webp', N'0', CAST(41 AS Decimal(18, 0)), NULL, N'tour')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40151 AS Decimal(18, 0)), N'e7067298-2071-4ba7-b421-a35b65178919.png', N'0', CAST(3 AS Decimal(18, 0)), NULL, N'facilities')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40153 AS Decimal(18, 0)), N'568e35dd-3de8-4550-9adb-056398dccc9b.png', N'0', CAST(6 AS Decimal(18, 0)), NULL, N'facilities')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(40154 AS Decimal(18, 0)), N'a84bd025-7caf-4e80-b752-3896c6731ed8.png', N'0', CAST(7 AS Decimal(18, 0)), NULL, N'facilities')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(50188 AS Decimal(18, 0)), N'7c749af3-c27e-454f-9d60-607bc4b42b4b.webp', N'0', CAST(42 AS Decimal(18, 0)), NULL, N'tour')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(50189 AS Decimal(18, 0)), N'7c749af3-c27e-454f-9d60-607bc4b42b4b.webp', N'0', CAST(43 AS Decimal(18, 0)), NULL, N'tour')
INSERT [dbo].[tourAttachments] ([tourAttachmentId], [attachmentPath], [attachmentName], [tourId], [isMainAttachment], [type]) VALUES (CAST(50190 AS Decimal(18, 0)), N'7c749af3-c27e-454f-9d60-607bc4b42b4b.webp', N'0', CAST(29 AS Decimal(18, 0)), NULL, N'tour')
SET IDENTITY_INSERT [dbo].[tourAttachments] OFF
GO
SET IDENTITY_INSERT [dbo].[tourDays] ON 

INSERT [dbo].[tourDays] ([tourDayId], [dayId], [tourId]) VALUES (7336, 1, 44)
INSERT [dbo].[tourDays] ([tourDayId], [dayId], [tourId]) VALUES (7402, 0, 34)
INSERT [dbo].[tourDays] ([tourDayId], [dayId], [tourId]) VALUES (7338, 1, 45)
INSERT [dbo].[tourDays] ([tourDayId], [dayId], [tourId]) VALUES (7393, 5, 42)
INSERT [dbo].[tourDays] ([tourDayId], [dayId], [tourId]) VALUES (7394, 3, 41)
INSERT [dbo].[tourDays] ([tourDayId], [dayId], [tourId]) VALUES (7395, 5, 35)
INSERT [dbo].[tourDays] ([tourDayId], [dayId], [tourId]) VALUES (7396, 3, 37)
INSERT [dbo].[tourDays] ([tourDayId], [dayId], [tourId]) VALUES (7397, 4, 40)
INSERT [dbo].[tourDays] ([tourDayId], [dayId], [tourId]) VALUES (7399, 5, 29)
INSERT [dbo].[tourDays] ([tourDayId], [dayId], [tourId]) VALUES (7401, 1, 36)
INSERT [dbo].[tourDays] ([tourDayId], [dayId], [tourId]) VALUES (7403, 6, 43)
SET IDENTITY_INSERT [dbo].[tourDays] OFF
GO
SET IDENTITY_INSERT [dbo].[tourLanguages] ON 

INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (724, 1, 44, N'english')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (908, 1, 34, N'english')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (726, 1, 45, N'english')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (909, 2, 34, N'french')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (910, 10003, 34, N'Spanish')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (881, 1, 42, N'english')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (882, 2, 42, N'french')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (883, 10003, 42, N'Spanish')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (884, 1, 41, N'english')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (885, 2, 41, N'french')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (886, 10003, 41, N'Spanish')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (887, 1, 35, N'english')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (888, 2, 35, N'french')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (889, 10003, 35, N'Spanish')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (890, 1, 37, N'english')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (891, 2, 37, N'french')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (892, 10003, 37, N'Spanish')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (893, 1, 40, N'english')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (894, 2, 40, N'french')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (895, 10003, 40, N'Spanish')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (899, 1, 29, N'english')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (900, 2, 29, N'french')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (901, 10003, 29, N'Spanish')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (905, 1, 36, N'english')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (906, 2, 36, N'french')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (907, 10003, 36, N'Spanish')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (911, 1, 43, N'english')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (912, 2, 43, N'french')
INSERT [dbo].[tourLanguages] ([tourLanguageId], [languageId], [tourId], [languageName]) VALUES (913, 10003, 43, N'Spanish')
SET IDENTITY_INSERT [dbo].[tourLanguages] OFF
GO
SET IDENTITY_INSERT [dbo].[tours] ON 

INSERT [dbo].[tours] ([tourId], [duration], [tourLocation], [tourDays], [pickupLocation], [dropOff], [tourType], [overview], [includeId], [exculdeId], [highlights], [expectId], [packId], [adultPrice], [capacity], [title], [childPrice], [infantPrice], [languageId], [adultPriceForDouble], [adultPriceForSuite], [isActive]) VALUES (CAST(34 AS Decimal(18, 0)), N'6', N'Luxor, Aswan,  Edfu, Kom Ombo, local village, Esna And Gebel El-Silsela', NULL, N'From luxor Hotels,Train station or luxor Airport', N'To Aswan  Hotels,Train station or Aswan Airport', N'join tours', NULL, NULL, NULL, N'Dahabyia tour package is the best way to discover Egypt.
<br>
<br>

Sail from Luxor to Aswan and take unique photos of the splendid Islands. 
<br>
<br>
Have some fun with our staff during sailing in our cultural parties on board. 
<br>
<br>
Listen well to your professional tour guide who will tell you attractive stories about the hidden Egyptian culture. 
<br>
<br>
Watch the Dahabiya captins while they move slowly from island to island during sailing. 
<br>
<br>
Explore temples,islands,nature and much more. 
<br>
<br>
Door to door transfers from and to your destinations in Luxor and Aswan
<br>
<br>
', NULL, NULL, CAST(1150.00 AS Decimal(10, 2)), CAST(12 AS Decimal(10, 0)), N'5 Nights-6 days Nile Dahabiya Including Tours From Luxor to Aswan', CAST(360.00 AS Decimal(18, 2)), CAST(110.00 AS Decimal(18, 2)), 1, CAST(720.00 AS Decimal(18, 2)), CAST(960.00 AS Decimal(18, 2)), N'Y')
INSERT [dbo].[tours] ([tourId], [duration], [tourLocation], [tourDays], [pickupLocation], [dropOff], [tourType], [overview], [includeId], [exculdeId], [highlights], [expectId], [packId], [adultPrice], [capacity], [title], [childPrice], [infantPrice], [languageId], [adultPriceForDouble], [adultPriceForSuite], [isActive]) VALUES (CAST(29 AS Decimal(18, 0)), N'5', N'Aswan, Luxor, Edfu,Kom Ombo, Esna And Gebel El-Silsila', NULL, N'From Aswan Hotels,Train station or Aswan Airport', N'To Luxor Hotels,Train station or Luxor Airport', N'join tours', NULL, NULL, NULL, N'Relax on Dahabiya sun deck this is the real taste of Egypt in the best way you can see.
<br>
<br>
We choose this 5 days Nile Dahabiya tour package from Aswan to Luxor to our guests who request the Best.
<br>
<br>
Discover Aswan city the beautiful queen located in the last point of southern Egypt.
<br>
<br>
Enjoy Sailing Between Aswan And Luxor And have unique photos of the splendid islands.
<br>
<br>
Touch the great hidden culture of Egypt during sailing.
<br>
<br>
Visit the most famous temples in Egypt such as Valley of the kings,Philae temple and so much more.

', NULL, NULL, CAST(960.00 AS Decimal(10, 2)), CAST(4 AS Decimal(10, 0)), N'4 Nights-5 days Nile Dahabiya Including Tours  From Aswan to Luxor', CAST(300.00 AS Decimal(18, 2)), CAST(90.00 AS Decimal(18, 2)), 1, CAST(600.00 AS Decimal(18, 2)), CAST(800.00 AS Decimal(18, 2)), N'Y')
INSERT [dbo].[tours] ([tourId], [duration], [tourLocation], [tourDays], [pickupLocation], [dropOff], [tourType], [overview], [includeId], [exculdeId], [highlights], [expectId], [packId], [adultPrice], [capacity], [title], [childPrice], [infantPrice], [languageId], [adultPriceForDouble], [adultPriceForSuite], [isActive]) VALUES (CAST(36 AS Decimal(18, 0)), N'8', N'Luxor,Aswan,Edfu,Kom Ombo,local village,Esna and Gebel El Silsila', NULL, N'From Luxor hotels,train station Or Luxor airport', N'To Luxor hotels,train station Or Luxor airport', N'Join tours', NULL, NULL, NULL, N'Listen to the Nile whispers and the Natural quietness in A fabulous 7 nights-8 days Nile Dahabiya tour package.
<br>
<br>
Enjoy the splendid views of the pure islands in a two ways of sailing starting from Luxor Ending also in Luxor.
<br>
<br>
Take it easy and visit the most attractive and important sightseeing in Egypt with a relaxing and smoothly way.
<br>
<br>
Relax with more schedule facilities and have more unique memories and photos of the splendid pure of Egypt .
<br>
<br>
Luxor to Luxor Dahabiya tour package offers you the hidden culture of Egypt in a unique design so you can touch it in your hands.
<br>
<br>
Enjoy your tour package with an expert tour guide,A/C transportation,Entertainment,Meals,Drinks and so much more as in itinerary
<br>
<br>', NULL, NULL, CAST(1580.00 AS Decimal(10, 2)), CAST(10 AS Decimal(10, 0)), N'7 Nights-8 Days Nile Dahabiya Including Tours from Luxor to Luxor', CAST(540.00 AS Decimal(18, 2)), CAST(160.00 AS Decimal(18, 2)), 1, CAST(1060.00 AS Decimal(18, 2)), CAST(1520.00 AS Decimal(18, 2)), N'Y')
INSERT [dbo].[tours] ([tourId], [duration], [tourLocation], [tourDays], [pickupLocation], [dropOff], [tourType], [overview], [includeId], [exculdeId], [highlights], [expectId], [packId], [adultPrice], [capacity], [title], [childPrice], [infantPrice], [languageId], [adultPriceForDouble], [adultPriceForSuite], [isActive]) VALUES (CAST(35 AS Decimal(18, 0)), N'9', N'Cairo,Luxor,Aswan,Edfu,Kom Ombo,local village,Esna and Gebel El-Silsila ', NULL, N'From Cairo hotels Or Cairo airport', N'To Cairo hotels Or Cairo airport', N'Join tours', NULL, NULL, NULL, N'Tour to one of the seven wonders of the world which are the Great Pyramids. 
<br>
<br>
Watch the biggest statue in the world the legendary sphinx.
<br>
<br>
Discover the largest and oldest museum the Egyptian museum which includes the largest collection of Egyptian antiquities in the world. 
<br>
<br>
Enjoy unique sailing from Luxor to Aswan in your Nile Dahabiya with splendid photos of the pure Egyptian nature.
<br>
<br>
Visit Luxor the most famous historical city in Egypt which owns one-third of the world''s monuments. 
<br>
<br>
Find out aswan the beautiful city famous by the nubian culture and the splendid Islands. 
<br>
<br>
Take your imagination far away and spend an unforgettable holiday with memories will last forever', NULL, NULL, CAST(1890.00 AS Decimal(10, 2)), CAST(7 AS Decimal(10, 0)), N'8 Nights-9 Days Cairo and Nile Dahabiya Tour package from Cairo airport', CAST(590.00 AS Decimal(18, 2)), CAST(180.00 AS Decimal(18, 2)), 1, CAST(1180.00 AS Decimal(18, 2)), CAST(1480.00 AS Decimal(18, 2)), N'Y')
INSERT [dbo].[tours] ([tourId], [duration], [tourLocation], [tourDays], [pickupLocation], [dropOff], [tourType], [overview], [includeId], [exculdeId], [highlights], [expectId], [packId], [adultPrice], [capacity], [title], [childPrice], [infantPrice], [languageId], [adultPriceForDouble], [adultPriceForSuite], [isActive]) VALUES (CAST(37 AS Decimal(18, 0)), N'8', N'Cairo,Luxor,Aswan,Edfu,Kom Ombo,Esna and Gebel El Silsila', NULL, N'From Cairo hotels, Or Cairo airport', N'To Cairor hotels,Or Cairo airport', N'Join tours', NULL, NULL, NULL, N'<br>
<br>
Discover the great history of Egypt in your 7 nights best Nile Dahabiya tour package which covers all Egypt. 
<br>
<br>
Touch the fabulous culture of Egypt and tour to Cairo,Luxor,Aswan and much more. 
<br>
<br>
Experience the splendid Egyptian River Nile with unique sailing between Aswan and Luxor. 
<br>
<br>
Visit the most famous historical places in the world  such as the great pyramids and the valley of the kings. 
<br>
<br>
Enjoy the Dahabiya facilities and entertainment with our simple parties on board. 
<br>
<br>
Find out the Egyptian Nile secrets by unique sailing with professional Egyptian sailors .
<br>
<br>
Listen to the Nile stories and more with an expert tour guide who will be with you during the whole tours.
<br>
<br>
Gather between the most famous historical sites in Egypt and the splendid experience of sailing on board Nile Dahabiya
<br>
<br>', NULL, NULL, CAST(1920.00 AS Decimal(10, 2)), CAST(7 AS Decimal(10, 0)), N'7 Nights-8 Days Pyramids and Nile Dahabiya Tour package from Cairo airport', CAST(600.00 AS Decimal(18, 2)), CAST(180.00 AS Decimal(18, 2)), 1, CAST(1200.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), N'Y')
INSERT [dbo].[tours] ([tourId], [duration], [tourLocation], [tourDays], [pickupLocation], [dropOff], [tourType], [overview], [includeId], [exculdeId], [highlights], [expectId], [packId], [adultPrice], [capacity], [title], [childPrice], [infantPrice], [languageId], [adultPriceForDouble], [adultPriceForSuite], [isActive]) VALUES (CAST(40 AS Decimal(18, 0)), N'7', N'Cairo, Aswan,Hurghada, Luxor, Edfu,Kom Ombo, local village, Esna And Gebel El-Silsila', NULL, N'From Cairo airport or Cairo hotels', N'To Cairo airport or Cairo hotels', N'Join tours', NULL, NULL, NULL, N'We design this tour package to our guests who demand the best and have short stay in Egypt. 
<br>
<br>
Going through these fantastic tours with a different culture from Cairo, Luxor, Hurghada,Aswan and more.
<br>
<br>
Enjoy the unique experience with a breathtaking sailing between Aswan and Luxor.
<br>
<br>
Visit the most wonderful and historical places on board the river Nile, great pyramids and Hurghada.
<br>
<br>
Explore the underwater world.seeing the stunning colorful corals that will catch your eyes.
<br>
<br>
Enjoy the Red sea beaches from Hurghada,Snorkel and have some fun.
<br>
<br>
Explore a lifetime trip covering all the unique places in Egypt ,sailing in the Nile river and Snorkeling in our 6 Nights tour package', NULL, NULL, CAST(1760.00 AS Decimal(10, 2)), CAST(2 AS Decimal(10, 0)), N'6 nights-7 days Cairo,Hurghada and Nile Dahabiya tour package from Cairo Airport', CAST(550.00 AS Decimal(18, 2)), CAST(165.00 AS Decimal(18, 2)), 1, CAST(1100.00 AS Decimal(18, 2)), CAST(1400.00 AS Decimal(18, 2)), N'Y')
INSERT [dbo].[tours] ([tourId], [duration], [tourLocation], [tourDays], [pickupLocation], [dropOff], [tourType], [overview], [includeId], [exculdeId], [highlights], [expectId], [packId], [adultPrice], [capacity], [title], [childPrice], [infantPrice], [languageId], [adultPriceForDouble], [adultPriceForSuite], [isActive]) VALUES (CAST(41 AS Decimal(18, 0)), N'10', N'Cairo, Aswan,Hurghada, Luxor, Edfu,Kom Ombo, local village, Esna And Gebel El-Silsila', NULL, N'From Cairo airport or Cairo hotels', N'To Cairo airport or Cairo hotels', N'Join tours', NULL, NULL, NULL, N'Travel back with time and discover the glorious iconic places in Egypt in your 6 nights unique Nile Dahabiya tour package which covers all the interesting places in Egypt.
<br>
<br>
Enjoy talking to the Nile while sailing in this amazing Dahabiya with our small parties on board.
<br>
<br>
Let the Nile river reavel the hidden secrets of the most mysteries culture in the world with a friendly tour guide with you during the entire tours .
<br>
<br>
Find out the healthy white sand,stunning coral reefs and the incredible beaches in a journey to the Red sea.
<br>
<br>
Take it easy with door to door transfers from and to your destinations in Cairo. 
<br>
<br>
Visit the most famous historical sites in Egypt such as the great pyramids and Valley of the kings with an expert tour guide .
<br>
<br>
It''s a once on a lifetime trip covering all the unique places in Egypt,sailing in the Nile river and Snorkeling on Red sea splendid water', NULL, NULL, CAST(2016.00 AS Decimal(10, 2)), CAST(8 AS Decimal(10, 0)), N'9 Nights-10 Days Cairo,Red sea and Nile Dahabiya tour package from Cairo airport', CAST(630.00 AS Decimal(18, 2)), CAST(190.00 AS Decimal(18, 2)), 1, CAST(1260.00 AS Decimal(18, 2)), CAST(1560.00 AS Decimal(18, 2)), N'Y')
INSERT [dbo].[tours] ([tourId], [duration], [tourLocation], [tourDays], [pickupLocation], [dropOff], [tourType], [overview], [includeId], [exculdeId], [highlights], [expectId], [packId], [adultPrice], [capacity], [title], [childPrice], [infantPrice], [languageId], [adultPriceForDouble], [adultPriceForSuite], [isActive]) VALUES (CAST(43 AS Decimal(18, 0)), N'3', N'Aswan,Kom Ombo, Local village, Edfu,Gebel El-Silsila,Esna and Luxor', NULL, N'From Aswan Hotels,Train station or Aswan Airport', N'To Luxor Hotels,Train station or Luxor Airport', N'Join tours', NULL, NULL, NULL, N'Enjoy your meals which freshly prepared on board and served on the sundeck.
<br><br>
Watch the Dahabiya captains who wear Galabyia the official dress in Egypt while they sailing slowly from Aswan to Luxor. 
<br><br>
Enjoy sailing and prepare yourself to have unique photos of the splendid local villages.
<br><br>
Stop in several sites such as Kom Ombo, Edfu and much more to touch the real history of Egypt.
<br><br>
Experience the most exclusive and luxurious way to explore the great Egyptian River Nile on board Nile Dahabiya. 
<br><br>
Find out a leisurely way to get between Aswan and Luxor and brings together superb sightseeing
<br><br>', NULL, NULL, CAST(600.00 AS Decimal(10, 2)), CAST(8 AS Decimal(10, 0)), N'2 Nights-3 Days Nile Dahabiya Including Tours from Aswan to Luxor', CAST(200.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), 1, CAST(400.00 AS Decimal(18, 2)), CAST(500.00 AS Decimal(18, 2)), N'Y')
INSERT [dbo].[tours] ([tourId], [duration], [tourLocation], [tourDays], [pickupLocation], [dropOff], [tourType], [overview], [includeId], [exculdeId], [highlights], [expectId], [packId], [adultPrice], [capacity], [title], [childPrice], [infantPrice], [languageId], [adultPriceForDouble], [adultPriceForSuite], [isActive]) VALUES (CAST(44 AS Decimal(18, 0)), N'1', N'a', NULL, N'a', N'a', N'a', NULL, NULL, NULL, N'as', NULL, NULL, CAST(1.00 AS Decimal(10, 2)), CAST(2 AS Decimal(10, 0)), N'test', CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 1, CAST(2.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[tours] ([tourId], [duration], [tourLocation], [tourDays], [pickupLocation], [dropOff], [tourType], [overview], [includeId], [exculdeId], [highlights], [expectId], [packId], [adultPrice], [capacity], [title], [childPrice], [infantPrice], [languageId], [adultPriceForDouble], [adultPriceForSuite], [isActive]) VALUES (CAST(45 AS Decimal(18, 0)), N'1', N'm', NULL, N'm', N'm', N'm', NULL, NULL, NULL, N'm', NULL, NULL, CAST(1.00 AS Decimal(10, 2)), CAST(2 AS Decimal(10, 0)), N'm', CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), 1, CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), N'N')
INSERT [dbo].[tours] ([tourId], [duration], [tourLocation], [tourDays], [pickupLocation], [dropOff], [tourType], [overview], [includeId], [exculdeId], [highlights], [expectId], [packId], [adultPrice], [capacity], [title], [childPrice], [infantPrice], [languageId], [adultPriceForDouble], [adultPriceForSuite], [isActive]) VALUES (CAST(42 AS Decimal(18, 0)), N'11', N'Cairo,Desert oasis,Luxor,Aswan,Edfu,Kom Ombo,Esna and Local village', NULL, N'From Cairo airport or Cairo hotels', N'To Cairo airport or Cairo hotels', N'Join tours', NULL, NULL, NULL, N'Back to the virgen nature and discover the splendid views of the desert oasis. 
<br>
<br>
Camp,sleep and watch the pure stars on a unique journey to the fabulous desert oasis. 
<br>
<br>
Enjoy the Nile secrets and the wonderful sailing in a unique navigation from Luxor to Aswan. 
<br>
<br>
Cover all Egypt in this special tour package seeing the great pyramids,the desert oasis,Valley of the kings and much more. 
<br>
<br>
Leave the troubles behind you and touch the peaceful nature,the splendid sites and the unique views in a lifetime trip. 
<br>
<br>
Enjoy the Dahabiya facilities,food,drinks and entertainment with our professional staff onboard.
<br>
<br>
Relax on Dahabiya sundeck during sailing this is Egypt in the best way you can see
<br>
<br>', NULL, NULL, CAST(1860.00 AS Decimal(10, 2)), CAST(32 AS Decimal(10, 0)), N'10 Nights-11 Days Cairo,Desert oasis and Nile Dahabiya tour package from Cairo airport', CAST(640.00 AS Decimal(18, 2)), CAST(192.00 AS Decimal(18, 2)), 1, CAST(1280.00 AS Decimal(18, 2)), CAST(1580.00 AS Decimal(18, 2)), N'Y')
SET IDENTITY_INSERT [dbo].[tours] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([userId], [userName], [fullName], [gender], [status], [createdby], [creationDate], [lastUpdateBy], [lastUpdateDate], [email], [mobile], [password], [roleId]) VALUES (CAST(30003 AS Decimal(18, 0)), N'admin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'mostafaalymostafa91@gmail.com', N'01003051936', N'PH0PdGiEBGUYsqwAKAD0bA==;XNPmXW5xAf3hMFaBXcIJCkg0HjnSbKjOj/wiKRxOkdg=', CAST(20007 AS Decimal(18, 0)))
INSERT [dbo].[users] ([userId], [userName], [fullName], [gender], [status], [createdby], [creationDate], [lastUpdateBy], [lastUpdateDate], [email], [mobile], [password], [roleId]) VALUES (CAST(40010 AS Decimal(18, 0)), N'hoba', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'abdelrhmanhoba@gmail.com', N'01025883501', N'lGLRroS+8afeEQXSOYwBHg==;5hTAyAu3zuWjASbFDp377HgaDXa8vdFY+DDFXLgTapw=', CAST(20007 AS Decimal(18, 0)))
INSERT [dbo].[users] ([userId], [userName], [fullName], [gender], [status], [createdby], [creationDate], [lastUpdateBy], [lastUpdateDate], [email], [mobile], [password], [roleId]) VALUES (CAST(40012 AS Decimal(18, 0)), N'nolia', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'noliam605@gmail.com', N'01285766571', N'h/tWtZ8shzVnwg5vHIR4ew==;R+XbZ6AMNXKv3TlY6Q6SwSMbtDS4Z7NQxGKvQ8lmz10=', CAST(20007 AS Decimal(18, 0)))
INSERT [dbo].[users] ([userId], [userName], [fullName], [gender], [status], [createdby], [creationDate], [lastUpdateBy], [lastUpdateDate], [email], [mobile], [password], [roleId]) VALUES (CAST(40013 AS Decimal(18, 0)), N'lola', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'lola12345abdo@gmail.com', N'01157553375', N'qvr280PF1m3IcAmcZBZBcQ==;Omkyr24DslxBH9XxF/KSNYYu4h+IwHM5m/0qOporc4Q=', CAST(20007 AS Decimal(18, 0)))
INSERT [dbo].[users] ([userId], [userName], [fullName], [gender], [status], [createdby], [creationDate], [lastUpdateBy], [lastUpdateDate], [email], [mobile], [password], [roleId]) VALUES (CAST(40014 AS Decimal(18, 0)), N'hany', NULL, NULL, NULL, NULL, CAST(N'2024-10-28' AS Date), NULL, NULL, N'iloveegypt3569@gmail.com', N'01090924534', N'BOYgvq4O0HH+AOJQQvmXmQ==;HVN2hIFGNPFW2DDcqU4MOrfO19Kxf5TYpCDEnVLjM/M=', NULL)
SET IDENTITY_INSERT [dbo].[users] OFF
GO
SET IDENTITY_INSERT [dbo].[whyChooseUs] ON 

INSERT [dbo].[whyChooseUs] ([id], [title], [languageId]) VALUES (1, N'Excellence in service guarantee.', 1)
INSERT [dbo].[whyChooseUs] ([id], [title], [languageId]) VALUES (2, N'Free cancellation', 1)
INSERT [dbo].[whyChooseUs] ([id], [title], [languageId]) VALUES (3, N'Experienced in what we do', 1)
INSERT [dbo].[whyChooseUs] ([id], [title], [languageId]) VALUES (1006, N'Low price guarantee', 1)
INSERT [dbo].[whyChooseUs] ([id], [title], [languageId]) VALUES (1007, N'Easy booking(2 min)', 1)
INSERT [dbo].[whyChooseUs] ([id], [title], [languageId]) VALUES (1008, N'Customer service round the clock', 1)
INSERT [dbo].[whyChooseUs] ([id], [title], [languageId]) VALUES (1009, N'Multilingual staff ', 1)
INSERT [dbo].[whyChooseUs] ([id], [title], [languageId]) VALUES (1010, N'Secure payment', 1)
SET IDENTITY_INSERT [dbo].[whyChooseUs] OFF
GO
/****** Object:  Index [UQ__booking__E3C5DE302CB14DE4]    Script Date: 2/11/2025 10:03:46 PM ******/
ALTER TABLE [dbo].[booking] ADD UNIQUE NONCLUSTERED 
(
	[requestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__booking__E3C5DE3087C19F3D]    Script Date: 2/11/2025 10:03:46 PM ******/
ALTER TABLE [dbo].[booking] ADD UNIQUE NONCLUSTERED 
(
	[requestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__hotelRoo__237A617FC80221A2]    Script Date: 2/11/2025 10:03:46 PM ******/
ALTER TABLE [dbo].[hotelRoomPricing] ADD UNIQUE NONCLUSTERED 
(
	[hotelRoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__localiza__9C22FCC3DDB13458]    Script Date: 2/11/2025 10:03:46 PM ******/
ALTER TABLE [dbo].[localizations] ADD UNIQUE NONCLUSTERED 
(
	[localizeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__roomType__5E5E0CF21977EB39]    Script Date: 2/11/2025 10:03:46 PM ******/
ALTER TABLE [dbo].[roomType] ADD UNIQUE NONCLUSTERED 
(
	[roomTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__roomType__5E5E0CF25B63E926]    Script Date: 2/11/2025 10:03:46 PM ******/
ALTER TABLE [dbo].[roomType] ADD UNIQUE NONCLUSTERED 
(
	[roomTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
