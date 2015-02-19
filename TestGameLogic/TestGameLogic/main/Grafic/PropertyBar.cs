using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using TestGameLogic.units;
using TestGameLogic.skills;
using TestGameLogic.property;

namespace TestGameLogic.main.Grafic
{
    public class PropertyBar : baseGrafic
    {
        private const int PROPERTY_SIZE = 20;// + 5*2; //pixel
        //private const int MARGIN_SIZE = 5;// + 5*2; //pixel

        //private int maxActions = -1;

        private baseUnit selectedUnit = null;

        public PropertyBar(PictureBox pictureBox, int width, int height)
            : base(pictureBox)
        {

            setPicturebox(width, height);
        }

        public void reDraw()
        {
            int index = 0;
            clear();
            //draw properties
            if (selectedUnit != null)
            {
                foreach (baseProperty property in selectedUnit.Properties)
                {
                    // draw unit
                    //gr.DrawRectangle(penStandart, new Rectangle(MARGIN_SIZE*2 + index * (ACTION_SIZE + MARGIN_SIZE) + 2, MARGIN_SIZE + 2, ACTION_SIZE - 4, ACTION_SIZE - 4));

                    gr.DrawString(property.Name, Button.DefaultFont, Brushes.Black,
                                                        10,
                                                        5 + index*PROPERTY_SIZE);
                    gr.DrawString(property.ValueAsString, Button.DefaultFont, Brushes.Black,
                                                        110,
                                                        5 + index * PROPERTY_SIZE);
                    
                    index++;
                }

            }
        }

        public void selectUnit(baseUnit selectedUnit)
        {
            this.selectedUnit = selectedUnit;
        }
    }
}
