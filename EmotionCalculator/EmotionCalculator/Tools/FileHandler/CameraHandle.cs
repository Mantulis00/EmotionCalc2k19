using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.Tools.FileHandler
{
    class CameraHandle
    {
        private VideoCaptureDevice camera;
        private FilterInfoCollection cameraHW;
        private PictureBox pic;

        public bool cameraRunning { get; set; }

        public CameraHandle(PictureBox pic)
        {
            cameraHW = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            camera = new VideoCaptureDevice(cameraHW[0].MonikerString);
            camera.NewFrame += new NewFrameEventHandler(NewFrame);


            this.pic = pic;
            cameraRunning = false;
        }

        public void Start()
        {
            if (!cameraRunning)
            {
                camera.Start();
                cameraRunning = true;
            }
            else
            {
                //
            }

        }

        private void NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pic.Image = (Image)eventArgs.Frame.Clone();
        }


        public void Stop()
        {
            if (cameraRunning)
            {
                camera.Stop();
                cameraRunning = false;

                pic.Image = null;
            }
            else
            {
                //
            }

        }

    }
}
