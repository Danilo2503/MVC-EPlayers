using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_EPlayers.Models;

namespace MVC_EPlayers.Controllers
{
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();

        [Route("Listar")]
        public IActionResult Index(){
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form){
            Equipe novaEquipe = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse(form["IdEquipe"]); 
            novaEquipe.Nome = form["Nome"];
            
            if(form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                if(!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using(var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                novaEquipe.Imagem = file.FileName;
            }
            else
            {
                novaEquipe.Imagem = "padrão.png";
            }

            equipeModel.Create(novaEquipe);
            ViewBag.Equipes = equipeModel.ReadAll(); 

            return LocalRedirect("~/Equipe/Listar");      
        }

        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            equipeModel.Delete(id);
            ViewBag.Equipes = equipeModel.ReadAll();
            
            return LocalRedirect("~/Equipe/Listar"); 
        }
    }
}