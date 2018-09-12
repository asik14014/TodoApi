UPDATE [dbo].[UserTypes]
SET [vchDescription] = N'Пользовательские права'
WHERE intId = 1

UPDATE [dbo].[UserTypes]
SET [vchDescription] = N'Полный доступ'
WHERE intId = 2

SELECT *
FROM [dbo].[UserTypes] (nolock)