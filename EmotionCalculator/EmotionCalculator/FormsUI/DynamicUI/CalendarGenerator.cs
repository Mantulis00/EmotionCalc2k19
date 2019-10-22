using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI.DynamicUI
{
    static class CalendarGenerator
    {
        private static readonly int rowLength = 7;
        private static readonly int numberOfRows = 6;

        private static readonly int cellSize = 40;

        internal static IEnumerable<PictureBox> GenerateCells(PictureBox pictureBox, Color defaultCellColor)
        {
            Size backgroundSize = pictureBox.Size;

            int horizontalGap = (backgroundSize.Width - (cellSize * rowLength)) / (rowLength + 1);
            int verticalGap = (backgroundSize.Height - (cellSize * numberOfRows)) / (numberOfRows + 1);

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    PictureBox cell = new PictureBox();

                    cell.Location = new Point(
                            horizontalGap + j * (cellSize + horizontalGap),
                            verticalGap + i * (cellSize + verticalGap));

                    cell.Size = new Size(cellSize, cellSize);
                    cell.BackColor = defaultCellColor;

                    pictureBox.Controls.Add(cell);
                    cell.BringToFront();
                    yield return cell;
                }
            }
        }

        internal static IEnumerable<PictureBox> GenerateEmojis(IEnumerable<PictureBox> cells, PictureBox pictureBox)
        {
            foreach (var cell in cells)
            {
                PictureBox emoji = new PictureBox();

                emoji.BackColor = Color.Transparent;
               // emoji.Image = ;
                emoji.Location  = new Point(cellSize/4, cellSize/3 );
                emoji.Size = new Size(cellSize/2, cellSize/2);
                emoji.SizeMode = PictureBoxSizeMode.StretchImage;

                cell.Controls.Add(emoji);
                cell.BringToFront();
                

                 yield return emoji;
            }
        }


        internal static IEnumerable<Label> GenerateNumberLabels(IEnumerable<PictureBox> cells)
        {
            foreach (var cell in cells)
            {
                Label number = new Label();
                number.BackColor = Color.Transparent;

                cell.Controls.Add(number);
                number.BringToFront();
                yield return number;
            }
        }

        internal static IEnumerable<Label> GenerateEmotionLabels(IEnumerable<PictureBox> cells)
        {
            foreach (var cell in cells)
            {
                Label emotionLabel = new Label();
                emotionLabel.BackColor = Color.Transparent;
                emotionLabel.Location = new Point(0, cellSize / 2);
                emotionLabel.Text = "blank";

                cell.Controls.Add(emotionLabel);
                emotionLabel.BringToFront();
                yield return emotionLabel;
            }
        }
    }
}
