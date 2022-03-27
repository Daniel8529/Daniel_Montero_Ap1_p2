using System.Windows.Input;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blezorejemplo.Entidades
{

   public class Productoparaayuda{
      
      [Key]
        
        public int Id { get; set; }
        public int Idresta { get; set; }
       public  string? descricion { get; set; }
         public string? Concepto  { get; set; }
        public int Cantidad{ get; set; }
        
       
      public Productoparaayuda(string? concepto , int cantidad,int  idresta){
        Concepto=concepto;
         Idresta= idresta;
        Cantidad=cantidad;

     }

   }
    
}