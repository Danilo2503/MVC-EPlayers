using System.Collections.Generic;
using MVC_EPlayers.Models;

namespace MVC_EPlayers.Interfaces
{
    public interface IEquipe
    {
        void Create(Equipe e);

        List<Equipe> ReadAll();

        void Update(Equipe e);

        void Delete(int id);         
    }
}