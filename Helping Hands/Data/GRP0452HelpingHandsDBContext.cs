using Helping_Hands.Data;
using Helping_Hands.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Helping_Hands
{
    public partial class GRP0452HelpingHandsDBContext : IdentityDbContext<UserApp>
    {

        public GRP0452HelpingHandsDBContext(DbContextOptions<GRP0452HelpingHandsDBContext> options)
            : base(options)
        {
        }

        public DbSet<Admins> Admins { get; set; }

        public DbSet<CareContracts> CareContracts { get; set; }
        public DbSet<CareVisits> CareVisits { get; set; }
        public DbSet<ChronicAccoms> ChronicAccoms { get; set; }
        public DbSet<ChronicInfections> ChronicInfections { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<ImageArchive> ImageArchive { get; set; }
        public DbSet<Managers> Managers { get; set; }
        public DbSet<Nurses> Nurses { get; set; }
        public DbSet<Organisations> Organisations { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<PreferedSuburbs> PreferedSuburbs { get; set; }
        public DbSet<Provinces> Provinces { get; set; }
        public DbSet<Suburbs> Suburbs { get; set; }


    }
}
