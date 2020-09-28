USE [gecom_des_db]
GO

/****** Object:  Table [dbo].[cotacao_tb]    Script Date: 22/02/2020 11:57:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[proposta_parcela_tb](
    [proposta_parcela_id] [int] IDENTITY(1,1) NOT NULL,
	[proposta_id] [int] NOT NULL,
	[numero_parcela] [int] NOT NULL,
	[data_vencimento] [datetime] NOT NULL,
	[premio_liquido] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[proposta_parcela_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[proposta_parcela_tb]  WITH NOCHECK ADD FOREIGN KEY([proposta_id])
REFERENCES [dbo].[proposta_tb] ([proposta_id])
GO


