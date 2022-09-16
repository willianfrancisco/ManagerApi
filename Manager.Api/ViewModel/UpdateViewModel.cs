using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Api.ViewModel
{
    public class UpdateViewModel
    {
        [Required(ErrorMessage = "O Id não pode ser vazio.")]
        [Range(1, int.MaxValue, ErrorMessage = "O Id deve ter no minimo um caractere")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome não pode ser nulo")]
        [MinLength(3, ErrorMessage = "O nome deve ter no minimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O e-mail não pode ser nulo")]
        [MinLength(10, ErrorMessage = "O e-mail deve ter no minimo 10 caracteres")]
        [MaxLength(180, ErrorMessage = "O e-mail deve ter no máximo 180 caracteres")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$",
                            ErrorMessage = "O e-mail informado não e valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha não pode ser nulo")]
        [MinLength(6, ErrorMessage = "A senha deve ter no minimo 6 caracteres")]
        [MaxLength(80, ErrorMessage = "A senha deve ter no máximo 80 caracteres")]
        public string Password { get; set; }
    }
}
