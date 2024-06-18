BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240618014601_MigracaoTaskModel', N'8.0.6');
GO

COMMIT;
GO

