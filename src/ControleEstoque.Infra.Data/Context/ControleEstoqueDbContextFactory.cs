using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace ControleEstoque.Infra.Data.Context
{
    public class ControleEstoqueDbContextFactory : IDesignTimeDbContextFactory<ControleEstoqueContext>
    {
        private readonly IHostingEnvironment _env;

        public ControleEstoqueDbContextFactory(IHostingEnvironment env)
        {
            _env = env;
        }

        public ControleEstoqueContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ControleEstoqueContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new ControleEstoqueContext( _env);
        }
    }
}
