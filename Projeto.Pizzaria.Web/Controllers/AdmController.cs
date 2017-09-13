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

        public AdmController(IDaoCategoriaProduto daoCategoria)
        {
            _daoCategoria = daoCategoria;
        }

        // GET: Adm
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoriaProduto()
        {
            //var dao = new DaoCategoriaProduto();
            var categorias = Mapper.Map<IEnumerable<CategoriaProduto>, IEnumerable<CategoriaProdutoModel>>(_daoCategoria.Consultar(new CategoriaProduto()));
            return View(categorias);
        }

        [HttpGet]
        public ActionResult Produtos()
        {
            var dao = new DaoCategoriaProduto();
            var categorias = dao.BuscarTodos();
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
            //var dao = new DaoCategoriaProduto();
            _daoCategoria.Incluir(categoria);
            return RedirectToAction("CategoriaProduto");
        }

        public ActionResult EditCategoriaProduto(int id)
        {
            //var dao = new DaoCategoriaProduto();
            var categoria = Mapper.Map<CategoriaProduto, CategoriaProdutoModel>(_daoCategoria.Buscar(id));
            return View(categoria);
        }

        [HttpPost]
        public ActionResult EditCategoriaProduto(CategoriaProdutoModel item)
        {
            var categoria = Mapper.Map<CategoriaProdutoModel, CategoriaProduto>(item);
            //var dao = new DaoCategoriaProduto();
            _daoCategoria.Alterar(categoria);
            return RedirectToAction("CategoriaProduto");
        }

        public ActionResult DetailsCategoriaProduto(int id)
        {
            //var dao = new DaoCategoriaProduto();
            var categoria = Mapper.Map<CategoriaProduto, CategoriaProdutoModel>(_daoCategoria.Buscar(id));
            return View(categoria);
        }

        public ActionResult DeleteCategoriaProduto(int id)
        {
            //var dao = new DaoCategoriaProduto();
            var categoria = Mapper.Map<CategoriaProduto, CategoriaProdutoModel>(_daoCategoria.Buscar(id));
            return View(categoria);
        }

        [HttpPost]
        public ActionResult DeleteCategoriaProduto(CategoriaProduto item)
        {
            //var dao = new DaoCategoriaProduto();
            _daoCategoria.Deletar(int.Parse(item.Id.ToString()));
            return RedirectToAction("CategoriaProduto");
        }
    }
}