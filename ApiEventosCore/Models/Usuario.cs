using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEventosCore.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(60, ErrorMessage = "O nome deve conter no máxino 60 caracters")]
        [MinLength(5, ErrorMessage = "O nome deve conter no mínimo 5 caracters")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Informe o nome do usuário")]
        [MaxLength(30, ErrorMessage = "O nome deve conter no máxino 60 caracters")]
        [MinLength(5, ErrorMessage = "O nome deve conter no mínimo 5 caracters")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Informe a senha")]
        [MaxLength(200, ErrorMessage = "A senha deve conter no máxino 20 caracters")]
        [MinLength(5, ErrorMessage = "A senha deve conter no mínimo 5 caracters")]
        public string Senha { get; set; }


        [Required(ErrorMessage = "Informe o nome do usuário")]
        [MaxLength(60, ErrorMessage = "O email deve conter no máxino 60 caracters")]
        [MinLength(5, ErrorMessage = "O email deve conter no mínimo 5 caracters")]
        public string Email { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
