using System.Windows.Input;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blezorejemplo.Entidades
{

   public class Productospaquete{
      
      [Key]
        
        
        public int Id { get; set; }
        
         public string? Concepto  { get; set; }
        
         public  DateTime FechaCaducacion { get; set; }
        public float Enpaquetado { get; set; }
        public int Cantidad{ get; set; }
        
       


   }
    
}