INSERT INTO [dbo].[AccountPlans] (intId, vchName, vchDescription, isChargeable, dcmAmount, intCurrency, dtLastUpdate)
VALUES 
(1, N'Начальный', N'Бесплатный', 0, 0.0, 1, GETDATE()),
(2, N'Премиум', N'Платный', 1, 0.0, 1, GETDATE())

SELECT *
FROM [dbo].[AccountPlans] (nolock)