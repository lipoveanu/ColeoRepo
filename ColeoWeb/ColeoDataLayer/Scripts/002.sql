USE Coleo
GO

ALTER TABLE ProjectStatus
ADD IsDefault bit NOT NULL CONSTRAINT [DF_ProjectStatus_IsDefault]  DEFAULT ((0))
GO