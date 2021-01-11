using System.Collections.Generic;
using System.IO;

namespace MVC_EPlayers.Models
{
    public class EplayersBase
    {
        public void CreateFileAndFolder(string _path){
            string folder = _path.Split("/")[0];

            if(!Directory.Exists(folder)){
                Directory.CreateDirectory(folder);
            }
            if(!File.Exists(_path)){
                File.Create(_path);   
            }
        }
        public List<string> ReadAllLinesCSV(string PATH){

            List<string> linhas = new List<string>();
            using(StreamReader file = new StreamReader(PATH))
            {
                string linha;
                while((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;        
        }
        public void RewriteCSV(string PATH, List<string> linhas){
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
        public void Update(Equipe e){
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add(Prepare(e));
            RewriteCSV(PATH, linhas);
        }
        public void Delete(int id){
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            RewriteCSV(PATH, linhas);
        }        
    }
}