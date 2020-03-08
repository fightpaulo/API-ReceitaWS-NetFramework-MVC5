using Newtonsoft.Json;
using ReceitaWS.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace ReceitaWS.Models.ApiHelper
{
    public class ReceitaFederalWebService
    {
        public static Empresa GetEmpresaNaReceita(string cnpj)
        {
            Empresa empresa = null;
            string responseBody = string.Empty;

            StringBuilder url = new StringBuilder();
            url.Append("https://www.receitaws.com.br/v1/cnpj/");
            url.Append(cnpj);

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    responseBody = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    if (responseBody.Contains("CNPJ inválido"))
                        throw new Exception();
                    
                    empresa = JsonConvert.DeserializeObject<Empresa>(responseBody);

                    empresa.Complemento = !string.IsNullOrEmpty(empresa.Complemento) ?
                        empresa.Complemento.Replace(";", "--") : null;
                }
            }
            catch (Exception ex)
            {
                StringBuilder erro = new StringBuilder();

                if (responseBody.Contains("CNPJ inválido"))
                {
                    erro.AppendLine("O CNPJ digitado é inválido. ");
                    erro.AppendLine("Verifique e tente novamente.");
                }
                else
                {
                    erro.AppendLine("Ocorreu um erro ao pesquisar o CNPJ na Receita Federal. ");
                    erro.AppendLine("Você precisa aguardar pelo menos 2 minutos antes da próxima consulta.");
                }
                

                throw new Exception(erro.ToString());
            }

            return empresa;
        }
    }

        
}