using Newtonsoft.Json;

namespace TradingTileServer
{
    public class ExchangeRate
    {
        internal const int BaseDecimals = 500;
        internal const decimal Basespread = 0.00016M;
        internal decimal BaseExchangeRate = 161000M;

        public ExchangeRate(int movement)
        {
            Buy = (BaseExchangeRate + movement) / 100000;
            Sell = Buy - Basespread;
            Spread = Basespread *  10000;
        }

        [JsonProperty("buy")]
        public decimal Buy { get; private set; }

        [JsonProperty("sell")]
        public decimal Sell { get; private set; }

        [JsonProperty("spread")]
        public decimal Spread { get; private set; }
    }
}