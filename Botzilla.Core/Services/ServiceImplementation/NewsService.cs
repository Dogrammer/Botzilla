using Botzilla.Core.Services.ServiceContract;
using Botzilla.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Botzilla.Core.Services.ServiceImplementation
{
    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext _context;

        public NewsService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
