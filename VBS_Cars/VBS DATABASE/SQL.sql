USE [VBS]
GO
/****** Object:  StoredProcedure [dbo].[SaveVehicles]    Script Date: 9/28/2023 12:14:05 PM ******/
DROP PROCEDURE [dbo].[SaveVehicles]
GO
/****** Object:  StoredProcedure [dbo].[SaveFeedback]    Script Date: 9/28/2023 12:14:05 PM ******/
DROP PROCEDURE [dbo].[SaveFeedback]
GO
/****** Object:  StoredProcedure [dbo].[SaveCustomer]    Script Date: 9/28/2023 12:14:05 PM ******/
DROP PROCEDURE [dbo].[SaveCustomer]
GO
/****** Object:  StoredProcedure [dbo].[SaveBooking]    Script Date: 9/28/2023 12:14:05 PM ******/
DROP PROCEDURE [dbo].[SaveBooking]
GO
/****** Object:  StoredProcedure [dbo].[LoginProcess]    Script Date: 9/28/2023 12:14:05 PM ******/
DROP PROCEDURE [dbo].[LoginProcess]
GO
/****** Object:  StoredProcedure [dbo].[GetVehicleInfo]    Script Date: 9/28/2023 12:14:05 PM ******/
DROP PROCEDURE [dbo].[GetVehicleInfo]
GO
/****** Object:  StoredProcedure [dbo].[GetVehicleById]    Script Date: 9/28/2023 12:14:05 PM ******/
DROP PROCEDURE [dbo].[GetVehicleById]
GO
/****** Object:  StoredProcedure [dbo].[GetFeedbackById]    Script Date: 9/28/2023 12:14:05 PM ******/
DROP PROCEDURE [dbo].[GetFeedbackById]
GO
/****** Object:  StoredProcedure [dbo].[GetFeedback]    Script Date: 9/28/2023 12:14:05 PM ******/
DROP PROCEDURE [dbo].[GetFeedback]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerInfo]    Script Date: 9/28/2023 12:14:05 PM ******/
DROP PROCEDURE [dbo].[GetCustomerInfo]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerById]    Script Date: 9/28/2023 12:14:05 PM ******/
DROP PROCEDURE [dbo].[GetCustomerById]
GO
/****** Object:  StoredProcedure [dbo].[GetBookingInfo]    Script Date: 9/28/2023 12:14:05 PM ******/
DROP PROCEDURE [dbo].[GetBookingInfo]
GO
/****** Object:  StoredProcedure [dbo].[GetBookingById]    Script Date: 9/28/2023 12:14:05 PM ******/
DROP PROCEDURE [dbo].[GetBookingById]
GO
/****** Object:  StoredProcedure [dbo].[DeleteVehicle]    Script Date: 9/28/2023 12:14:05 PM ******/
DROP PROCEDURE [dbo].[DeleteVehicle]
GO
/****** Object:  StoredProcedure [dbo].[DeleteFeedback]    Script Date: 9/28/2023 12:14:05 PM ******/
DROP PROCEDURE [dbo].[DeleteFeedback]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCustomer]    Script Date: 9/28/2023 12:14:05 PM ******/
DROP PROCEDURE [dbo].[DeleteCustomer]
GO
/****** Object:  StoredProcedure [dbo].[DeleteBooking]    Script Date: 9/28/2023 12:14:05 PM ******/
DROP PROCEDURE [dbo].[DeleteBooking]
GO
ALTER TABLE [dbo].[tbl_Feedback] DROP CONSTRAINT [FK_tbl_Feedback_tbl_Booking]
GO
ALTER TABLE [dbo].[tbl_Booking] DROP CONSTRAINT [FK_tbl_Booking_tbl_Vehicles]
GO
ALTER TABLE [dbo].[tbl_Booking] DROP CONSTRAINT [FK_tbl_Booking_tbl_Customer]
GO
ALTER TABLE [dbo].[tbl_Vehicles] DROP CONSTRAINT [DF_tbl_Vehicles_IsDeleted]
GO
ALTER TABLE [dbo].[tbl_Role] DROP CONSTRAINT [DF_tbl_Role_IsDeleted]
GO
ALTER TABLE [dbo].[tbl_Feedback] DROP CONSTRAINT [DF_tbl_Feedback_IsDeleted]
GO
ALTER TABLE [dbo].[tbl_Customer] DROP CONSTRAINT [DF_tbl_User_IsDeleted]
GO
ALTER TABLE [dbo].[tbl_Customer] DROP CONSTRAINT [DF_tbl_Customer_RegDate]
GO
ALTER TABLE [dbo].[tbl_Booking] DROP CONSTRAINT [DF_tbl_Booking_IsDeleted]
GO
/****** Object:  Table [dbo].[tbl_Vehicles]    Script Date: 9/28/2023 12:14:05 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Vehicles]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Vehicles]
GO
/****** Object:  Table [dbo].[tbl_Role]    Script Date: 9/28/2023 12:14:05 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Role]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Role]
GO
/****** Object:  Table [dbo].[tbl_Feedback]    Script Date: 9/28/2023 12:14:05 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Feedback]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Feedback]
GO
/****** Object:  Table [dbo].[tbl_Customer]    Script Date: 9/28/2023 12:14:05 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Customer]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Customer]
GO
/****** Object:  Table [dbo].[tbl_Booking]    Script Date: 9/28/2023 12:14:05 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbl_Booking]') AND type in (N'U'))
DROP TABLE [dbo].[tbl_Booking]
GO
/****** Object:  Table [dbo].[tbl_Booking]    Script Date: 9/28/2023 12:14:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Booking](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[VehicleId] [int] NULL,
	[BookingDate] [datetime] NULL,
	[PickupDate] [datetime] NULL,
	[ReturnDate] [datetime] NULL,
	[CancelBooking] [varchar](50) NULL,
	[ReturnStatus] [varchar](50) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_tbl_Booking] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Customer]    Script Date: 9/28/2023 12:14:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](50) NULL,
	[Password] [varchar](255) NULL,
	[Email] [varchar](50) NULL,
	[Address] [varchar](max) NULL,
	[RegDate] [datetime] NULL,
	[ImagePath] [varchar](max) NULL,
	[RoleId] [int] NULL,
	[PhoneNo] [varchar](20) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Feedback]    Script Date: 9/28/2023 12:14:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Feedback](
	[FeedbackId] [int] IDENTITY(1,1) NOT NULL,
	[BookingId] [int] NULL,
	[Rating] [int] NULL,
	[Comment] [varchar](500) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_tbl_Feedback] PRIMARY KEY CLUSTERED 
(
	[FeedbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Role]    Script Date: 9/28/2023 12:14:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_tbl_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Vehicles]    Script Date: 9/28/2023 12:14:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Vehicles](
	[VehicleId] [int] IDENTITY(1,1) NOT NULL,
	[Make] [varchar](200) NULL,
	[Model] [varchar](200) NULL,
	[Year] [int] NULL,
	[Price] [decimal](18, 2) NULL,
	[Mileage] [decimal](18, 2) NULL,
	[LicensePlate] [varchar](15) NULL,
	[Colour] [varchar](50) NULL,
	[VIN] [varchar](17) NULL,
	[EngineType] [varchar](50) NULL,
	[EngineSize] [decimal](18, 2) NULL,
	[FuelType] [varchar](50) NULL,
	[FuelTank] [decimal](18, 2) NULL,
	[SeatingCapacity] [int] NULL,
	[Condition] [varchar](50) NULL,
	[Features] [varchar](50) NULL,
	[VersionName] [varchar](255) NULL,
	[ExShowroomPrice] [decimal](18, 2) NULL,
	[RTO] [decimal](18, 2) NULL,
	[Insurance] [decimal](18, 2) NULL,
	[ImageURLs] [varchar](max) NULL,
	[VideoURLs] [varchar](max) NULL,
	[Availability] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK__tbl_Vehi__476B5492F6EAE0E2] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Booking] ON 

INSERT [dbo].[tbl_Booking] ([BookingId], [CustomerId], [VehicleId], [BookingDate], [PickupDate], [ReturnDate], [CancelBooking], [ReturnStatus], [IsDeleted]) VALUES (1, 1, 1, CAST(N'2023-09-22T00:00:00.000' AS DateTime), CAST(N'2023-10-01T00:00:00.000' AS DateTime), CAST(N'2023-10-22T00:00:00.000' AS DateTime), N'Cancel', N'Good', 0)
INSERT [dbo].[tbl_Booking] ([BookingId], [CustomerId], [VehicleId], [BookingDate], [PickupDate], [ReturnDate], [CancelBooking], [ReturnStatus], [IsDeleted]) VALUES (4, 1, 1, CAST(N'2023-09-25T00:00:00.000' AS DateTime), CAST(N'2023-09-25T00:00:00.000' AS DateTime), CAST(N'2023-09-25T00:00:00.000' AS DateTime), N'fgkjsg', N'dkkgsd', 0)
INSERT [dbo].[tbl_Booking] ([BookingId], [CustomerId], [VehicleId], [BookingDate], [PickupDate], [ReturnDate], [CancelBooking], [ReturnStatus], [IsDeleted]) VALUES (1008, 1, 1, CAST(N'2023-09-26T00:00:00.000' AS DateTime), CAST(N'2023-09-26T00:00:00.000' AS DateTime), CAST(N'2023-09-26T00:00:00.000' AS DateTime), N'CANCLE', N'string', 0)
SET IDENTITY_INSERT [dbo].[tbl_Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Customer] ON 

INSERT [dbo].[tbl_Customer] ([CustomerId], [CustomerName], [Password], [Email], [Address], [RegDate], [ImagePath], [RoleId], [PhoneNo], [IsDeleted]) VALUES (1, N'shuruthi', N'F2ov5N5tH8NJILB4SsfgDmVL8BSxvPMxXTXIrOPTtCJnOx8rkGnhDQ==', N'shuruthi@gmail.com', N'salem', CAST(N'2023-09-21T10:25:29.447' AS DateTime), NULL, NULL, N'1234567890', 0)
INSERT [dbo].[tbl_Customer] ([CustomerId], [CustomerName], [Password], [Email], [Address], [RegDate], [ImagePath], [RoleId], [PhoneNo], [IsDeleted]) VALUES (2, N'test', N'F2ov5N5tH8NJILB4SsfgDmVL8BSxvPMxXTXIrOPTtCJnOx8rkGnhDQ==', N'test', N'test', CAST(N'2023-09-22T11:28:19.107' AS DateTime), NULL, 1, N'3455667788', 1)
INSERT [dbo].[tbl_Customer] ([CustomerId], [CustomerName], [Password], [Email], [Address], [RegDate], [ImagePath], [RoleId], [PhoneNo], [IsDeleted]) VALUES (3, N'string', N'QDp+4NWJFHeLv+XggZX1', N'string', N'string', CAST(N'2023-09-22T15:11:40.633' AS DateTime), N'string', 0, N'string', 1)
INSERT [dbo].[tbl_Customer] ([CustomerId], [CustomerName], [Password], [Email], [Address], [RegDate], [ImagePath], [RoleId], [PhoneNo], [IsDeleted]) VALUES (4, N'string', N'XN33SXuNr7Wuim44SKQH', N'string', N'string', CAST(N'2023-09-22T15:12:32.723' AS DateTime), N'string', 0, N'string', 1)
INSERT [dbo].[tbl_Customer] ([CustomerId], [CustomerName], [Password], [Email], [Address], [RegDate], [ImagePath], [RoleId], [PhoneNo], [IsDeleted]) VALUES (5, N'string', N'B4IcVWHiV7rknI2YpSGi', N'string', N'string', CAST(N'2023-09-23T17:44:45.917' AS DateTime), N'string', 0, N'string', 0)
INSERT [dbo].[tbl_Customer] ([CustomerId], [CustomerName], [Password], [Email], [Address], [RegDate], [ImagePath], [RoleId], [PhoneNo], [IsDeleted]) VALUES (6, N'Ramya', N'v6IIwBsvyuTsoeOwXTjh', N'dkjfsf', N'dfsf', CAST(N'2023-09-25T09:54:48.063' AS DateTime), N'fsdfsf', 1, N'sfsf', 0)
INSERT [dbo].[tbl_Customer] ([CustomerId], [CustomerName], [Password], [Email], [Address], [RegDate], [ImagePath], [RoleId], [PhoneNo], [IsDeleted]) VALUES (7, N'string', N'qBzbpeH97LbR5rtansEj', N'string', N'string', CAST(N'2023-09-25T11:36:30.357' AS DateTime), N'string', 0, N'string', 1)
INSERT [dbo].[tbl_Customer] ([CustomerId], [CustomerName], [Password], [Email], [Address], [RegDate], [ImagePath], [RoleId], [PhoneNo], [IsDeleted]) VALUES (8, N'annu', N'/HjgFBE3uH05z0uz+GhV', N'dfsdg', N'dfds', CAST(N'2023-09-26T11:08:08.773' AS DateTime), N'djfldf', 2, N'dfd', 0)
INSERT [dbo].[tbl_Customer] ([CustomerId], [CustomerName], [Password], [Email], [Address], [RegDate], [ImagePath], [RoleId], [PhoneNo], [IsDeleted]) VALUES (9, N'kamsala', N'rYIjlVXagGCcuzuWKlslNLy0pj9laDRLwGx1tm4b9Vh5WTsYkqFFnQ==', N'Kamsala@gmail.com', N'dhfdkf', CAST(N'2023-09-26T15:31:00.127' AS DateTime), N'string', 2, N'23456', 0)
SET IDENTITY_INSERT [dbo].[tbl_Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Feedback] ON 

INSERT [dbo].[tbl_Feedback] ([FeedbackId], [BookingId], [Rating], [Comment], [IsDeleted]) VALUES (2, 1, 5, N'good', 0)
INSERT [dbo].[tbl_Feedback] ([FeedbackId], [BookingId], [Rating], [Comment], [IsDeleted]) VALUES (1002, 1, 1, N'string', 0)
SET IDENTITY_INSERT [dbo].[tbl_Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Role] ON 

INSERT [dbo].[tbl_Role] ([RoleId], [RoleName], [IsDeleted]) VALUES (1, N'Admin', 0)
INSERT [dbo].[tbl_Role] ([RoleId], [RoleName], [IsDeleted]) VALUES (2, N'User', 0)
SET IDENTITY_INSERT [dbo].[tbl_Role] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Vehicles] ON 

INSERT [dbo].[tbl_Vehicles] ([VehicleId], [Make], [Model], [Year], [Price], [Mileage], [LicensePlate], [Colour], [VIN], [EngineType], [EngineSize], [FuelType], [FuelTank], [SeatingCapacity], [Condition], [Features], [VersionName], [ExShowroomPrice], [RTO], [Insurance], [ImageURLs], [VideoURLs], [Availability], [IsDeleted]) VALUES (1, N'Toyota', N'Camry', 2022, CAST(35000.00 AS Decimal(18, 2)), CAST(25.50 AS Decimal(18, 2)), N'ABC123', N'Silver', N'12345678901234567', N'V6', CAST(3.50 AS Decimal(18, 2)), N'Petrol', CAST(18.50 AS Decimal(18, 2)), 5, N'New', N'Navigation', N'XLE', CAST(32000.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), N'url1,url2,url3', N'url1,url2,url3', 1, 0)
INSERT [dbo].[tbl_Vehicles] ([VehicleId], [Make], [Model], [Year], [Price], [Mileage], [LicensePlate], [Colour], [VIN], [EngineType], [EngineSize], [FuelType], [FuelTank], [SeatingCapacity], [Condition], [Features], [VersionName], [ExShowroomPrice], [RTO], [Insurance], [ImageURLs], [VideoURLs], [Availability], [IsDeleted]) VALUES (2, N'ss', N'ss', 1992, CAST(10000.00 AS Decimal(18, 2)), CAST(25.00 AS Decimal(18, 2)), N'test', N'test', N'test', N'test', CAST(45.00 AS Decimal(18, 2)), N'test', CAST(12.00 AS Decimal(18, 2)), 45, N'ddd', N'gggg', N'wwww', CAST(2220.00 AS Decimal(18, 2)), CAST(110.00 AS Decimal(18, 2)), CAST(1110.00 AS Decimal(18, 2)), N'asas', N'asa', 1, 0)
SET IDENTITY_INSERT [dbo].[tbl_Vehicles] OFF
GO
ALTER TABLE [dbo].[tbl_Booking] ADD  CONSTRAINT [DF_tbl_Booking_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tbl_Customer] ADD  CONSTRAINT [DF_tbl_Customer_RegDate]  DEFAULT (getdate()) FOR [RegDate]
GO
ALTER TABLE [dbo].[tbl_Customer] ADD  CONSTRAINT [DF_tbl_User_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tbl_Feedback] ADD  CONSTRAINT [DF_tbl_Feedback_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tbl_Role] ADD  CONSTRAINT [DF_tbl_Role_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tbl_Vehicles] ADD  CONSTRAINT [DF_tbl_Vehicles_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tbl_Booking]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Booking_tbl_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[tbl_Customer] ([CustomerId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Booking] CHECK CONSTRAINT [FK_tbl_Booking_tbl_Customer]
GO
ALTER TABLE [dbo].[tbl_Booking]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Booking_tbl_Vehicles] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[tbl_Vehicles] ([VehicleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Booking] CHECK CONSTRAINT [FK_tbl_Booking_tbl_Vehicles]
GO
ALTER TABLE [dbo].[tbl_Feedback]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Feedback_tbl_Booking] FOREIGN KEY([BookingId])
REFERENCES [dbo].[tbl_Booking] ([BookingId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_Feedback] CHECK CONSTRAINT [FK_tbl_Feedback_tbl_Booking]
GO
/****** Object:  StoredProcedure [dbo].[DeleteBooking]    Script Date: 9/28/2023 12:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteBooking]
@BookingId int
as begin
update [dbo].[tbl_Booking] set IsDeleted = 1
where BookingId = @BookingId
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteCustomer]    Script Date: 9/28/2023 12:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Shuruthi>
-- Create date: <09/21/2023>
-- Description:	<Delete the customer Information>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCustomer]
@CustomerId int
as
begin
update [dbo].[tbl_Customer] set IsDeleted = 1
where CustomerId = @CustomerId
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteFeedback]    Script Date: 9/28/2023 12:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,shuruthi>
-- Create date: <9/25/2023>
-- Description:	<Delete the feedback details>
-- =============================================
CREATE PROC [dbo].[DeleteFeedback]
@FeedbackId int
as begin 
update [dbo].[tbl_Feedback] set IsDeleted = 1
where FeedbackId=@FeedbackId
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteVehicle]    Script Date: 9/28/2023 12:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Shuruthi>
-- Create date: <9/2/2023,>
-- Description:	<Delete the Vehicle Details,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteVehicle]
@VehicleId int
as
begin 
update [dbo].[tbl_Vehicles] set IsDeleted = 1
WHERE VehicleId = @VehicleId
END

GO
/****** Object:  StoredProcedure [dbo].[GetBookingById]    Script Date: 9/28/2023 12:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBookingById]
    @BookingId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        B.BookingId,
        C.CustomerName,
        V.Make, 
        V.Model,
        V.Year,
        V.Price,
        B.BookingDate,
        B.PickupDate,
        B.ReturnDate,
        B.CancelBooking,
        B.ReturnStatus
      
    FROM [dbo].[tbl_Booking] B
    JOIN [dbo].[tbl_Customer] C ON B.CustomerId = C.CustomerId
    JOIN [dbo].[tbl_Vehicles] V ON B.VehicleId = V.VehicleId
    WHERE B.BookingId = @BookingId AND B.IsDeleted = 0;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetBookingInfo]    Script Date: 9/28/2023 12:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBookingInfo]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        B.BookingId,
        C.CustomerName,
        V.Make, 
        V.Model,
        V.Year,
        V.Price,
        B.BookingDate,
        B.PickupDate,
        B.CancelBooking,
        B.ReturnStatus
    FROM [dbo].[tbl_Booking] B
    JOIN [dbo].[tbl_Customer] C ON B.CustomerId = C.CustomerId
    JOIN [dbo].[tbl_Vehicles] V ON B.VehicleId = V.VehicleId
    WHERE B.IsDeleted = 0;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerById]    Script Date: 9/28/2023 12:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,shuruthi>
-- Create date: <9/22/23>
-- Description:	<Get the VehicleById Information,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCustomerById]
   @CustomerId INT
AS
BEGIN
 select 
     c. CustomerId,
     c. CustomerName,
     c. Email,
     c. Address,
     c. RegDate,
     c. ImagePath,
     R. RoleName,
      c.PhoneNo from [dbo].[tbl_Customer] c
	  join tbl_Role R on c.RoleId = R.RoleId
	  WHERE c. CustomerId = @CustomerId and c.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerInfo]    Script Date: 9/28/2023 12:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,shuruthi>
-- Create date: <09/20/2023,,>
-- Description:	<Get the Customer Infromation ,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCustomerInfo]
as
begin 
  select 
     c. CustomerId,
     c. CustomerName,
     c. Email,
     c. Address,
     c. RegDate,
     c. ImagePath,
     R. RoleName,
      c.PhoneNo from [dbo].[tbl_Customer] c
	  join tbl_Role R on c.RoleId = R.RoleId
   where c. IsDeleted = 0 
end
GO
/****** Object:  StoredProcedure [dbo].[GetFeedback]    Script Date: 9/28/2023 12:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetFeedback] AS
BEGIN
    SELECT f.FeedbackId,
           f.Rating,
           f.Comment,
           b.BookingId,
           c.CustomerId,
           c.CustomerName,
           v.VehicleId,
           v.Make,
           v.Model
    FROM [dbo].[tbl_Feedback] f
    INNER JOIN[dbo].[tbl_Booking]  b ON f.BookingId = b.BookingId
    INNER JOIN [dbo].[tbl_Customer] c ON b.CustomerId = c.CustomerId
    INNER JOIN  [dbo].[tbl_Vehicles] v ON b.VehicleId = v.VehicleId
    WHERE f.IsDeleted = 0;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetFeedbackById]    Script Date: 9/28/2023 12:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetFeedbackById]
@FeedbackId INT AS
BEGIN
    SELECT f.[FeedbackId],
           f.[Rating],
           f.[Comment],
           b.[BookingId],
           c.[CustomerId],
           c.[CustomerName],
           v.[VehicleId],
           v.[Make],
           v.[Model]
    FROM [dbo].[tbl_Feedback] f
    INNER JOIN [dbo].[tbl_Booking] b ON f.[BookingId] = b.[BookingId]
    INNER JOIN[dbo].[tbl_Customer]  c ON b.[CustomerId] = c.[CustomerId]
    INNER JOIN   [dbo].[tbl_Vehicles] v ON b.[VehicleId] = v.[VehicleId]
    WHERE f.[FeedbackId] = @FeedbackId
          AND f.[IsDeleted] = 0
END;
GO
/****** Object:  StoredProcedure [dbo].[GetVehicleById]    Script Date: 9/28/2023 12:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,shuruthi>
-- Create date: <9/22.23>
-- Description:	<Get the vehicle ById Information,>
-- =============================================
CREATE PROCEDURE [dbo].[GetVehicleById]
@VehicleId int 
as 
begin
    select 
        VehicleId,
        Make,
        Model,
        Year,
        Price,
        Mileage,
        LicensePlate,
        Colour,
        VIN,
        EngineType,
        EngineSize,
        FuelType,
        FuelTank,
        SeatingCapacity,
        Condition,
        Features,
        VersionName,
        ExShowroomPrice,
        RTO,
        Insurance,
        ImageURLs,
        VideoURLs
    from [dbo].[tbl_Vehicles] where @VehicleId  = VehicleId
end
GO
/****** Object:  StoredProcedure [dbo].[GetVehicleInfo]    Script Date: 9/28/2023 12:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,shuruthi>
-- Create date: <9/22/2023,>
-- Description:	<Get Vehicle Information,>
-- =============================================
CREATE PROCEDURE [dbo].[GetVehicleInfo]
as
begin 
select 
VehicleId,
Make,
Model,
Year,
Price,
Mileage,
LicensePlate,
Colour,
VIN,
EngineType,
EngineSize,
FuelType,
FuelTank,
SeatingCapacity,
Condition,
Features,
VersionName,
ExShowroomPrice,
RTO,
Insurance,
ImageURLs,
VideoURLs,
Availability from [dbo].[tbl_Vehicles]
where IsDeleted=0
end
GO
/****** Object:  StoredProcedure [dbo].[LoginProcess]    Script Date: 9/28/2023 12:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LoginProcess] --'shuruthi','12345'
      @CustomerName varchar(50)
     
AS
BEGIN
	BEGIN TRY
		DECLARE @Success int=200,
          @Fail int=500
		  
		IF EXISTS(SELECT CustomerID,CustomerName,Password
	      FROM [dbo].[tbl_Customer] )
		BEGIN
		   SELECT @Success as Success
		   SELECT  * FROM [dbo].[tbl_Customer]  WHERE CustomerName=@CustomerName
		END
		ELSE
		  BEGIN
			 SELECT @Fail as Failed
		  END
	END TRY
	BEGIN CATCH
	END CATCH

	END
GO
/****** Object:  StoredProcedure [dbo].[SaveBooking]    Script Date: 9/28/2023 12:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaveBooking]
    @BookingId int,
    @CustomerId INT,
    @VehicleId INT,
    @BookingDate DATE,
    @PickupDate DATE,
    @ReturnDate DATE,
    @CancelBooking varchar(50),
    @ReturnStatus varchar(50)
AS
BEGIN
declare @statuscode int
 if not exists (SELECT BookingId  FROM [dbo].[tbl_Booking] WHERE BookingId = @BookingId)
	begin
  INSERT INTO [dbo].[tbl_Booking] (CustomerId, VehicleId, BookingDate, PickupDate, ReturnDate, CancelBooking, ReturnStatus)
    VALUES (@CustomerId, @VehicleId, @BookingDate, @PickupDate, @ReturnDate, @CancelBooking, @ReturnStatus);
	set @statuscode=200
   select @statuscode
   end
	else 
	begin
	update [dbo].[tbl_Booking]
	set CustomerId=@CustomerId,
	VehicleId=@VehicleId,
	BookingDate=@BookingDate,
	PickupDate=@PickupDate,
	ReturnDate=@ReturnDate,
	CancelBooking=@CancelBooking,
	ReturnStatus=@ReturnStatus
	where BookingId = @BookingId
	end
END
GO
/****** Object:  StoredProcedure [dbo].[SaveCustomer]    Script Date: 9/28/2023 12:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author shuruthi>
-- Create date: <09/20/2023>
-- Description:	<Save or Update the customer Details>
-- exec [dbo].[SaveCustomer] 2,kani,12345,flfsdf,jsndfkds,1,123456789,0
-- =============================================
CREATE PROCEDURE [dbo].[SaveCustomer]

    @CustomerId INT,
    @CustomerName VARCHAR(50),
    @Password VARCHAR(225),
    @Email VARCHAR(200),
    @Address VARCHAR(max),
    @ImagePath VARCHAR(max),
    @RoleId INT,
    @PhoneNo VARCHAR(20)
AS
BEGIN
declare @statuscode int
    IF @CustomerId =0
    BEGIN
        INSERT INTO [dbo].[tbl_Customer](CustomerName, Password, Email, Address,RegDate, ImagePath, RoleId, PhoneNo)
        VALUES (@CustomerName, @Password, @Email, @Address, GETDATE(), @ImagePath, @RoleId, @PhoneNo);
   set @statuscode=200
   select @statuscode
   END
    ELSE
    BEGIN
        UPDATE[dbo].[tbl_Customer]
        SET CustomerName = @CustomerName,
            Password = @Password,
            Email = @Email,
            Address = @Address,
			RegDate=GETDATE(),
            ImagePath = @ImagePath,
            RoleId = @RoleId,
            PhoneNo = @PhoneNo
        WHERE CustomerId = @CustomerId
    END
END
GO
/****** Object:  StoredProcedure [dbo].[SaveFeedback]    Script Date: 9/28/2023 12:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Shuruthi>
-- Create date: <9/25/2023>
-- Description:	<Save the feedback for customer >
-- =============================================
CREATE PROCEDURE [dbo].[SaveFeedback]
    @FeedbackId INT,
    @BookingId INT,
    @Rating INT,
    @Comment NVARCHAR(MAX)
AS
BEGIN
    DECLARE @statuscode INT

    IF NOT EXISTS (SELECT FeedbackId FROM [dbo].[tbl_Feedback] WHERE FeedbackId = @FeedbackId)
    BEGIN
        INSERT INTO [dbo].[tbl_Feedback] ( [BookingId], [Rating], [Comment])
        VALUES ( @BookingId, @Rating, @Comment)

        SET @statuscode = 200
        SELECT @statuscode
    END
    ELSE
    BEGIN
        UPDATE [dbo].[tbl_Feedback]
        SET BookingId = @BookingId,
            Rating = @Rating,
            Comment = @Comment
        WHERE FeedbackId = @FeedbackId
    END
END

GO
/****** Object:  StoredProcedure [dbo].[SaveVehicles]    Script Date: 9/28/2023 12:14:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,shuruthi>
-- Create date: <	9/26/2023,>
-- Description:	<Save the Vehicles Details,>
-- =============================================
CREATE PROC [dbo].[SaveVehicles]
    @VehicleId INT,
    @Make VARCHAR(200),
    @Model VARCHAR(200),
    @Year INT,
    @Price DECIMAL(18,2),
    @Mileage DECIMAL(18,2),
    @LicensePlate VARCHAR(15),
    @Colour VARCHAR(50),
    @VIN VARCHAR(17),
    @EngineType VARCHAR(50),
    @EngineSize DECIMAL(18,2),
    @FuelType VARCHAR(50),
    @FuelTank DECIMAL(18,2),
    @SeatingCapacity INT,
    @Condition VARCHAR(50),
    @Features VARCHAR(50),
    @VersionName VARCHAR(255),
    @ExShowroomPrice DECIMAL(18,2),
    @RTO DECIMAL(18,2),
    @Insurance DECIMAL(18,2),
    @ImageURLs VARCHAR(MAX),
    @VideoURLs VARCHAR(MAX),
    @Availability BIT
AS
BEGIN
    DECLARE @statuscode INT

    IF NOT EXISTS (SELECT VehicleId FROM [dbo].[tbl_Vehicles] WHERE VehicleId = @VehicleId)
    BEGIN
        INSERT INTO [dbo].[tbl_Vehicles] (
            Make, Model, Year, Price, Mileage, LicensePlate,
			Colour, VIN, EngineType, EngineSize, FuelType, FuelTank, 
            SeatingCapacity, Condition, Features, VersionName,
			ExShowroomPrice, RTO, Insurance, ImageURLs, VideoURLs, Availability
        )
        VALUES (
            @Make, @Model, @Year, @Price, @Mileage, @LicensePlate, @Colour,
			@VIN, @EngineType, @EngineSize, @FuelType, 
            @FuelTank, @SeatingCapacity, @Condition, @Features, 
			@VersionName, @ExShowroomPrice, @RTO, @Insurance, @ImageURLs, 
            @VideoURLs, @Availability
           )

        SET @statuscode = 200
        SELECT @statuscode
    END
    ELSE
    BEGIN
        UPDATE [dbo].[tbl_Vehicles]
        SET
            Make = @Make,
            Model = @Model,
            Year = @Year,
            Price = @Price,
            Mileage = @Mileage,
            LicensePlate = @LicensePlate,
            Colour = @Colour,
            VIN = @VIN,
            EngineType = @EngineType,
            EngineSize = @EngineSize,
            FuelType = @FuelType,
            FuelTank = @FuelTank,
            SeatingCapacity = @SeatingCapacity,
            Condition = @Condition,
            Features = @Features,
            VersionName = @VersionName,
            ExShowroomPrice = @ExShowroomPrice,
            RTO = @RTO,
            Insurance = @Insurance,
            ImageURLs = @ImageURLs,
            VideoURLs = @VideoURLs,
            Availability = @Availability
        WHERE VehicleId = @VehicleId
    END
END
GO
