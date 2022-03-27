using System.Windows.Input;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blezorejemplo.Entidades
{

   public class Productospaquete{
      
      [Key]
        public int Id { get; set; }
        
         public string? Concepto  { get; set; }
        
         public  DateTime FechaCaducacion { get; set; }= DateTime.Now;
        public float total { get; set; }
        public string NombreproductoProducido { get; set; }
        public int Cantidad{ get; set; }
        public int Producido {get; set;}
        
       public virtual List<Productoparaayuda> AyudaPaquete {get; set;} = new List< Productoparaayuda>();


   }
    
}