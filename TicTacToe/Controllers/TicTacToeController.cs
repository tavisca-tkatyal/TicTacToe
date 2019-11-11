using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    public class TicTacToeController : ApiController
    {
        static Game game = new Game();
        // GET: api/TicTacToe
        public String Get()
        {
            return game.DisplayBoard();
        }

        // GET: api/TicTacToe/5
        public String Get(int id)
        {
            return "value";
        }

        // POST: api/TicTacToe/11 
        public void Post(int id)
        {
            
        }

        // PUT: api/TicTacToe/11
        public String Put(int id)
        {
           String winner = game.MakeAMove(id);
            if(winner !="")
            {
                game = new Game();
                return winner;
            }
            return game.DisplayBoard() + winner;
        }

        // DELETE: api/TicTacToe/5
        public void Delete(int id)
        {
        }
    }
}
