
INSERT INTO [dbo].[Users] (vchEmail, bitIsActive, intUserType, bintUserInfoId, intAccountPlan, dtRegistration, dtLastUpdate)
VALUES (N'test@gmail.com', 1, 1, 1, 1, GETDATE(), GETDATE())

SELECT *
FROM [dbo].[Users] (nolock)