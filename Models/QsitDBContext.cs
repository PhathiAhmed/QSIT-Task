using Microsoft.EntityFrameworkCore;

namespace QSIT.Models
{
    public class QsitDBContext:DbContext
    {
        public QsitDBContext()
        {

        }
        public QsitDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Map> Maps { get; set; }
        public DbSet<Map_Type> Map_Types { get; set; }
        public DbSet<Map_Sub_Type> Map_Sub_Types { get; set; }
    }
}
