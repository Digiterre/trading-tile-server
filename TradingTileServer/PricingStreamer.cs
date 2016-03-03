using System;
using System.Reactive.Linq;
using System.Threading;
using Microsoft.AspNet.SignalR;
using TradingTileServer.Hubs;

namespace TradingTileServer
{
    public class PricingStreamer
    {
        private IHubContext _context;
        
        public void StartStreaming()
        {
            Thread.Sleep(5000);

            _context = GlobalHost.ConnectionManager.GetHubContext<PricingHub>();

            CreateExchangeMovementObserverable().Subscribe(StreamPrice);                        
        }

        private IObservable<int> CreateExchangeMovementObserverable()
        {
            var rnd = new Random();
            
            var xm =
                Observable
                    .Generate(
                        0,
                        x => x < int.MaxValue,
                        x => x + 1,
                        x => ExchangeRate.BaseDecimals + rnd.Next(-5, 5),
                        x => TimeSpan.FromSeconds((rnd.NextDouble() * 3.0)));

            return xm;
        }
        
        private void StreamPrice(int movement)
        {
            _context.Clients.All.rateChanged(new ExchangeRate(movement));
        }
    }
}