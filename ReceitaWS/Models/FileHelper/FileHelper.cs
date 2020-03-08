using ReceitaWS.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ReceitaWS.Models.FileHelper
{
    public class FileHelper
    {
        public static void CriaOuAddAoArquivo(Empresa empresa, string caminho)
        {
            string nomeArquivo = "Empresas_Consultadas_RF.csv";
            string nomeCompletoArquivo = caminho + "\\" + nomeArquivo;
           
            if (!File.Exists(nomeCompletoArquivo))
            {
                using (StreamWriter streamWriter = new StreamWriter(nomeCompletoArquivo, true, Encoding.UTF8))
                {
                    streamWriter.Write("Data de Abertura");
                    streamWriter.Write(";CNPJ");
                    streamWriter.Write(";Última Atualização");
                    streamWriter.Write(";Razão Social");
                    streamWriter.Write(";Atividades Principais");
                    streamWriter.Write(";Atividades Secundárias");
                    streamWriter.Write(";Natureza Jurídica");
                    streamWriter.Write(";Logradouro");
                    streamWriter.Write(";Número");
                    streamWriter.Write(";Complemento");
                    streamWriter.Write(";Bairro");
                    streamWriter.Write(";CEP");
                    streamWriter.Write(";Município");
                    streamWriter.Write(";UF");
                    streamWriter.Write(";E-mail");
                    streamWriter.Write(";Adicionado ao arquivo em");

                    streamWriter.WriteLine();
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(nomeCompletoArquivo, true, Encoding.UTF8))
            {
                streamWriter.Write(empresa.Abertura);
                streamWriter.Write(";" + empresa.Cnpj);
                streamWriter.Write(";" + empresa.Ultima_Atualizacao);
                streamWriter.Write(";" + empresa.Nome);

                streamWriter.Write(";");

                if (empresa.Atividade_Principal != null)
                {
                    foreach (var atividadePrincipal in empresa.Atividade_Principal)
                    {
                        streamWriter.Write("-> " + atividadePrincipal + "  ");
                    }
                }
                else
                {
                    streamWriter.Write(" - ");
                }
                
                streamWriter.Write(";");

                if (empresa.Atividades_Secundarias != null)
                {
                    foreach (var atividadeSecundaria in empresa.Atividades_Secundarias)
                    {
                        streamWriter.Write("-> " + atividadeSecundaria + "  ");
                    }
                }
                else
                {
                    streamWriter.Write(" - ");
                }

                streamWriter.Write(";" + empresa.Natureza_Juridica);
                streamWriter.Write(";" + empresa.Logradouro);
                streamWriter.Write(";" + empresa.Numero);
                streamWriter.Write(";" + empresa.Complemento);
                streamWriter.Write(";" + empresa.Bairro);
                streamWriter.Write(";" + empresa.Cep);
                streamWriter.Write(";" + empresa.Municipio);
                streamWriter.Write(";" + empresa.Uf);
                streamWriter.Write(";" + empresa.Email);
                streamWriter.Write(";" + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

                streamWriter.WriteLine();
            }
        }

        public static List<Empresa> GetInfoDoArquivo(string nomeDoArquivo)
        {
            Empresa empresa = null;
            List<Empresa> empresas = new List<Empresa>();

            if (File.Exists(nomeDoArquivo))
            {
                using (StreamReader sr = File.OpenText(nomeDoArquivo))
                {
                    List<string> linhas = new List<string>();

                    while (!sr.EndOfStream)
                    {
                        linhas.Add(sr.ReadLine());
                    }

                    // Remove o cabeçalho
                    linhas.RemoveAt(0);

                    foreach (string linha in linhas)
                    {
                        string[] empresaLida = linha.Split(';');
                        empresa = new Empresa(empresaLida);
                        empresas.Add(empresa);
                    }
                }
            }

            return empresas;
        }
    }
}
