INSERT INTO [dbo].[UserTypes] (vchName, vchDescription)
VALUES (N'Пользователь', N'Пользовательские права'),
(N'Администратор', N'Полный доступ')

SELECT *
FROM [dbo].[UserTypes] (nolock)