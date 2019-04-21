namespace WarehouseApp
{
    using System.Data.Entity;

    public class WarehouseContext : DbContext
    {
        public WarehouseContext()
            : base("name=WarehouseContext")
        {
        }
         public virtual DbSet<Item> Items { get; set; }
    }
}