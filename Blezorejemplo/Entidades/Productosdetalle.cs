using System.Windows.Input;
using System.ComponentModel.DataAnnotations;

namespace Blezorejemplo.Entidades
{

    public class Productosdetalle
    {

        [Key]
    
        
        public int Id { get; set; }
        public int ProductoId { get; set; }
        
       
        public string? Presentacion { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la descricion")]
       
         
        public float Precio { get; set; }
        public int cantidad{ get; set; }
        public int Existenciaempaquetado{ get; set; }
      
      


    }

}