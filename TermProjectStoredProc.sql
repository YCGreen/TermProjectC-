ALTER PROC getDQVDC
       @Symbol varchar(10)
 
AS
BEGIN
    WITH CTE AS (
        SELECT 
            tsd.date,
            tra.quantity,
            tra.quantity * tsd.[close] AS value,
            CASE
                WHEN tsd.[date] = (SELECT MIN(tsd1.date)
                                   FROM TS_DailyData tsd1
                                   WHERE tsd1.ticker = tsd.ticker)
                THEN 0 
                ELSE 
                    tra.quantity * (tsd.[close] - LAG(tsd.[close]) OVER (PARTITION BY tsd.ticker ORDER BY tsd.date)) 
            END AS dailypl,
            MIN(tsd.date) OVER (PARTITION BY tsd.ticker) AS min_date -- Minimum date for each ticker
        FROM 
            TS_DailyData tsd
        JOIN 
            Transactions tra ON tsd.ticker = tra.ticker 
        WHERE 
            tsd.Ticker = @Symbol
    )
    
    SELECT DISTINCT
        FORMAT(date, 'yyyy-MM-dd') AS [date],
        quantity,
        FORMAT(value, 'C', 'en-US') AS [value],
        dailypl
    FROM 
        CTE
    WHERE 
        NOT (date > min_date AND dailypl = 0) -- Exclude rows where date is above min(date) and dailypl is 0
    ORDER BY 
        [date];
END









ALTER PROC getDQVDC
       @Symbol varchar(10)
 
AS

SELECT DISTINCT
    [date] = FORMAT(tsd.date, 'yyyy-MM-dd'),
    tra.quantity,
    [value] = FORMAT(tra.quantity * tsd.[close], 'C', 'en-US'),
	dailypl = CASE
					WHEN  tsd.[date] = 
						(SELECT MIN(tsd1.date)
						FROM TS_DailyData tsd1
						WHERE tsd1.ticker = tsd.ticker)
					THEN 0 
					ELSE 
					tra.quantity * (tsd.[close] - LAG(tsd.[close]) OVER 
						(PARTITION BY tsd.ticker ORDER BY tsd.date)) 
				END

FROM 
    TS_DailyData tsd

JOIN 
    Transactions tra ON tsd.ticker = tra.ticker 

WHERE tsd.Ticker = @Symbol  

ORDER BY 
    [Date];


GO


ALTER PROC getTickers 

AS 

SELECT DISTINCT Ticker FROM Transactions

ORDER BY Ticker

GO