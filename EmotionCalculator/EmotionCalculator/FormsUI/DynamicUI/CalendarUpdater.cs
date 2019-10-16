using EmotionCalculator.EmotionCalculator.Logic.Data;
using EmotionCalculator.EmotionCalculator.Logic.Settings;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI.DynamicUI
{
    class CalendarUpdater : IMonthUpdatable
    {
        internal static readonly Color defaultCellColor = Color.FromArgb(60, 255, 255, 255);
        internal static readonly Color currentMonthColor = Color.FromArgb(180, 255, 255, 255);
        internal static readonly Color currentDayColor = Color.FromArgb(220, 255, 110, 110);

        private IReadOnlyList<PictureBox> cells;
        private IReadOnlyList<Label> numbers;
        private IReadOnlyList<Label> emotionLabels;

        private PictureBox backgroundBox;
        private SettingsManager settingsManager;

        internal CalendarUpdater(PictureBox backgroundBox, SettingsManager settingsManager)
        {
            this.backgroundBox = backgroundBox;
            this.settingsManager = settingsManager;

            cells = CalendarGenerator.GenerateCells(backgroundBox).ToList();
            numbers = CalendarGenerator.GenerateNumberLabels(cells).ToList();
            emotionLabels = CalendarGenerator.GenerateEmotionLabels(cells).ToList();
        }

        public void Update(MonthEmotions monthEmotions, DateTime newDateTime)
        {
            backgroundBox.Image = settingsManager.SelectedTheme.Image;

            DayOfWeek dayOfWeek = new DateTime(newDateTime.Year, newDateTime.Month, 1).DayOfWeek;

            ResetColors();

            //Sunday = 0
            //Monday = 1

            int cellNumber = (int)dayOfWeek;

            if (cellNumber == 0)
                cellNumber += 6;
            else
                cellNumber--;

            //Sunday = 6
            //Monday = 0

            for (int i = 0; i < DateTime.DaysInMonth(newDateTime.Year, newDateTime.Month); i++)
            {
                var cell = cells[cellNumber + i];

                if (i + 1 == newDateTime.Day)
                {
                    cell.BackColor = currentDayColor;
                }
                else
                {
                    cell.BackColor = currentMonthColor;
                }

                var number = numbers[cellNumber + i];

                number.Text = (i + 1).ToString();
                number.Visible = true;

                var emotionLabel = emotionLabels[cellNumber + i];

                if (monthEmotions[i + 1] == Emotion.NotSet)
                {
                    emotionLabel.Text = string.Empty;
                }
                else
                {
                    emotionLabel.Text = monthEmotions[i + 1].ToString();
                }

                emotionLabel.Visible = true;
            }
        }

        private void ResetColors()
        {
            foreach (var cell in cells)
            {
                cell.BackColor = defaultCellColor;
            }

            foreach (var number in numbers)
            {
                number.Text = string.Empty;
                number.Visible = false;
            }

            foreach (var emotionLabel in emotionLabels)
            {
                emotionLabel.Text = string.Empty;
                emotionLabel.Visible = false;
            }
        }
    }
}
