using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmotionCalculator.MiniGames.SpaceInvaders
{
     class AnimationManager
    {
        internal List<PictureBox> AnimationElements { get; }
        List<Point> Distances;
        List<Point> presetLocations;


        System.Windows.Forms.Timer Clock;
        public  AnimationManager(PictureBox grapX, System.Windows.Forms.Timer Clock)
        {

             presetLocations = new List<Point>();

            int InvadersStartX = 10;
            int InvadersStartY = 10;

            int InvaderSize = 20;
            int InvadersSpacer = 2 * InvaderSize;

            presetLocations = SetupPresetLocations( InvadersStartX, InvadersStartY, InvadersSpacer);
            AnimationElements = SetAnimationElements(grapX);
            Distances = SetDistances(presetLocations, AnimationElements);


            this.Clock = Clock;
        }

        
        public  void StartAnimation(SpaceInvadersMain mainer)
        {
            int counter = 0;
                for (int y = 0; y < AnimationElements.Count; y++)
                {
                

                    if (presetLocations[y].X != 0 &&
                        presetLocations[y].X + 4 > AnimationElements[y].Location.X &&
                        presetLocations[y].X - 4 < AnimationElements[y].Location.X)
                    {
                    
                        presetLocations[y] = new Point(0, presetLocations[y].Y);
                     }

                     else if (presetLocations[y].X > AnimationElements[y].Location.X && presetLocations[y].X != 0)
                    {
                         AnimationElements[y].Left += 2;
                    }

                     else if (presetLocations[y].X  < AnimationElements[y].Location.X && presetLocations[y].X != 0)
                     {
                          AnimationElements[y].Left -= 2;
                     }
                

                     if (presetLocations[y].Y != 0 &&
                        presetLocations[y].Y + 4 > AnimationElements[y].Location.Y &&
                        presetLocations[y].Y - 4 < AnimationElements[y].Location.Y)
                    {
                         presetLocations[y] = new Point(presetLocations[y].X, 0);
                     }

                     else if (presetLocations[y].Y > AnimationElements[y].Location.Y && presetLocations[y].Y != 0)
                    {
                         AnimationElements[y].Top += 2;
                    }

                     else if (presetLocations[y].Y < AnimationElements[y].Location.Y && presetLocations[y].Y != 0)
                    {
                         AnimationElements[y].Top -= 2;
                    }

                     if (presetLocations[y].X == 0 && presetLocations[y].Y == 0)
                    {
                         counter++;
                    }
                     else
                         counter = 0;

                    if (counter + 1 == AnimationElements.Count)
                     {
                         Clock.Stop();
                         mainer.StartTimer();
                     }

            }
            
        }

        private  List<Point> SetDistances(List<Point> presetLocations, List<PictureBox> AnimationElements)
        {
            List<Point> Distances = new List<Point>();

            for (int x=0; x<AnimationElements.Count; x++)
            {
                Point distance = new Point();

                distance.X = presetLocations[x].X - AnimationElements[x].Location.X;
                distance.Y = presetLocations[x].Y - AnimationElements[x].Location.Y;

                Distances.Add(distance);
            }


            return Distances;
        }



        private  List<PictureBox> SetAnimationElements(PictureBox grapX)
        {
            List<PictureBox> AnimationElements = new List<PictureBox>();

            for (int x = 0; x < 42; x++)
            {
                PictureBox Element = new PictureBox();

                Element.Location = grapX.Controls[x].Location;
                Element.Size = new Size (
                    grapX.Controls[x].Size.Width/2,
                    grapX.Controls[x].Size.Height/2);

                Element.Left += grapX.Controls[x].Size.Width / 4;
                Element.Top += grapX.Controls[x].Size.Height / 4;

                for (int y=0; y< grapX.Controls[x].Controls.Count; y++)
                {
                    if (grapX.Controls[x].Controls[y] is PictureBox)
                    {
                        Element.Image = ((PictureBox)grapX.Controls[x].Controls[y]).Image;
                    }
                }
                Element.SizeMode = PictureBoxSizeMode.StretchImage;
                Element.Visible = true;
                Element.BackColor = Color.Transparent;
                Element.BringToFront();
                if (Element.Image != null)
                {
                    grapX.Controls.Add(Element);

                    AnimationElements.Add(Element);
                }

            }

            return AnimationElements;
        }

        private  List<Point> SetupPresetLocations(
            int InvadersStartX, int InvadersStartY,
            int InvadersSpacer
            )
            {
            List<Point> presetLocations = new List<Point>();
            Point invader;
            int xLocation = InvadersStartX;
                for (int y = 0; y < 5; y++)
                 {
                     for (int x= 0; x < 8; x++)
                      {
                         invader = new Point();
                        invader.X = InvadersStartX;
                        invader.Y = InvadersStartY;
                        presetLocations.Add(invader);

                        InvadersStartX += InvadersSpacer;
                      }
                     InvadersStartX = xLocation;
                     InvadersStartY += InvadersSpacer;
                 }
            InvadersStartX = xLocation;
            InvadersStartX += InvadersSpacer * 3;
            for (int x=0; x<2; x++)
            {
                invader = new Point();
                invader.X = InvadersStartX;
                invader.Y = InvadersStartY;
                presetLocations.Add(invader);

                InvadersStartX += InvadersSpacer;
            }

            return presetLocations;
        }



    }

}
