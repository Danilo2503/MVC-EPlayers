using System.Collections.Generic;
using MVC_EPlayers.Models;

namespace MVC_EPlayers.Interfaces
{
    public interface IJogador
    {
        void Create(Jogador j);
        List<Jogador> ReadAll();
        void Update(Jogador j);
        void Delete(int id);
    }
}