using System.Collections.Generic;
using System.Linq;
using static EmotionCalculator.Properties.Resources;

namespace EmotionCalculator.EmotionCalculator.Logic.Data.Songs
{
    static class RadioPack
    {
        private static readonly List<SongPack> minecraftSongs = new List<SongPack>()
        {
            new SongPack("Minecraft Song 01", "Beautiful", MCBG01, _01MCSong),
            new SongPack("Minecraft Song 02", "Beautiful", MCBG02, _02MCSong),
            new SongPack("Minecraft Song 03", "Beautiful", MCBG03, _03MCSong),
            new SongPack("Minecraft Song 04", "Beautiful", MCBG04, _04MCSong),
            new SongPack("Minecraft Song 05", "Beautiful", MCBG05, _05MCSong),
            new SongPack("Minecraft Song 06", "Beautiful", MCBG06, _06MCSong),
            new SongPack("Minecraft Song 07", "Beautiful", MCBG07, _07MCSong),
            new SongPack("Minecraft Song 08", "Beautiful", MCBG08, _08MCSong),
            new SongPack("Minecraft Song 09", "Beautiful", MCBG09, _09MCSong),
            new SongPack("Minecraft Song 10", "Beautiful", MCBG10, _10MCSong),
            new SongPack("Minecraft Song 11", "Beautiful", MCBG11, _11MCSong),
            new SongPack("Minecraft Song 12", "Beautiful", MCBG12, _12MCSong),
        };

        internal static IEnumerable<SongPack> SongPacks
        {
            get
            {
                return minecraftSongs;
            }
        }

        internal static IEnumerable<SongPack> GetPackByName(string[] name)
        {
            return SongPacks.Where(pack => name.Contains(pack.Name));
        }
    }
}
