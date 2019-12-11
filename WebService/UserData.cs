using System;
using System.Collections.Generic;

namespace WebService
{
    public partial class UserData
    {
        public int UserId { get; set; }
        public int JoyCoins { get; set; }
        public int JoyGems { get; set; }
        public short DailyStreak { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? Anger { get; set; }
        public int? Contempt { get; set; }
        public int? Disgust { get; set; }
        public int? Fear { get; set; }
        public int? Happiness { get; set; }
        public int? Neutral { get; set; }
        public int? Sadness { get; set; }
        public int? Surprise { get; set; }

        public Users User { get; set; }
    }
}
