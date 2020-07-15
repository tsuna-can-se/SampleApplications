CREATE TABLE [dbo].[Books] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (512) NULL,
    [Price]      DECIMAL (18)   NULL,
    [Author]     NVARCHAR (256) NULL,
    [Publisher]  NVARCHAR (256) NULL,
    [RowVersion] ROWVERSION     NOT NULL
);
GO

INSERT INTO [dbo].[Books] ([Name], [Price], [Author], [Publisher]) VALUES (N'マネージドIDの本', CAST(3000 AS Decimal(18, 0)), N'著者A', N'出版社A')
INSERT INTO [dbo].[Books] ([Name], [Price], [Author], [Publisher]) VALUES (N'ASP.NETの本', CAST(2500 AS Decimal(18, 0)), N'著者B', N'出版社B')
GO