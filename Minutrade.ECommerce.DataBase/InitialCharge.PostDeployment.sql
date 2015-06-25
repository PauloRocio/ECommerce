/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [ECommerce]
GO
SET IDENTITY_INSERT [dbo].[MaritalStatus] ON 

GO
INSERT [dbo].[MaritalStatus] ([id], [MaritalStatus]) VALUES (1, N'Solteiro')
GO
INSERT [dbo].[MaritalStatus] ([id], [MaritalStatus]) VALUES (2, N'Casado')
GO
INSERT [dbo].[MaritalStatus] ([id], [MaritalStatus]) VALUES (3, N'Viúvo')
GO
INSERT [dbo].[MaritalStatus] ([id], [MaritalStatus]) VALUES (4, N'Divorciado')
GO
SET IDENTITY_INSERT [dbo].[MaritalStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[States] ON 

GO
INSERT [dbo].[States] ([id], [StatesName]) VALUES (1, N'MG')
GO
INSERT [dbo].[States] ([id], [StatesName]) VALUES (2, N'SP')
GO
INSERT [dbo].[States] ([id], [StatesName]) VALUES (3, N'RJ')
GO
INSERT [dbo].[States] ([id], [StatesName]) VALUES (4, N'ES')
GO
SET IDENTITY_INSERT [dbo].[States] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

GO
INSERT [dbo].[Client] ([Id], [MaritalStatusId], [StateId], [Cpf], [Name], [Email], [Street], [Neighborhood], [Number], [CEP], [Complement], [ReferenceInformation]) VALUES (3, 1, 1, N'849.678.822-93', N'José da Silva Batista Júnior', N'jose@teste.com', N'Rua Céu Terra', N'Novo Horizonte', 666, N'31190000', N'2', N'Perto da quadra do bairro')
GO
INSERT [dbo].[Client] ([Id], [MaritalStatusId], [StateId], [Cpf], [Name], [Email], [Street], [Neighborhood], [Number], [CEP], [Complement], [ReferenceInformation]) VALUES (4, 1, 1, N'897.826.871-46', N'Maria Teste da Silva Melo', N'maria@teste.com', N'Rua Qualquer', N'Vitória', 777, N'45-352.180', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Phone] ON 

GO
INSERT [dbo].[Phone] ([id], [ClientId], [CodArea], [Number]) VALUES (1, 3, 31, N'9988-5070')
GO
SET IDENTITY_INSERT [dbo].[Phone] OFF
GO
