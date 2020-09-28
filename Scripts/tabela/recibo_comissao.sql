USE [gecom_des_db]
GO

/****** Object:  Table [dbo].[cotacao_tb]    Script Date: 22/02/2020 11:57:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[recibo_comissao_tb](
    [recibo_comissao_id] [int] IDENTITY(1,1) NOT NULL,
	[proposta_id] [int] NOT NULL,
	[valor_bruto] [decimal](18, 2) NOT NULL,
	[valor_liquido] [decimal](18, 2) NOT NULL,
	[percentual_comissao] [decimal](18, 2) NOT NULL,
	[percentual_imposto] [decimal](18, 2) NOT NULL,
	
PRIMARY KEY CLUSTERED 
(
	[recibo_comissao_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[recibo_comissao_tb]  WITH NOCHECK ADD FOREIGN KEY([proposta_id])
REFERENCES [dbo].[proposta_tb] ([proposta_id])
GO


