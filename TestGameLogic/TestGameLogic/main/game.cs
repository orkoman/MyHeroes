using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;
using TestGameLogic.weapons;
using TestGameLogic.units.parts;

namespace TestGameLogic.main
{
    public class Game
    {
        public static Random GameRandom = new Random(DateTime.Now.Millisecond);

        public Player[] players = null;

        public Game()
        {

            //Create units
            Sword sword1 = GameDataFactory.createSword();
            Shield shield1 = GameDataFactory.createShield();
            Warrior warrior1 = GameDataFactory.createWarrior();
            //TODO
            //warrior1.setWeapon(sword1, warrior1.getParts(typeof(Hand), 0));
            //warrior1.setWeapon(shield1,warrior1.getParts(typeof(OffHand),1));

            Bow bow1 = GameDataFactory.createBow();
            Archer archer1 = GameDataFactory.createArcher();
            //TODO
            //archer1.setWeapon(bow1, archer1.getParts(typeof(Hand), 2));

            //TODO OLEG
            Warrior warrior2 = warrior1.Clone() as Warrior;
            Archer archer2 = archer1.Clone() as Archer;

            //Create players
            Player player1 = new Player(new List<baseUnit>{warrior1, archer1});
            Player player2 = new Player(new List<baseUnit> { warrior2, archer2 });

            players = new Player[] { player1,player2 };
        }

    }
}
