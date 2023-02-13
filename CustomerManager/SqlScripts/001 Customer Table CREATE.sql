
/****** Object:  Table [dbo].[Customers]    Script Date: 13/02/2023 01:09:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [nvarchar](450) NULL,
	[LastUpdateDate] [datetime] NULL,
	[LastUpdateUser] [nvarchar](450) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO


