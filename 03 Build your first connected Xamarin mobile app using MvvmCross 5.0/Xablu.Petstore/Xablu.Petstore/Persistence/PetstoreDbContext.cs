using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Xablu.Petstore.Models;

namespace Xablu.Petstore.Persistence
{
    public class PetstoreDbContext : DbContext
    {
        public const string SqlLiteFileName = "petstore.db";

        public PetstoreDbContext(DbContextOptions<PetstoreDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<PetDbContext> Pets { get; set; }
        public DbSet<OrderDbContext> Orders { get; set; }
    }

    public class PetDbContext
    {
        private Pet _pet;
        public long PetDbContextId { get; set; }

        [NotMapped]
        public Pet Pet
        {
            get
            {
                if (_pet == null)
                {
                    _pet = JsonConvert.DeserializeObject<Pet>(JsonPet);
                }
                if (_pet.Id == null) _pet.Id = PetDbContextId;
                return _pet;
            }
            set
            {
                _pet = value;
                JsonPet = JsonConvert.SerializeObject(_pet);
            }
        }

        public string JsonPet { get; set; }
    }

    public class OrderDbContext
    {
        private Order _order;

        public long OrderDbContextId { get; set; }

        [NotMapped]
        public Order Order
        {
            get
            {
                if (_order == null)
                {
                    _order = JsonConvert.DeserializeObject<Order>(JsonOrder);
                }
                if (_order.Id == null) _order.Id = OrderDbContextId;
                return _order;
            }
            set
            {
                _order = value;
                JsonOrder = JsonConvert.SerializeObject(_order);
            }
        }

        public string JsonOrder { get; set; }

    }
}
