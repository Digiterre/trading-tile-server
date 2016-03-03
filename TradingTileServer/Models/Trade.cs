using System;
using Newtonsoft.Json;

namespace TradingTileServer.Controllers
{
    public class Trade
    {
        [JsonProperty("tradeId")]
        public Guid TradeId { get; set; }
        [JsonProperty("symbols")]
        public string Symbols { get; set; }
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("spot")]
        public decimal Spot { get; set; }
        [JsonProperty("quantity")]
        public string Quantity { get; set; }
    }
}