using System.Windows.Input;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blezorejemplo.Entidades
{

   public class Productos{
      
       [Key]
       public int ProductoId { get; set; }
       
       [Required(ErrorMessage ="Es obligatorio introducir la descricion")]
       public string? Descripcion { get; set; }
       public int  Existencia { get; set; }
       [Required(ErrorMessage ="Es obligatorio introducir la descricion")]
       [Range(1,int.MaxValue,ErrorMessage ="El costo sale del rango")]
       public int  Costo { get; set; }

       public float ValorInventario { get; set; }
        public double Precio { get; set; }
      
        public  DateTime FechaCaducacion { get; set; }= DateTime.Now;
        
        public float Gramo { get; set; }
        public int Ganancia { get; set; }
       [ForeignKey("ProductoId")]
       
        public virtual List< Productosdetalle> DetalleProducto {get; set;} = new List< Productosdetalle>();
    

   }
    
}