USE [SiteNoticias]
GO

/****** Object:  Table [dbo].[TbNoticia]    Script Date: 08/04/2017 09:51:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TbNoticia](
	[not_id] [int] IDENTITY(1,1) NOT NULL,
	[not_titulo] [nchar](150) NULL,
	[not_texto] [text] NULL,
	[not_data] [datetime] NULL,
	[not_imagem] [varchar](50) NULL,
	[cat_id] [int] NULL,
 CONSTRAINT [PK_TbNoticia] PRIMARY KEY CLUSTERED 
(
	[not_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TbNoticia]  WITH CHECK ADD  CONSTRAINT [FK_TbNoticia_TbCategoria] FOREIGN KEY([cat_id])
REFERENCES [dbo].[TbCategoria] ([cat_id])
GO

ALTER TABLE [dbo].[TbNoticia] CHECK CONSTRAINT [FK_TbNoticia_TbCategoria]
GO

