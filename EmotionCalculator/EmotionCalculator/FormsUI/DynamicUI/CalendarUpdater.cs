using EmotionCalculator.EmotionCalculator.Logic.Data;
using EmotionCalculator.EmotionCalculator.Logic.Settings;
using EmotionCalculator.EmotionCalculator.Tools.API.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI.DynamicUI
{
    class CalendarUpdater : IMonthUpdatable
    {
        private IReadOnlyList<PictureBox> cells;
        private IReadOnlyList<Label> numbers;
        private IReadOnlyList<Label> emotionLabels;

        private PictureBox backgroundBox;
        private SettingsManager settingsManager;

        internal CalendarUpdater(PictureBox backgroundBox, SettingsManager settingsManager)
        {
            this.backgroundBox = backgroundBox;
            this.settingsManager = settingsManager;

            cells = CalendarGenerator.GenerateCells(backgroundBox, settingsManager.SelectedTheme.SecondaryColor).ToList();
            numbers = CalendarGenerator.GenerateNumberLabels(cells).ToList();
            emotionLabels = CalendarGenerator.GenerateEmotionLabels(cells).ToList();
        }

        public void Update(MonthEmotions monthEmotions, DateTime newDateTime)
        {
            ThemePack selectedTheme = settingsManager.SelectedTheme;

            backgroundBox.Image = selectedTheme.Image;

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
                    cell.BackColor = selectedTheme.FocusColor;
                }
                else
                {
                    cell.BackColor = selectedTheme.PrimaryColor;
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
                cell.BackColor = settingsManager.SelectedTheme.SecondaryColor;
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
