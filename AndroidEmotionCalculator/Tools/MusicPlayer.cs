using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;
using EmotionCalculator.EmotionCalculator.Logic;

namespace AndroidEmotionCalculator.Tools
{
    class MusicPlayer
    {

        protected MediaPlayer player;
        private readonly MainManager monthManager;
        public int index;
        public MusicPlayer(MainManager monthManager)
        {
            this.monthManager = monthManager;
        }
        public void StartPlayer()
        {
            var song = monthManager.ReadOnlyUserData.OwnedItems.SongPacks.ElementAt(index);
            song.Song.Position = 0;
           
                player = new MediaPlayer();
                player.SetDataSource("1.wav");
                player.Start();
           
        }
        public void PausePlayer()
        {
            player.Pause();
        }
        private void ReselectSong(int change)
        {
            index += change;

            var songs = monthManager.ReadOnlyUserData.OwnedItems.SongPacks;

            if (index == -1)
                index = songs.Count() - 1;
            index %= songs.Count();
         


        }

        public void NextMusic()
        {
            ReselectSong(1);
        }

        public void BackMusic()
        {
            ReselectSong(-1);
        }
    }
}