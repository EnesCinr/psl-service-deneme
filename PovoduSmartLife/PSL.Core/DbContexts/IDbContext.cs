using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Core.DbContexts
{
    public interface IDbContext
    {
        DatabaseFacade Database { get; }
    }
}
