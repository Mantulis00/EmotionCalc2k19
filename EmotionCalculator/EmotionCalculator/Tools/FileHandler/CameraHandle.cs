using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.Tools.FileHandler
{
    class CameraHandle
    {
        private readonly VideoCaptureDevice camera;
        private readonly FilterInfoCollection cameraHW;
        private readonly PictureBox pic;

        public bool CameraRunning { get; set; }

        public CameraHandle(PictureBox pic)
        {
            cameraHW = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            camera = new VideoCaptureDevice(cameraHW[0].MonikerString);
            camera.NewFrame += new NewFrameEventHandler(NewFrame);


            this.pic = pic;
            CameraRunning = false;
        }

        public void Start()
        {
            if (!CameraRunning)
            {
                camera.Start();
                CameraRunning = true;
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
            if (CameraRunning)
            {
                camera.Stop();
                CameraRunning = false;

                pic.Image = null;
            }
            else
            {
                //
            }

        }

    }
}
