﻿namespace api.Mappers
{
    public static class StockMappers
    {
        public static Dtos.Stock.StockDto toStockDto(this Models.Stock stock)
        {
            return new Dtos.Stock.StockDto
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                Purchase = stock.Purchase,
                LastDiv = stock.LastDiv,
                Industry = stock.Industry,
                MarketCap = stock.MarketCap
            };
        }
    }
}
