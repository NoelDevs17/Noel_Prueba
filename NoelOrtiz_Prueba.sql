Create Database NoelOrtizPrueba

USE [NoelOrtizPrueba]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persona](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[FechaDeNacimiento] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[persona] ON 

INSERT [dbo].[persona] ([ID], [Nombre], [FechaDeNacimiento]) VALUES (1, N'Noel Ortiz', CAST(N'1999-02-17' AS Date))
INSERT [dbo].[persona] ([ID], [Nombre], [FechaDeNacimiento]) VALUES (2, N'Carlos Manuel', CAST(N'2015-02-26' AS Date))
SET IDENTITY_INSERT [dbo].[persona] OFF
GO
