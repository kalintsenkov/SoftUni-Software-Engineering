  SELECT CountryName,
         CountryCode,
  CASE
    WHEN CurrencyCode != 'EUR' THEN 'Not Euro'
    WHEN CurrencyCode = 'EUR' THEN 'Euro'
    ELSE 'Not Euro'
  END AS Currency
    FROM Countries
ORDER BY CountryName
