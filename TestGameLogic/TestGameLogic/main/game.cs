using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;
using TestGameLogic.weapons;

namespace TestGameLogic.main
{
    public class game
    {
        public player[] players = null;

        public game()
        {
            //Create units
            warrior warrior1 = new warrior(new sword(), new shield());
            archer archer1 = new archer(new bow(),null);

            warrior warrior2 = warrior1.Clone() as warrior;
            archer archer2 = archer1.Clone() as archer;

            //Create players
            player player1 = new player(warrior1, archer1);
            player player2 = new player(warrior2,archer2);

            players = new player[] { player1,player2 };
        }

    }
}
