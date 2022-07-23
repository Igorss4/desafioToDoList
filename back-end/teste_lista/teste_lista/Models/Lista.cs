using System.ComponentModel.DataAnnotations;

namespace teste_lista.Models
{
    public class Lista
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }

        public string Descricao { get; set; }

        public Boolean Concluida { get; set; }
    }
}
