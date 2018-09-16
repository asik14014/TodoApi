INSERT INTO [dbo].[AccountPlans] (vchName, vchDescription, isChargeable, dcmAmount, intCurrency, dtLastUpdate)
VALUES 
(N'Начальный', N'Бесплатный', 0, 0.0, 1, GETDATE()),
(N'Премиум', N'Платный', 1, 0.0, 1, GETDATE())

SELECT *
FROM [dbo].[AccountPlans] (nolock)