﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AndruhaBot
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class mainbaseEntities : DbContext
    {
        private static mainbaseEntities _context;
        public mainbaseEntities()
            : base("name=mainbaseEntities")
        {
        }
        public static mainbaseEntities GetContext()
        {
            if (_context == null)
                _context = new mainbaseEntities ();

            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Grafik> Grafik { get; set; }
        public virtual DbSet<Pol> Pol { get; set; }
        public virtual DbSet<Rezume> Rezume { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRezume> UserRezume { get; set; }
        public virtual DbSet<Zanaytost> Zanaytost { get; set; }
    }
}
