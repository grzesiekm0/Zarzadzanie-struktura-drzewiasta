using Microsoft.EntityFrameworkCore;

namespace TaskManager.Models
{
   public partial class TreeManagerContex : DbContext
    {
        public TreeManagerContex(DbContextOptions options) : base(options)
        {
        }
    
        public DbSet<TreeView> Tree { get; set; }

    }
}
