using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI.DynamicUI
{
    class CalendarGenerator
    {
        private static readonly int rowLength = 7;
        private static readonly int numberOfRows = 6;

        private static readonly int buttonSize = 40;

        private DateTimePicker dateTimePicker;
        private PictureBox cellBackgroundBox;

        private static readonly Color defaultCellColor = Color.FromArgb(120, 255, 255, 255);
        private static readonly Color currentMonthColor = Color.FromArgb(220, 255, 255, 255);
        private static readonly Color currentDayColor = Color.FromArgb(220, 255, 100, 100);

        private List<PictureBox> cells = new List<PictureBox>();
        internal IReadOnlyList<PictureBox> Cells { get { return cells.AsReadOnly(); } }

        internal CalendarGenerator(DateTimePicker dateTimePicker, PictureBox pictureBox)
        {
            this.dateTimePicker = dateTimePicker;
            cellBackgroundBox = pictureBox;

            GenerateCells();

            dateTimePicker.ValueChanged += new EventHandler(SelectCurrentMonth);

            SelectCurrentMonth(this, null);
        }

        private void GenerateCells()
        {
            Size backgroundSize = cellBackgroundBox.Size;

            int horizontalGap = (backgroundSize.Width - (buttonSize * rowLength)) / (rowLength + 1);
            int verticalGap = (backgroundSize.Height - (buttonSize * numberOfRows)) / (numberOfRows + 1);

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    PictureBox cell = new PictureBox();

                    cell.Location = new Point(
                            horizontalGap + j * (buttonSize + horizontalGap),
                            verticalGap + i * (buttonSize + verticalGap));

                    cell.Size = new Size(buttonSize, buttonSize);
                    cell.BackColor = defaultCellColor;

                    cellBackgroundBox.Controls.Add(cell);
                    cell.BringToFront();

                    cell.Enabled = true;

                    cells.Add(cell);
                }
            }
        }

        private void SelectCurrentMonth(object sender, object e)
        {
            ResetColors();

            DateTime selectedDate = dateTimePicker.Value;

            DayOfWeek dayOfWeek = new DateTime(selectedDate.Year, selectedDate.Month, 1).DayOfWeek;

            //Sunday = 0
            //Monday = 1

            int cellNumber = (int)dayOfWeek;

            if (cellNumber == 0)
                cellNumber += 6;
            else
                cellNumber--;

            for (int i = 0; i < DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month); i++)
            {
                var cell = Cells[cellNumber + i];

                if (i + 1 != selectedDate.Day)
                {
                    cell.BackColor = currentMonthColor;
                }
                else
                {
                    cell.BackColor = currentDayColor;
                }
            }
        }

        private void ResetColors()
        {
            foreach (var cell in cells)
            {
                cell.BackColor = defaultCellColor;
            }
        }
    }
}
