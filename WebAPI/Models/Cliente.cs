using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Cliente
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]

        public int ID { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public bool ativo { get; set; }
    }
}