using Microsoft.EntityFrameworkCore;
using Blezorejemplo.Entidades;
using Blezorejemplo.DAL;

namespace Blezorejemplo.DAL
{
   public class Contexto : DbContext
    { 

        public DbSet<Productos> Productos {get; set;}
        

        public DbSet<Productospaquete> productospaquetes{ get; set;}
      
        public DbSet<Productoparaayuda> Productoparaayuda { get; set; }
        
        public Contexto(DbContextOptions<Contexto> options) : base(options){}
    }
}