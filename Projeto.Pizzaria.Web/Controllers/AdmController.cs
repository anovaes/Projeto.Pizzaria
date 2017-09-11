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
        // GET: Adm
        public ActionResult Index()
        {
            var dao = new DaoCategoriaProduto();
            var categorias = Mapper.Map<IEnumerable<CategoriaProduto>, IEnumerable<CategoriaProdutoModel>>(dao.Consultar(new CategoriaProduto()));
            return View(categorias);
        }
        [HttpGet]
        public ActionResult Produtos()
        {
            var dao = new DaoCategoriaProduto();
            var categorias = dao.BuscarTodos();
            return View(categorias);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoriaProdutoModel item)
        {
            var categoria = Mapper.Map<CategoriaProdutoModel, CategoriaProduto>(item);
            var dao = new DaoCategoriaProduto();
            dao.Incluir(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var dao = new DaoCategoriaProduto();
            var categoria = Mapper.Map<CategoriaProduto, CategoriaProdutoModel>(dao.Buscar(id));
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Edit(CategoriaProdutoModel item)
        {
            var categoria = Mapper.Map<CategoriaProdutoModel, CategoriaProduto>(item);
            var dao = new DaoCategoriaProduto();
            dao.Alterar(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var dao = new DaoCategoriaProduto();
            var categoria = Mapper.Map<CategoriaProduto, CategoriaProdutoModel>(dao.Buscar(id));
            return View(categoria);
        }

        public ActionResult Delete(int id)
        {
            var dao = new DaoCategoriaProduto();
            var categoria = Mapper.Map<CategoriaProduto, CategoriaProdutoModel>(dao.Buscar(id));
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Delete(CategoriaProduto item)
        {
            var dao = new DaoCategoriaProduto();
            dao.Deletar(int.Parse(item.Id.ToString()));
            return RedirectToAction("Index");
        }
    }
}