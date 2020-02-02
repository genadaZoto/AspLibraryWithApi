/****** Script de la commande SelectTopNRows à partir de SSMS  ******/
SELECT TOP (1000) [IdBook]
      ,[Author]
      ,[Category]
      ,[Description]
      ,[Image]
      ,[ReleaseYear]
      ,[Title]
  FROM [Library].[dbo].[Book]