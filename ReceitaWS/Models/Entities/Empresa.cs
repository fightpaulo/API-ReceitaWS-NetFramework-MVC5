using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReceitaWS.Models.Entities
{
    public class Empresa
    {
        public string Abertura { get; set; }

        [Display(Name = "CNPJ ")]
        public string Cnpj { get; set; }

        [Display(Name = "Última Atualização ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}")]
        public DateTime? Ultima_Atualizacao { get; set; }

        [Display(Name = "Razão Social ")]
        public string Nome { get; set; }

        [Display(Name = "Nome Fantasia ")]
        public string Fantasia { get; set; }

        [Display(Name = "Atividade Principal ")]
        public List<AtividadePrincipal> Atividade_Principal { get; set; }

        [Display(Name = "Atividades Secundárias ")]
        public List<AtividadeSecundaria> Atividades_Secundarias { get; set; }

        [Display(Name = "Natureza Jurídica ")]
        public string Natureza_Juridica { get; set; }

        public string Logradouro { get; set; }

        [Display(Name = "Número ")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Display(Name = "CEP ")]
        public string Cep { get; set; }

        public string Bairro { get; set; }

        [Display(Name = "Município ")]
        public string Municipio { get; set; }

        [Display(Name = "UF ")]
        public string Uf { get; set; }

        [Display(Name = "E-mail ")]
        public string Email { get; set; }

        public Empresa()
        {

        }

        public Empresa(string[] empresaDoArquivo)
        {
            Abertura = empresaDoArquivo[0];
            Cnpj = empresaDoArquivo[1];
            Ultima_Atualizacao = (DateTime?)Convert.ToDateTime(empresaDoArquivo[2]);
            Nome = empresaDoArquivo[3];
            Natureza_Juridica = empresaDoArquivo[6];
            Logradouro = empresaDoArquivo[7];
            Numero = empresaDoArquivo[8];
            Complemento = empresaDoArquivo[9];
            Bairro = empresaDoArquivo[10];
            Cep = empresaDoArquivo[11];
            Municipio = empresaDoArquivo[12];
            Uf = empresaDoArquivo[13];
            Email = empresaDoArquivo[14];
        }

    }
}