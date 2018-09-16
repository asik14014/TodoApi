INSERT INTO dbo.TaskStatuses (vchName, vchDescription)
VALUES (N'Создан', N'Начальный статус задачи'),
(N'В работе', N'Выполняется в текущий момент'),
(N'Приостановлен', N'Отложен'),
(N'Выполнен', N'Ок'),
(N'Отменен', N'Отменен')

SELECT *
FROM dbo.TaskStatuses