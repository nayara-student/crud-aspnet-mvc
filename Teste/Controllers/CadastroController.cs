using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teste.Models;

namespace Teste.Controllers
{
    public class CadastroController : Controller
    {
        //private MeuBanco db = new MeuBanco();

        private static List<Models.ProdutoModel> _listaProduto = new List<Models.ProdutoModel>() { 
            new Models.ProdutoModel(){ Id = 1, Codigo = "123", Descricao = "Bola de Basquete", Status = true },
            new Models.ProdutoModel(){ Id = 2, Codigo = "124", Descricao = "Caneca de Vidro Verde", Status = false },
            new Models.ProdutoModel(){ Id = 3, Codigo = "125", Descricao = "Panela de Pressão 30 Litros", Status = true }
        };

        // GET: Cadastro
        
        public ActionResult Produto()
        {
            return View(_listaProduto);
            //return View(db.Grupo.ToList());
        }

        public ActionResult RecuperarGrupoProduto(int id)
        {
            return Json(_listaProduto.Find(x => x.Id == id));
        }

        public ActionResult ExcluirGrupoProduto(int id)
        {
            var ret = false;
            var registroBD = _listaProduto.Find(x => x.Id == id);
            if(registroBD != null)
            {
                _listaProduto.Remove(registroBD);
                ret = true;
            }
            return Json(ret);
        }

        public ActionResult SalvarGrupoProduto(ProdutoModel produtoModel)
        {
            var registroBD = _listaProduto.Find(x => x.Id == produtoModel.Id);
            if (registroBD == null)
            {
                registroBD = produtoModel;
                registroBD.Id = _listaProduto.Max(x => x.Id) + 1;
                _listaProduto.Add(registroBD);
            }
            else
            {
                registroBD.Codigo = produtoModel.Codigo;
                registroBD.Descricao = produtoModel.Descricao;
                registroBD.Status = produtoModel.Status;
            }

            return Json(registroBD);
        }

    }
}