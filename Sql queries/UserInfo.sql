INSERT INTO [dbo].[UsersInfo] (bintId, vchPhotoUrl, vchName, vchTelNumber, vchRawJson)
VALUES (1, N'http://test/test.png', N'Test', N'87777777777', N'')

SELECT *
FROM [dbo].[UsersInfo] (nolock)