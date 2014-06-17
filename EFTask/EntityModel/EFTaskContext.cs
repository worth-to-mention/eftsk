using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask.EntityModel
{
    public class EFTaskContext : DbContext
    {

        public EFTaskContext()
            :base("name=EFTaskContext")
        {

        }

        public DbSet<Good> Goods { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<WebMoneyPayment> WebMoneyPayments { get; set; }

        public DbSet<CashPayment> CashPayments { get; set; }

        public DbSet<CreditCardPayment> CardPayments { get; set; }

        public DbSet<PayPalPayment> PayPalPayments { get; set; }


        protected override void OnModelCreating(DbModelBuilder builder)
        {
            
            
            builder.Entity<Good>()
                .HasMany(x => x.Categories)
                .WithMany(x => x.Goods)
                .Map(x => x.ToTable("Structure").MapLeftKey("Good").MapRightKey("Category"));
            builder.Entity<Good>()
                .HasMany(x => x.Payments)
                .WithRequired(x => x.Good)
                .Map(x => x.MapKey("Good"));
            builder.Entity<Good>()
                .Property(x => x.Name)
                .IsRequired();

            builder.Entity<Category>()
                .HasMany(x => x.Children)
                .WithOptional(x => x.Parent)
                .HasForeignKey(x => x.Parent_Id);
            builder.Entity<Category>()
                .Property(x => x.Name)
                .IsRequired();

            builder.Entity<Client>()
                .HasMany(x => x.Payments)
                .WithRequired(x => x.Client)
                .Map(x => x.MapKey("Client"));
            builder.Entity<Client>()
                .Property(x => x.Login)
                .IsRequired();
            builder.Entity<Client>()
                .Property(x => x.FirstName)
                .IsRequired();
            builder.Entity<Client>()
                 .Property(x => x.SecondName)
                 .IsRequired();

            builder.ComplexType<ValidityPeriod>();

            builder.Entity<CreditCardPayment>().ToTable("CreditCardPayments");
            builder.Entity<CreditCardPayment>()
                .Property(x => x.CardNumber)
                .HasMaxLength(16);

            builder.Entity<CashPayment>().ToTable("CashPayments");

            builder.Entity<WebMoneyPayment>().ToTable("WebMoneyPayments");
            builder.Entity<WebMoneyPayment>()
                .Property(x => x.EWAlletNumber)
                .HasMaxLength(12);

            builder.Entity<PayPalPayment>().ToTable("PayPalPayments");
            
            base.OnModelCreating(builder);
        }
    }
}
