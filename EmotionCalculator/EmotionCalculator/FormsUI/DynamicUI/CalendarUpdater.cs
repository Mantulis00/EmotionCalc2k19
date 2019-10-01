using EmotionCalculator.EmotionCalculator.Logic.Data;
using EmotionCalculator.EmotionCalculator.Tools.API.Face;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI.DynamicUI
{
    class CalendarUpdater
    {
        internal static readonly Color defaultCellColor = Color.FromArgb(100, 255, 255, 255);
        internal static readonly Color currentMonthColor = Color.FromArgb(220, 255, 255, 255);
        internal static readonly Color currentDayColor = Color.FromArgb(220, 255, 110, 110);

        private DateTime previousDate;
        private MonthEmotions monthEmotions;

        private IReadOnlyList<PictureBox> cells;
        private IReadOnlyList<Label> numbers;
        private IReadOnlyList<Label> emotionLabels;

        private DateTimePicker dateTimePicker;

        internal CalendarUpdater(DateTimePicker dateTimePicker, PictureBox backgroundBox)
        {
            this.dateTimePicker = dateTimePicker;

            cells = CalendarGenerator.GenerateCells(backgroundBox).ToList();
            numbers = CalendarGenerator.GenerateNumberLabels(cells).ToList();
            emotionLabels = CalendarGenerator.GenerateEmotionLabels(cells).ToList();

            previousDate = dateTimePicker.Value;

            dateTimePicker.ValueChanged +=
               (o, e) =>
               {
                   DateTime newDate = dateTimePicker.Value;
                   if (previousDate.Year != newDate.Year
                   || previousDate.Month != newDate.Month)
                       UpdateMonth();
                   else
                       UpdateDay();

                   previousDate = newDate;
               };

            UpdateMonth();
        }

        private void UpdateDay()
        {
            DateTime selectedDate = dateTimePicker.Value;
            DayOfWeek dayOfWeek = new DateTime(selectedDate.Year, selectedDate.Month, 1).DayOfWeek;

            //Sunday = 0
            //Monday = 1

            int cellNumber = (int)dayOfWeek;

            if (cellNumber == 0)
                cellNumber += 6;
            else
                cellNumber--;

            //Sunday = 6
            //Monday = 0

            int selectedDay = selectedDate.Day;
            int unselectedDay = previousDate.Day;

            cells[cellNumber + selectedDay - 1].BackColor = currentDayColor;
            cells[cellNumber + unselectedDay - 1].BackColor = currentMonthColor;
        }

        private void UpdateMonth()
        {
            DateTime selectedDate = dateTimePicker.Value;
            DayOfWeek dayOfWeek = new DateTime(selectedDate.Year, selectedDate.Month, 1).DayOfWeek;

            //Save month
            if (monthEmotions != null)
                MonthEmotionsIO.SaveMonth(monthEmotions);

            //Reload month
            monthEmotions = MonthEmotions.GetByDate(selectedDate.Year, (Month)selectedDate.Month);

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

            for (int i = 0; i < DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month); i++)
            {
                var cell = cells[cellNumber + i];

                if (i + 1 == selectedDate.Day)
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
                    emotionLabel.Text = string.Empty;
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

        internal void SubmitChange(int dayOfTheMonth, Emotion emotion)
        {
            monthEmotions.SetEmotion(dayOfTheMonth, emotion);
            UpdateMonth();
        }
    }
}
