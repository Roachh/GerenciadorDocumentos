﻿using Microsoft.AspNetCore.Mvc;
using TesteProcedimentosOperacionais.Models;
using TesteProcedimentosOperacionais.Repositorio;

namespace TesteProcedimentosOperacionais.Controllers
{
    public class DocumentoController : Controller
    {
        private readonly IDocumentoRepositorio _documentoRepositorio;
        private readonly IProcessoRepositorio _processoRepositorio;

        public DocumentoController(IDocumentoRepositorio documentoRepositorio, IProcessoRepositorio processoRepositorio)
        {
            _documentoRepositorio = documentoRepositorio;
            _processoRepositorio = processoRepositorio;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Cadastrar");
        }

        public IActionResult Cadastrar()
        {
            List<Processo> processos = _processoRepositorio.BuscarProcessos();
            ViewBag.Processos = processos;
            return View();
        }
        public IActionResult Consultar()
        {
            List<Documento> documentos = _documentoRepositorio.BuscarDocumentos();
            ViewBag.Documentos = documentos.OrderBy(x => x.Titulo);
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([Bind("Codigo, Titulo, Categoria, ProcessoId, Arquivo")] Documento documento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    documento.NomeArquivo = Guid.NewGuid() + Path.GetFileName(documento.Arquivo.FileName);
                    gravarArquivo(documento.Arquivo, documento.NomeArquivo);
                    _documentoRepositorio.Adicionar(documento);

                    TempData["MensagemSucesso"] = "Documento adicionado com sucesso.";
                    return RedirectToAction("Consultar");
                }

                List<Processo> processos = _processoRepositorio.BuscarProcessos();
                ViewBag.Processos = processos;
                return View(documento);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos adicionar o documento, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("Consultar");
            }
        }

        private async void gravarArquivo(IFormFile arquivo, string nomeArquivo)
        {
            var pathAbsoluto = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/arquivos", nomeArquivo);
            using (var fileStream = new FileStream(pathAbsoluto, FileMode.Create))
            {
                await arquivo.CopyToAsync(fileStream);
            }
        }
    }
}
