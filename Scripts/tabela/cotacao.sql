USE [gecom_des_db]
GO

/****** Object:  Table [dbo].[cotacao_tb]    Script Date: 22/02/2020 11:57:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[cotacao_tb](
	[cotacao_id] [int] IDENTITY(1,1) NOT NULL,
	[segurado_id] [int] NOT NULL,
	[ramo_id] [int] NOT NULL,
	[codigo] [varchar](50) NOT NULL,
	[premio] [decimal](18, 0) NOT NULL,
	[data_inicio_vigencia] [datetime] NOT NULL,
	[data_fim_vigencia] [datetime] NOT NULL,
	[data_cotacao] [datetime] NOT NULL,
	[corretor_id] [int] NOT NULL,
	[seguradora_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cotacao_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[cotacao_tb]  WITH NOCHECK ADD FOREIGN KEY([corretor_id])
REFERENCES [dbo].[corretor_tb] ([corretor_id])
GO

ALTER TABLE [dbo].[cotacao_tb]  WITH NOCHECK ADD FOREIGN KEY([ramo_id])
REFERENCES [dbo].[ramo_tb] ([ramo_id])
GO

ALTER TABLE [dbo].[cotacao_tb]  WITH NOCHECK ADD FOREIGN KEY([segurado_id])
REFERENCES [dbo].[segurado_tb] ([segurado_id])
GO

ALTER TABLE [dbo].[cotacao_tb]  WITH NOCHECK ADD FOREIGN KEY([seguradora_id])
REFERENCES [dbo].[seguradora_tb] ([seguradora_id])
GO


