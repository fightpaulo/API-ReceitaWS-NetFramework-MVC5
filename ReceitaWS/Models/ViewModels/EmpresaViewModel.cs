using ReceitaWS.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReceitaWS.Models.ViewModels
{
    public class EmpresaViewModel
    {
        [DisplayName("CNPJ ")]
        [Required(ErrorMessage = "O preenchimento desse campo é obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Esse campo precisa ter 14 dígitos numéricos sem traços ou pontos.")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Digite apenas valores numéricos sem traços ou pontos.")]
        public string CnpjDigitado { get; set; }

        public Empresa Empresa { get; set; }

        public string Erro { get; set; }
    }
}