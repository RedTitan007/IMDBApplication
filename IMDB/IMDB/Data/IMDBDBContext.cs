
namespace IMDB.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.Configuration;
    public partial class IMDBDBContext : DbContext
    {
        public IMDBDBContext(DbContextOptions<IMDBDBContext> options) : base(options) { }
        public IMDBDBContext() : base(GetOptions(ConfigurationManager.ConnectionStrings["ConnectionStrings:DBContext"].ConnectionString.ToString()))
        {
        }
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder().UseLazyLoadingProxies(), connectionString).Options;
        }

        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Moviemapping> Moviemapping { get; set; }
        public virtual DbSet<Producer> Producer { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Moviemapping>().HasKey(sc => new { sc.ActorID, sc.MovieID });


        }

    }
}
