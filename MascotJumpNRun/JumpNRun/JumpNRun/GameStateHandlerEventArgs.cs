using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpNRun
{
    public enum GameState
    {
        Lose, Win
    }

    class GameStateHandlerEventArgs
    {
        public GameState State { get; set; }

        public GameStateHandlerEventArgs(GameState state)
        {
            State = state;
        }
    }
}
