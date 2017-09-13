using AutoMapper;
using Projeto.Pizzaria.Dao.Data;
using Projeto.Pizzaria.Dao.Entidade;
using Projeto.Pizzaria.Dao.Interface;
using Projeto.Pizzaria.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Pizzaria.Web.Controllers
{
    public class AdmController : Controller
    {
        readonly IDaoCategoriaProduto _daoCategoria;
        readonly IDaoProduto _daoProduto;

        public AdmController(IDaoCategoriaProduto daoCategoria, IDaoProduto daoProduto)
        {
            _daoCategoria = daoCategoria;
            _daoProduto = daoProduto;
        }

        //**********
        // HOME
        //**********
        public ActionResult Index()
        {
            return View();
        }

        //**********
        // Categoria Produto
        //**********
        public ActionResult CategoriaProduto()
        {
            var categorias = Mapper.Map<IEnumerable<CategoriaProduto>, IEnumerable<CategoriaProdutoModel>>(_daoCategoria.Consultar(new CategoriaProduto()));
            return View(categorias);
        }

        public ActionResult CreateCategoriaProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategoriaProduto(CategoriaProdutoModel item)
        {
            var categoria = Mapper.Map<CategoriaProdutoModel, CategoriaProduto>(item);
            _daoCategoria.Incluir(categoria);
            return RedirectToAction("CategoriaProduto");
        }

        private ActionResult BuscarCategoria(int id)
        {
            var categoria = Mapper.Map<CategoriaProduto, CategoriaProdutoModel>(_daoCategoria.Buscar(id));
            return View(categoria);
        }

        public ActionResult EditCategoriaProduto(int id)
        {
            return BuscarCategoria(id);
        }

        [HttpPost]
        public ActionResult EditCategoriaProduto(CategoriaProdutoModel item)
        {
            var categoria = Mapper.Map<CategoriaProdutoModel, CategoriaProduto>(item);
            _daoCategoria.Alterar(categoria);
            return RedirectToAction("CategoriaProduto");
        }

        public ActionResult DetailsCategoriaProduto(int id)
        {
            return BuscarCategoria(id);
        }

        public ActionResult DeleteCategoriaProduto(int id)
        {
            return BuscarCategoria(id);
        }

        [HttpPost]
        public ActionResult DeleteCategoriaProduto(CategoriaProduto item)
        {
            _daoCategoria.Deletar(int.Parse(item.Id.ToString()));
            return RedirectToAction("CategoriaProduto");
        }

        //**********
        // Produto
        //**********

        [HttpGet]
        public ActionResult Produto()
        {
            //var categorias = Mapper.Map<IEnumerable<CategoriaProduto>, IEnumerable<CategoriaProdutoModel>>(_daoCategoria.Consultar(new CategoriaProduto()));
            var produtos = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoModel>>(_daoProduto.Consultar(new Produto()));
            return View(produtos);
        }

        public ActionResult CreateProduto()
        {
            var categorias = Mapper.Map<IEnumerable<CategoriaProduto>, IEnumerable<CategoriaProdutoModel>>(_daoCategoria.Consultar(new CategoriaProduto()));
            var produtos = new ProdutoModel() { CategoriaProduto = categorias };
            return View(produtos);
        }

        [HttpPost]
        public ActionResult CreateProduto(ProdutoModel item)
        {
            var produto = Mapper.Map<ProdutoModel, Produto>(item);
            _daoProduto.Incluir(produto);
            return RedirectToAction("Produto");
        }

        private ActionResult BuscarProduto(int id)
        {
            var produto = Mapper.Map<Produto, ProdutoModel>(_daoProduto.Buscar(id));
            return View(produto);
        }

        public ActionResult EditProduto(int id)
        {
            var categorias = Mapper.Map<IEnumerable<CategoriaProduto>, IEnumerable<CategoriaProdutoModel>>(_daoCategoria.Consultar(new CategoriaProduto()));
            var produto = Mapper.Map<Produto, ProdutoModel>(_daoProduto.Buscar(id));
            produto.CategoriaProduto = categorias;
            return View(produto);
        }

        [HttpPost]
        public ActionResult EditProduto(ProdutoModel item)
        {
            var produto = Mapper.Map<ProdutoModel, Produto>(item);
            _daoProduto.Alterar(produto);
            return RedirectToAction("Produto");
        }

        public ActionResult DetailsProduto(int id)
        {
            return BuscarProduto(id);
        }

        public ActionResult DeleteProduto(int id)
        {
            return BuscarProduto(id);
        }

        [HttpPost]
        public ActionResult DeleteProduto(CategoriaProduto item)
        {
            _daoProduto.Deletar(int.Parse(item.Id.ToString()));
            return RedirectToAction("Produto");
        }
    }
}