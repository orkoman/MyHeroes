using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using TestGameLogic.units;

namespace TestGameLogic.main.Grafic
{
    public class GraficMain
    {
        private Battlefield battleField = null;
        private ActionBar actionBar = null;
        private PropertyBar propertyBar = null;

        public Battlefield BattleField
        {
            get { return battleField; } 
        }

        public ActionBar Actionbar
        {
            get { return actionBar; }
        }

        public PropertyBar Propertybar
        {
            get { return propertyBar; }
        }

        public GraficMain(PictureBox battleFieldGrafic, PictureBox actionGrafic, PictureBox propertyGrafic)
        {
            //Create battlefield
            battleField = new Battlefield(battleFieldGrafic, 15, 10);
            actionBar = new ActionBar(actionGrafic, 10);
            propertyBar = new PropertyBar(propertyGrafic, 200, 500);
        }

        public void reDraw()
        {
            battleField.reDraw();
            actionBar.reDraw();
            propertyBar.reDraw();
        }
    }
}
