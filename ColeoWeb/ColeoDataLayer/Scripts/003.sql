USE [Coleo]
GO

ALTER TABLE ProjectStatus
ADD DisplayOrder int NOT NULL CONSTRAINT [DF_ProjectStatus_DisplayOrder]  DEFAULT ((0))
GO


