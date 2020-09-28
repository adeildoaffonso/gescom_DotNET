USE [gecom_des_db]
GO

/****** Object:  Table [dbo].[cotacao_tb]    Script Date: 22/02/2020 11:57:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[recibo_comissao_detalhe_tb](
    [recibo_comissao_detalhe_id] [int] IDENTITY(1,1) NOT NULL,
	[recibo_comissao_id] [int] NOT NULL,
	[corretor_id] [int] NOT NULL,
	[data_pagamento] [datetime] NOT NULL,
	[valor_pagamento] [decimal](18, 2) NOT NULL,
	[percentual_comissao] [decimal](18, 2) NOT NULL,
	
PRIMARY KEY CLUSTERED 
(
	[recibo_comissao_detalhe_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[recibo_comissao_detalhe_tb]  WITH NOCHECK ADD FOREIGN KEY([recibo_comissao_id])
REFERENCES [dbo].[recibo_comissao_tb] ([recibo_comissao_id])
GO

ALTER TABLE [dbo].[recibo_comissao_detalhe_tb]  WITH NOCHECK ADD FOREIGN KEY([corretor_id])
REFERENCES [dbo].[corretor_tb] ([corretor_id])
GO

