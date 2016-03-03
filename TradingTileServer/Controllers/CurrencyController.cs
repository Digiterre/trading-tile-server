using System;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using TradingTileServer.Hubs;

namespace TradingTileServer.Controllers
{
    [RoutePrefix("api/currency")]
    public class CurrencyController : ApiController
    {
        private readonly Lazy<IHubContext> _pricingHub =
            new Lazy<IHubContext>(() => GlobalHost.ConnectionManager.GetHubContext<PricingHub>());


        /// <summary>
        /// Debug endpoint to ensure signalr is working in CORS environment
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost] 
        public IHttpActionResult Post(string message)
        {
            _pricingHub.Value.Clients.All.ping();

            return Ok();
        }

        [Route("execute")]
        public IHttpActionResult Execute([FromBody] Trade trade)
        {
            trade.TradeId = Guid.NewGuid();
            trade.Action = (trade.Action == "Buy") ? "Bought" : "Sold";
            return Ok(trade);
        }

        
    }
}