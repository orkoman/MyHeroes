using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using TestGameLogic.units;

namespace TestGameLogic
{
    public class Battlefield
    {
        Bitmap bmp = null;
        Graphics gr = null;

        private const int FIELD_SIZE = 50; //pixel

        private int widthInFields = -1;
        private int height = -1;

        private int widthFull = -1;
        private int heightFull = -1;

        private PictureBox pictureBox = null;

        private List<Player> players = null;

        private Pen penStandart = new Pen(Brushes.Black);
        private Pen penSelected = new Pen(Brushes.Green);
        private Pen penTarget = new Pen(Brushes.Red);

        /*public int WidthInFields
        {
            get { return widthInFields; }
        }*/

        public Battlefield(PictureBox pictureBox,int width, int height)
        {
            this.widthFull = width*FIELD_SIZE;
            this.heightFull = height*FIELD_SIZE;
            this.pictureBox = pictureBox;
            this.pictureBox.Width = this.widthFull;
            this.pictureBox.Height = this.heightFull;


            this.bmp = new Bitmap(this.widthFull, this.heightFull);
            this.gr = Graphics.FromImage(this.bmp);
            this.widthInFields = width;
            this.height = height;

            clear();
        }

        public void setPlayers(List<Player> players)
        {
            this.players = players;
            //set initial positions
            int leftUnitCount = players[0].Units.Count;
            int divHeight = height / (leftUnitCount + 1);
            for (int n = 0; n < leftUnitCount; n++)
            {
                players[0].Units[n].Position = widthInFields * (divHeight* (n+1)) + 0;
            }

            int rightUnitCount = players[1].Units.Count;
            divHeight = height / (rightUnitCount + 1);
            for (int n = 0; n < rightUnitCount; n++)
            {
                players[1].Units[n].Position = widthInFields * (divHeight * (n + 1)) + widthInFields - 1;
            }
        }

        public void clear()
        {
            this.gr.FillRectangle(Brushes.White, new Rectangle(0, 0, this.widthFull, this.heightFull));
            this.pictureBox.Image = bmp;
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
                    gr.DrawString(unit.GetType().Name.ToString(), Button.DefaultFont, Brushes.Black, x * FIELD_SIZE + FIELD_SIZE / 4, y * FIELD_SIZE + FIELD_SIZE / 4);
                
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

        /*public void onClick()
        { 
            //TODO OLEG set units
        }*/
    }
}
