
INSERT INTO [dbo].[Users] (bintId, vchEmail, bitIsActive, intUserType, bintUserInfoId, intAccountPlan, dtRegistration, dtLastUpdate)
VALUES (1, N'test@gmail.com', 1, 1, 1, 1, GETDATE(), GETDATE())

SELECT *
FROM [dbo].[Users] (nolock)