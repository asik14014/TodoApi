INSERT INTO [dbo].[UsersInfo] (vchPhotoUrl, vchName, vchTelNumber, vchRawJson)
VALUES (N'http://test/test.png', N'Test', N'87777777777', N'')

SELECT *
FROM [dbo].[UsersInfo] (nolock)