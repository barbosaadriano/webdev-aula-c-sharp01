USE [SiteNoticias]
GO

/****** Object:  Table [dbo].[TbUsuario]    Script Date: 08/04/2017 09:51:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TbUsuario](
	[usu_id] [int] IDENTITY(1,1) NOT NULL,
	[usu_nome] [varchar](50) NULL,
	[usu_login] [varchar](50) NULL,
	[usu_senha] [varchar](50) NULL,
	[usu_ativo] [bit] NULL,
 CONSTRAINT [PK_TbUsuario] PRIMARY KEY CLUSTERED 
(
	[usu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

