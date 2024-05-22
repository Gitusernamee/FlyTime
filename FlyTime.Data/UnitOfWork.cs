using System;
using FlyTime.Data.Repositories;

namespace FlyTime.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlyTimeDbContext _context;

        public UnitOfWork(FlyTimeDbContext context)
        {
            _context = context;
            PilotRepository = new PilotRepository(_context);
            FlightRepository = new FlightRepository(_context);

        }

        public IPilotRepository PilotRepository { get; private set; }
        public IFlightRepository FlightRepository { get; private set; }
    

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
