using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace MarioGame.Theming
{
    public class AudioManager
    {
        private Song _backgroundSong;
        private float _volume;
        private static Dictionary<string, SoundEffect> _dictionary;
        public AudioManager(Song song)
        {
            _volume = 1.0f;
            _backgroundSong = song;
            _dictionary = new Dictionary<string, SoundEffect>();
            MediaPlayer.Play(_backgroundSong);
        }
        public void AddSFX(string effect, SoundEffect sfx)
        {
            _dictionary.Add(effect, sfx);
        }
        public void playEffect(string key)
        {
            SoundEffect effect;
            _dictionary.TryGetValue(key, out effect);
            effect.Play(_volume, 0.0f, 0.0f);
        }
        public void StartStarMode()
        {

        }
    }
}
