using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using TestGameLogic.units;

namespace TestGameLogic.main.Grafic
{
    public class Battlefield : baseGrafic
    {
        private const int FIELD_SIZE = 50; //pixel

        private int widthInFields = -1;
        private int heightInFields = -1;

        private List<Player> players = null;

        public Battlefield(PictureBox pictureBox,int widthInFields, int heightInFields)
            : base(pictureBox)
        {
            int widthFull = widthInFields*FIELD_SIZE;
            int heightFull = heightInFields*FIELD_SIZE;
            
            setPicturebox(widthFull,heightFull);

            this.widthInFields = widthInFields;
            this.heightInFields = heightInFields;

            //clear();
        }

        public void setPlayers(List<Player> players)
        {
            this.players = players;
            //set initial positions
            int leftUnitCount = players[0].Units.Count;
            int divHeight = heightInFields / (leftUnitCount + 1);
            for (int n = 0; n < leftUnitCount; n++)
            {
                players[0].Units[n].Position = widthInFields * (divHeight* (n+1)) + 0;
            }

            int rightUnitCount = players[1].Units.Count;
            divHeight = heightInFields / (rightUnitCount + 1);
            for (int n = 0; n < rightUnitCount; n++)
            {
                players[1].Units[n].Position = widthInFields * (divHeight * (n + 1)) + widthInFields - 1;
            }
        }

        public void reDraw()
        {
            clear();
            //draw units
            foreach(Player player in players)
            {
                foreach (baseUnit unit in player.Units)
                { 
                    int x = unit.Position%widthInFields;
                    int y = unit.Position / widthInFields;

                    // draw unit
                    gr.DrawRectangle(penStandart, new Rectangle(x * FIELD_SIZE + 2, y * FIELD_SIZE + 2, FIELD_SIZE - 4, FIELD_SIZE - 4));
                    gr.DrawString(unit.GetType().Name.ToString(), Button.DefaultFont, Brushes.Black, x * FIELD_SIZE + FIELD_SIZE / 10, y * FIELD_SIZE + FIELD_SIZE / 4);
                
                    // draw Target
                    if (unit.Target != -1)
                    {
                        int x1 = unit.Target % widthInFields;
                        int y1 = unit.Target / widthInFields;
                        gr.DrawEllipse(penTarget, new Rectangle(x1 * FIELD_SIZE, y1 * FIELD_SIZE, FIELD_SIZE, FIELD_SIZE));
                        gr.DrawLine(penTarget, x1 * FIELD_SIZE + FIELD_SIZE / 2, y1 * FIELD_SIZE + FIELD_SIZE / 2, x * FIELD_SIZE + FIELD_SIZE / 2, y * FIELD_SIZE + FIELD_SIZE / 2);
                    }
                }

                // draw selected
                if (player.SelectedUnit != null)
                {
                    int x = player.SelectedUnit.Position % widthInFields;
                    int y = player.SelectedUnit.Position / widthInFields;

                    gr.DrawRectangle(penSelected, new Rectangle(x * FIELD_SIZE, y * FIELD_SIZE, FIELD_SIZE, FIELD_SIZE));
                }
            }


        }

        public int calculatePosition(int _x, int _y)
        {
            int x = _x / FIELD_SIZE;
            int y = _y / FIELD_SIZE;

            int position = y * widthInFields + x;
            return position;
        }
    }
}
