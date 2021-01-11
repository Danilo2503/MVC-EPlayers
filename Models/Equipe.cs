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

        public void Create(Equipe e){
            string[] linha = {Prepare(e)};
            File.AppendAllLines(PATH, linha);
        }

        private string Prepare(Equipe e){
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        public void Create(Equipe equipe){
            string[] linhas = {Prepare(e)};
            File.AppendAllLines(PATH, linhas);
        }

        public void Update(Equipe e){
            throw new System.NotImplementedException();
        }

        public void Delete(int id){
            throw new System.NotImplementedException();
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