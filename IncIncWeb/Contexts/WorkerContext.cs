using Microsoft.EntityFrameworkCore;

namespace IncIncWeb.Contexts
{
	public class WorkerContext : DbContext
	{
		public WorkerContext(DbContextOptions<WorkerContext> options) : base(options)
		{

		}

		public DbSet<WorkerContext> Worker { get; set; }
	}
}
