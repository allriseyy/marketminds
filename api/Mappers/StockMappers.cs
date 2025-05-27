using api.Models;
using api.Dtos.Stock;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto toStockDto(this Stock stock)
        {
            return new StockDto
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

        public static Stock toStockFromCreateDTO(this CreateStockRequestDto stockDto)
        {
            return new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };
        }

        public static void toStockFromUpdateDTO(this Stock stock, UpdateStockRequestDto dto)
        {
            stock.Symbol = dto.Symbol;
            stock.CompanyName = dto.CompanyName;
            stock.Purchase = dto.Purchase;
            stock.LastDiv = dto.LastDiv;
            stock.Industry = dto.Industry;
            stock.MarketCap = dto.MarketCap;
        }
    }
}
