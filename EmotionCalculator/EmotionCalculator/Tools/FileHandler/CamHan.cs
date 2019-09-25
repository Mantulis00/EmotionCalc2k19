using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using AForge;
using AForge.Video.DirectShow;
using AForge.Video;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.Tools.FileHandler
{
    class CamHan
    {

        private VideoCaptureDevice camera;
        private FilterInfoCollection cameraHW;
        private PictureBox pic ;

        public bool cameraIsRoling { get; set; }

        public CamHan(PictureBox pic)
        {
            cameraHW = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            camera = new VideoCaptureDevice(cameraHW[0].MonikerString);
            camera.NewFrame += new NewFrameEventHandler(NewFrame);


            this.pic = pic;
            cameraIsRoling = false;
        }

       public void Start()
        {
            if (!cameraIsRoling)
            {
                camera.Start();
                cameraIsRoling = true;
            }
            else
            {
                //
            }

        }

        private void NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                pic.Image = (Image)eventArgs.Frame.Clone();
            }
            catch (Exception e)
            {

            }
        }


        public void Stop()
        {
            if (cameraIsRoling)
            {
                camera.Stop();
                cameraIsRoling = false;
            }
            else
            {
                //
            }
                
        }

    }
}
