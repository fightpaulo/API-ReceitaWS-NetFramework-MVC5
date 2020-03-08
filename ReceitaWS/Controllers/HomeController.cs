using ReceitaWS.Models.ApiHelper;
using ReceitaWS.Models.Entities;
using ReceitaWS.Models.FileHelper;
using ReceitaWS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReceitaWS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string erro)
        {
            if (!string.IsNullOrEmpty(erro))
            {
                EmpresaViewModel empresaViewModel = new EmpresaViewModel();
                empresaViewModel.Erro = erro;

                return View(empresaViewModel);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(EmpresaViewModel empresaViewModel)
        {
            empresaViewModel.Erro = string.Empty;

            try
            {
                if (ModelState.IsValid)
                {
                    Empresa empresa = ReceitaFederalWebService.GetEmpresaNaReceita(empresaViewModel.CnpjDigitado);
                    empresaViewModel.CnpjDigitado = string.Empty;
                    empresaViewModel.Empresa = empresa;

                    ViewBag.AtividadesPrincipais = empresa.Atividade_Principal != null ?
                        new SelectList(empresa.Atividade_Principal, "Code", "Text") : null;

                    ViewBag.AtividadesSecundarias = empresa.Atividades_Secundarias != null ?
                        new SelectList(empresa.Atividades_Secundarias, "Code", "Text") : null;

                    FileHelper.CriaOuAddAoArquivo(empresa, 
                        Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                }
            }
            catch (Exception ex)
            {
                string erro = ex.Message;

                return RedirectToAction("Index", new { erro } );
            } 

            return View(empresaViewModel);
        }

        public ActionResult ListarConsultas()
        {
            string nomeDoArquivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) 
                + "\\Empresas_Consultadas_RF.csv";

            List<Empresa> empresas = FileHelper.GetInfoDoArquivo(nomeDoArquivo);

            return View("ConsultasRealizadas", empresas);
        }
    }
}