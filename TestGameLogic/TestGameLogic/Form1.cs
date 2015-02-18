using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestGameLogic.main.Tests;
using TestGameLogic.main.Requirements;
using TestGameLogic.main;

namespace TestGameLogic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AutoSize = true;


            Game.start(pictureBox1, pictureBox2);


            pictureBox2.Left = pictureBox1.Left;
            pictureBox2.Top = pictureBox1.Top + pictureBox1.Height + 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            button1.Text = testBaseRequirement().ToString();
        }


        bool testBaseRequirement()
        {
            bool result = true;

            TestObject testObject = new TestObject();

            baseRequirement<TestObject> xFalse = new TestCharacteristicsRequirement("xFalse",40, 0);
            baseRequirement<TestObject> xTrue = new TestCharacteristicsRequirement("xTrue", 50, 0);
            baseRequirement<TestObject> yFalse = new TestCharacteristicsRequirement("yFalse", 40, 0);
            baseRequirement<TestObject> yTrue = new TestCharacteristicsRequirement("yTrue", 50, 0);
            baseRequirement<TestObject> zFalse = new TestCharacteristicsRequirement("zFalse", 40, 0);
            baseRequirement<TestObject> zTrue = new TestCharacteristicsRequirement("zTrue", 50, 0);

            baseRequirement<TestObject> req = xTrue;
            result &= (req.checkAll(testObject) == true);
            req = xFalse;
            result &= (req.checkAll(testObject) == false);

            req = xTrue.or(xFalse);
            result &= (req.checkAll(testObject) == true);
            req = yTrue.and(yFalse);
            result &= (req.checkAll(testObject) == false);

            xFalse = new TestCharacteristicsRequirement("xFalse", 40, 0);
            xTrue = new TestCharacteristicsRequirement("xTrue", 50, 0);
            yFalse = new TestCharacteristicsRequirement("yFalse", 40, 0);
            yTrue = new TestCharacteristicsRequirement("yTrue", 50, 0);
            zFalse = new TestCharacteristicsRequirement("zFalse", 40, 0);
            zTrue = new TestCharacteristicsRequirement("zTrue", 50, 0);

            req = (xTrue.or(xFalse)).and(yTrue);
            result &= (req.checkAll(testObject) == true);
            req = (yTrue.and(yFalse)).or(zTrue);
            result &= (req.checkAll(testObject) == true);

            xFalse = new TestCharacteristicsRequirement("xFalse", 40, 0);
            xTrue = new TestCharacteristicsRequirement("xTrue", 50, 0);
            yFalse = new TestCharacteristicsRequirement("yFalse", 40, 0);
            yTrue = new TestCharacteristicsRequirement("yTrue", 50, 0);
            zFalse = new TestCharacteristicsRequirement("zFalse", 40, 0);
            zTrue = new TestCharacteristicsRequirement("zTrue", 50, 0);

            req = (xFalse.or(xTrue)).and(yTrue);
            result &= (req.checkAll(testObject) == true);
            req = (yFalse.and(yTrue)).or(zTrue);
            result &= (req.checkAll(testObject) == true);
            
            //--

            xFalse = new TestCharacteristicsRequirement("xFalse", 40, 0);
            xTrue = new TestCharacteristicsRequirement("xTrue", 50, 0);
            yFalse = new TestCharacteristicsRequirement("yFalse", 40, 0);
            yTrue = new TestCharacteristicsRequirement("yTrue", 50, 0);
            zFalse = new TestCharacteristicsRequirement("zFalse", 40, 0);
            zTrue = new TestCharacteristicsRequirement("zTrue", 50, 0);

            req = (xTrue.or(xFalse)).or(yTrue);
            result &= (req.checkAll(testObject) == true);
            req = (yTrue.and(yFalse)).and(zTrue);
            result &= (req.checkAll(testObject) == false);

            xFalse = new TestCharacteristicsRequirement("xFalse", 40, 0);
            xTrue = new TestCharacteristicsRequirement("xTrue", 50, 0);
            yFalse = new TestCharacteristicsRequirement("yFalse", 40, 0);
            yTrue = new TestCharacteristicsRequirement("yTrue", 50, 0);
            zFalse = new TestCharacteristicsRequirement("zFalse", 40, 0);
            zTrue = new TestCharacteristicsRequirement("zTrue", 50, 0);

            req = (xFalse.or(xTrue)).or(yFalse);
            result &= (req.checkAll(testObject) == true);
            req = (yFalse.and(yTrue)).and(zTrue);
            result &= (req.checkAll(testObject) == false);

            //--

            xFalse = new TestCharacteristicsRequirement("xFalse", 40, 0);
            xTrue = new TestCharacteristicsRequirement("xTrue", 50, 0);
            yFalse = new TestCharacteristicsRequirement("yFalse", 40, 0);
            yTrue = new TestCharacteristicsRequirement("yTrue", 50, 0);
            zFalse = new TestCharacteristicsRequirement("zFalse", 40, 0);
            zTrue = new TestCharacteristicsRequirement("zTrue", 50, 0);

            req = (xTrue.or(xFalse)).and(yTrue.or(yFalse));
            result &= (req.checkAll(testObject) == true);

            xFalse = new TestCharacteristicsRequirement("xFalse", 40, 0);
            xTrue = new TestCharacteristicsRequirement("xTrue", 50, 0);
            yFalse = new TestCharacteristicsRequirement("yFalse", 40, 0);
            yTrue = new TestCharacteristicsRequirement("yTrue", 50, 0);
            zFalse = new TestCharacteristicsRequirement("zFalse", 40, 0);
            zTrue = new TestCharacteristicsRequirement("zTrue", 50, 0);

            req = (xFalse.or(xTrue)).and(yFalse.or(yTrue));
            result &= (req.checkAll(testObject) == true);

            //--

            xFalse = new TestCharacteristicsRequirement("xFalse", 40, 0);
            xTrue = new TestCharacteristicsRequirement("xTrue", 50, 0);
            yFalse = new TestCharacteristicsRequirement("yFalse", 40, 0);
            yTrue = new TestCharacteristicsRequirement("yTrue", 50, 0);
            zFalse = new TestCharacteristicsRequirement("zFalse", 40, 0);
            zTrue = new TestCharacteristicsRequirement("zTrue", 50, 0);

            req = (xTrue.and(xFalse)).or(yTrue.and(yFalse));
            result &= (req.checkAll(testObject) == false);

            xFalse = new TestCharacteristicsRequirement("xFalse", 40, 0);
            xTrue = new TestCharacteristicsRequirement("xTrue", 50, 0);
            yFalse = new TestCharacteristicsRequirement("yFalse", 40, 0);
            yTrue = new TestCharacteristicsRequirement("yTrue", 50, 0);
            zFalse = new TestCharacteristicsRequirement("zFalse", 40, 0);
            zTrue = new TestCharacteristicsRequirement("zTrue", 50, 0);

            req = (xFalse.or(xTrue)).and(yFalse.and(yTrue));
            result &= (req.checkAll(testObject) == false);

            //--

            xFalse = new TestCharacteristicsRequirement("xFalse", 40, 0);
            xTrue = new TestCharacteristicsRequirement("xTrue", 50, 0);
            yFalse = new TestCharacteristicsRequirement("yFalse", 40, 0);
            yTrue = new TestCharacteristicsRequirement("yTrue", 50, 0);
            zFalse = new TestCharacteristicsRequirement("zFalse", 40, 0);
            zTrue = new TestCharacteristicsRequirement("zTrue", 50, 0);

            req = (xTrue.and(xFalse)).or(yTrue.and(yFalse)).or(zTrue);
            result &= (req.checkAll(testObject) == true);

            xFalse = new TestCharacteristicsRequirement("xFalse", 40, 0);
            xTrue = new TestCharacteristicsRequirement("xTrue", 50, 0);
            yFalse = new TestCharacteristicsRequirement("yFalse", 40, 0);
            yTrue = new TestCharacteristicsRequirement("yTrue", 50, 0);
            zFalse = new TestCharacteristicsRequirement("zFalse", 40, 0);
            zTrue = new TestCharacteristicsRequirement("zTrue", 50, 0);

            req = (xTrue.and(xFalse)).or(yTrue.and(yFalse)).or(zFalse);
            result &= (req.checkAll(testObject) == false);

            //--

            xFalse = new TestCharacteristicsRequirement("xFalse", 40, 0);
            xTrue = new TestCharacteristicsRequirement("xTrue", 50, 0);
            yFalse = new TestCharacteristicsRequirement("yFalse", 40, 0);
            yTrue = new TestCharacteristicsRequirement("yTrue", 50, 0);
            zFalse = new TestCharacteristicsRequirement("zFalse", 40, 0);
            zTrue = new TestCharacteristicsRequirement("zTrue", 50, 0);

            req = (xTrue.and(xFalse)).or(yTrue.and(yFalse)).or(zTrue.or(zFalse));
            result &= (req.checkAll(testObject) == true);

            xFalse = new TestCharacteristicsRequirement("xFalse", 40, 0);
            xTrue = new TestCharacteristicsRequirement("xTrue", 50, 0);
            yFalse = new TestCharacteristicsRequirement("yFalse", 40, 0);
            yTrue = new TestCharacteristicsRequirement("yTrue", 50, 0);
            zFalse = new TestCharacteristicsRequirement("zFalse", 40, 0);
            zTrue = new TestCharacteristicsRequirement("zTrue", 50, 0);

            req = (xTrue.and(xFalse)).or(yTrue.and(yFalse)).and(zFalse.or(zTrue));
            result &= (req.checkAll(testObject) == false);

            //--

            xFalse = new TestCharacteristicsRequirement("xFalse", 40, 0);
            xTrue = new TestCharacteristicsRequirement("xTrue", 50, 0);
            yFalse = new TestCharacteristicsRequirement("yFalse", 40, 0);
            yTrue = new TestCharacteristicsRequirement("yTrue", 50, 0);
            zFalse = new TestCharacteristicsRequirement("zFalse", 40, 0);
            zTrue = new TestCharacteristicsRequirement("zTrue", 50, 0);

            req = (xTrue.and(xFalse)).or(yTrue.or(yFalse)).and(zTrue.or(zFalse));
            result &= (req.checkAll(testObject) == true);

            xFalse = new TestCharacteristicsRequirement("xFalse", 40, 0);
            xTrue = new TestCharacteristicsRequirement("xTrue", 50, 0);
            yFalse = new TestCharacteristicsRequirement("yFalse", 40, 0);
            yTrue = new TestCharacteristicsRequirement("yTrue", 50, 0);
            zFalse = new TestCharacteristicsRequirement("zFalse", 40, 0);
            zTrue = new TestCharacteristicsRequirement("zTrue", 50, 0);

            req = (xTrue.and(xFalse)).or(yTrue.and(yFalse)).and(zTrue.and(zFalse));
            result &= (req.checkAll(testObject) == false);

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Game.start(pictureBox1);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Game.battleFieldClick(e.X, e.Y);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Game.endTurn();
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Game.actionBarClick(e.X, e.Y);
        }

        /*void testBaseRequirementClean(List<baseRequirement<TestObject>> list)
        { 
            foreach(baseRequirement<TestObject> element in list)
            {
                element.clean();
            }
        }*/
    }
}
