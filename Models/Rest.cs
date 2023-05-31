using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Rest
{
    [Table("Hotel")]
    public class HotelData
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;

        public int Price { get; set; }

        public string Images { get; set; } = string.Empty;

    }

    public class HotelDataDbContext : DbContext
    {
        public DbSet<HotelData> Data { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string conString = @" Data Source=W-674PY03-1;Initial Catalog=Leharidb;Persist Security Info=True;User ID=sa;Password=***Integrated Security = True; TrustServerCertificate=True";
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(conString);
        }
    }
    public interface IEmpComponent
    {
        List<HotelData> GetData();
        HotelData GetMenu(int id);
        void AddMenu(HotelData data);
        void UpdateMenu(HotelData data);
        void DeleteMenu(int id);
    }

    public class MenuComponent : IEmpComponent
    {
        public void AddMenu(HotelData data)
        {
            var context = new HotelDataDbContext();
            context.Data.Add(data);
            context.SaveChanges();
        }



        public void DeleteMenu(int id)
        {
            var context = new HotelDataDbContext();
            var check = context.Data.FirstOrDefault(e => e.ItemId == id);
            if (check != null)
            {
                context.Data.Remove(check);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Item not found to delete");
            }
        }



        public HotelData GetMenu(int id)
        {
            var context = new HotelDataDbContext();
            var rec = context.Data.FirstOrDefault(e => e.ItemId == id);
            if (rec != null)
            {
                return rec;
            }
            else
            {
                throw new Exception("Employee not found to delete");
            }
        }

        public List<HotelData> GetData()
        {
            var context = new HotelDataDbContext();
            return context.Data.ToList();
        }

        public void UpdateMenu(HotelData data)
        {
            var context = new HotelDataDbContext();
            var check = context.Data.FirstOrDefault(e => e.ItemId == data.ItemId);
            if (check != null)
            {
                check.ItemName = data.ItemName;
                check.ItemId = data.ItemId;
                check.Price = data.Price;
                check.Images = data.Images;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Menu not found to update");
            }
        }




    }
}