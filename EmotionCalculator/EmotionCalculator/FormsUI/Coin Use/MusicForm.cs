﻿using EmotionCalculator.EmotionCalculator.Logic;
using EmotionCalculator.EmotionCalculator.Tools.Web;
using System;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.FormsUI.Coin_Use
{
    public partial class MusicForm : Form
    {
        private readonly SoundPlayer player;
        private readonly MainManager monthManager;
        private int index;

        internal MusicForm(MainManager monthManager)
        {
            this.monthManager = monthManager;
            player = new SoundPlayer();
            InitializeComponent();
            ReselectSong(0);

            FormClosing += (o, e) =>
            {
                player?.Stop();
                player?.Dispose();
            };
        }

        private void ReselectSong(int change)
        {
            player?.Stop();
            index += change;

            var songs = monthManager.ReadOnlyUserData.OwnedItems.SongPacks;

            if (index == -1)
                index = songs.Count() - 1;
            index %= songs.Count();

            var song = songs.ElementAt(index);

            musiclabel.Text = song.Name;
            BackgroundImage = song.Image.ToImage();
        }

        private void PlayButtonMusic_Click(object sender, EventArgs e)
        {
            var song = monthManager.ReadOnlyUserData.OwnedItems.SongPacks.ElementAt(index);

            song.Song.Position = 0;
            player.Stream = null;
            player.Stream = song.Song;
            player.Play();
        }

        private void PauseButtonMusic_Click(object sender, EventArgs e)
        {
            player?.Stop();
        }

        private void NextMusicButton_Click(object sender, EventArgs e)
        {
            ReselectSong(1);
        }

        private void BackMusicButton_Click(object sender, EventArgs e)
        {
            ReselectSong(-1);
        }
    }
}
