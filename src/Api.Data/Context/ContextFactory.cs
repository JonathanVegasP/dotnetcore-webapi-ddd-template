using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyContext>();
            builder.UseInMemoryDatabase("db");
            return new MyContext(builder.Options);
        }
    }
}
