using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestGameLogic.units;
using TestGameLogic.weapons;
using TestGameLogic.units.parts;
using System.Windows.Forms;
using TestGameLogic.main.Grafic;
using TestGameLogic.skills;

namespace TestGameLogic.main
{
    public enum GameStates
    { 
        setUnit = 10,
        waitSetUnit = 11, //TODO not need in test
        doMoves_selectUnit = 12,
        doMoves_targetField = 13,
        waitDoMoves = 14, //TODO not need in test
        calculate = 15,
        //waitOtherPlayerCalculate = 5, //TODO not need in test
        
       
        end = 1000
    }

    public static class Game
    {
        public static Random GameRandom = new Random(DateTime.Now.Millisecond);

        private static List<Player> players = null;
        private static Player currentPlayer = null;
        private static GraficMain graficMain = null;

        private static GameStates gameState = GameStates.setUnit;

        /*public GameStates GameState
        {
            get { return gameState; }
        }*/

        private static void stateMachineLoop()
        { 
            switch(gameState)
            {
                case GameStates.setUnit:
                    setUnits();
                    break;
                case GameStates.doMoves_selectUnit:
                    //doMoves();
                    break;
            
            }
        }

        public static void start(PictureBox battleFieldGrafic, PictureBox actionGrafic, PictureBox propertyGrafic)
        {
            graficMain = new GraficMain(battleFieldGrafic, actionGrafic, propertyGrafic);
            createEverything();
            stateMachineLoop();
        }

        private static void createEverything()
        {
            //Create Everything

            //Create units for player1
            Warrior warrior1 = GameDataFactory.createWarrior();
            warrior1.setWeapon(GameDataFactory.createSword());
            warrior1.setWeapon(GameDataFactory.createShield());

            Archer archer1 = GameDataFactory.createArcher();
            archer1.setWeapon(GameDataFactory.createBow());

            //for player2
            Warrior warrior2 = GameDataFactory.createWarrior();
            warrior2.setWeapon(GameDataFactory.createSword());
            warrior2.setWeapon(GameDataFactory.createShield());

            Archer archer2 = GameDataFactory.createArcher();
            archer2.setWeapon(GameDataFactory.createBow());

            //Create players
            Player player1 = new Player(new List<baseUnit>{warrior1, archer1});
            Player player2 = new Player(new List<baseUnit> { warrior2, archer2 });
            players = new List<Player> { player1, player2 };
            selectPlayer(player1);

            //set init positions for units  
            //TODO 
        }

        private static void setUnits()
        {
            graficMain.BattleField.setPlayers(players);
            graficMain.reDraw();

            gameState = GameStates.doMoves_selectUnit;
            stateMachineLoop();
        }

        public static void battleFieldClick(int x, int y)
        {
            switch (gameState)
            {
                case GameStates.doMoves_selectUnit:
                    doMoves_selectUnit(graficMain.BattleField.calculatePosition(x, y));
                    break;
                case GameStates.doMoves_targetField:
                    doMoves_targetField(graficMain.BattleField.calculatePosition(x, y));
                    break;
            }
        }

        public static void actionBarClick(int x, int y)
        {
            switch (gameState)
            {
                case GameStates.doMoves_targetField:
                    doMoves_targetField_action(graficMain.Actionbar.calculateSkill(x, y));
                    break;
            }
        }

        private static bool doMoves_selectUnit(int position)
        {
            foreach (baseUnit unit in currentPlayer.Units)
            {
                if (unit.Position == position)
                {
                    selectUnit(currentPlayer,unit);
                    //selectedUnit = unit;
                    gameState = GameStates.doMoves_targetField;
                    return true;
                }
            }
            return false;
        }

        private static void selectUnit(Player player, baseUnit unit)
        {
            player.selectUnit(unit);
            graficMain.Actionbar.selectUnit(unit);
            graficMain.Propertybar.selectUnit(unit);

            graficMain.reDraw();
        }

        private static void selectPlayer(Player player)
        {
            currentPlayer = player;

            //battleField.reDraw();
        }

        private static void doMoves_targetField(int position)
        {
            if (!doMoves_selectUnit(position))
            {
                //TODO checklogic
                if (checkLogic(position))
                {
                    currentPlayer.SelectedUnit.Target = position;

                    //currentPlayer.unselectUnit();
                    //gameState = GameStates.doMoves_selectUnit;
                    graficMain.reDraw();
                }
            }
        }

        private static void doMoves_targetField_action(baseActiveSkill skill)
        {
            if (skill != null)
            {
                currentPlayer.SelectedUnit.selectSkill(skill);

                //TODO OLEG
                //currentPlayer.SelectedUnit.selectSkill();


                //TODO OLEG
                /*currentPlayer.SelectedUnit.Target = position;
                currentPlayer.unselectUnit();

                graficMain.reDraw();

                gameState = GameStates.doMoves_selectUnit;*/

                graficMain.reDraw();
            }
        }

        public static void endTurn()
        {
            if (currentPlayer == players.Last())
            {
                gameState = GameStates.calculate;

                currentPlayer = players.First();
            }
            else
            {
                gameState = GameStates.doMoves_selectUnit;

                int index = players.IndexOf(currentPlayer) + 1;
                currentPlayer = players[index];
            }
        }

        private static bool checkLogic(int position)
        {
            bool logicResult = true;

            if (currentPlayer.SelectedUnit.SelectedSkill.needMove())
            {
                //TODO maybe logic not here????
                logicResult &= graficMain.BattleField.checkDistancePossibility(currentPlayer.SelectedUnit.Position, position, currentPlayer.SelectedUnit.Speed);
            }

            return logicResult;
        }
    }
}
