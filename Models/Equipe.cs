using System;
using System.Collections.Generic;
using System.IO;
using MVC_EPlayers.Interfaces;

namespace MVC_EPlayers.Models
{
    public class Equipe : EplayersBase , IEquipe
    {
        public int IdEquipe {get;set;}
        public string Nome {get;set;}
        public string Imagem {get;set;}
        private const string PATH = "Database/equipe.csv";

        public Equipe(){
            CreateFileAndFolder(PATH);
        }

        public void Create(Equipe equipe){
            string[] linha = {Prepare(equipe)};
            File.AppendAllLines(PATH, linha);
        }

        private string Prepare(Equipe equipe){
            return $"{equipe.IdEquipe};{equipe.Nome};{equipe.Imagem}";
        }

        public void Update(Equipe equipe){
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == equipe.IdEquipe.ToString());
            linhas.Add(Prepare(equipe));
            RewriteCSV(PATH, linhas);
        }

        public void Delete(int id){
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            RewriteCSV(PATH, linhas);
        } 

        public List<Equipe> ReadAll(){
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = int.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }
    }
}