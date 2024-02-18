using Cobranca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobranca.InfraStructure.Context
{
    public class CobrancaContext : DbContext
    {
        public CobrancaContext(DbContextOptions<CobrancaContext> op) : base(op) { }
        
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Boleto> Boletos { get; set; }
    }
}
