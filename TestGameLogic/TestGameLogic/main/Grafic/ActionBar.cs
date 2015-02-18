﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using TestGameLogic.units;
using TestGameLogic.skills;

namespace TestGameLogic.main.Grafic
{
    public class ActionBar : baseGrafic
    {
        private const int ACTION_SIZE = 50;// + 5*2; //pixel
        private const int MARGIN_SIZE = 5;// + 5*2; //pixel

        private int maxActions = -1;

        private baseUnit selectedUnit = null;

        public ActionBar(PictureBox pictureBox, int maxActions)
            : base(pictureBox)
        {
            int widthFull = maxActions * (ACTION_SIZE + MARGIN_SIZE*2);
            int heightFull = ACTION_SIZE + MARGIN_SIZE*2;

            setPicturebox(widthFull, heightFull);

            this.maxActions = maxActions;
        }

        public void reDraw()
        {
            int index = 0;
            clear();
            //draw actions
            if (selectedUnit != null)
            {
                foreach (baseActiveSkill activeSkill in selectedUnit.getActiveSkills())
                {
                    // draw unit
                    gr.DrawRectangle(penStandart, new Rectangle(MARGIN_SIZE*2 + index * (ACTION_SIZE + MARGIN_SIZE) + 2, MARGIN_SIZE + 2, ACTION_SIZE - 4, ACTION_SIZE - 4));

                    gr.DrawString(activeSkill.GetType().Name.ToString(), Button.DefaultFont, Brushes.Black,
                                                        MARGIN_SIZE * 2 + index * (ACTION_SIZE + MARGIN_SIZE) + ACTION_SIZE / 10,
                                                        5 + ACTION_SIZE / 4);
                    index++;
                }
            }
        }

        public void selectUnit(baseUnit selectedUnit)
        {
            this.selectedUnit = selectedUnit;
        }

        public int calculatePosition(int x, int y)
        {
            if (y >= MARGIN_SIZE && 
                y < ACTION_SIZE + MARGIN_SIZE)
            {
                int position = (x - MARGIN_SIZE * 2) / (ACTION_SIZE + MARGIN_SIZE);
                return position;
            }

            return -1;
        }
    }
}
