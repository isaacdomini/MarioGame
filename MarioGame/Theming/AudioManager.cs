using MarioGame.Entities;
using MarioGame.States;
using MarioGame.States.BlockStates.ActionStates;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace MarioGame.Theming
{
    
    public class AudioManager
    {
        private Song _backgroundSong;
        private Song _starSong;
        private float _volume;
        private static Dictionary<string, SoundEffect> _dictionary;
        public enum SFXEnum
        { up, breakblock, bump, coin, fireball, flagpole, gameover, jump, pipedown, powerdown, powerup, powerupappear, stomp, timewarning }

        public AudioManager(Song song, Song star)
        {
            _volume = 1.0f;
            _backgroundSong = song;
            _starSong = star;
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
            effect.CreateInstance().Play();
        }
        public void StartStarMode()
        {
            MediaPlayer.Stop();
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(_starSong);
        }
        public void StopStarMode()
        {
            MediaPlayer.Stop();
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(_backgroundSong);

        }
        public void SFXPlayer(IState state, IState prevState)
        {
            if(state is JumpingMarioState)
            {
                playEffect(GlobalConstants.SFXFiles[SFXEnum.jump.GetHashCode()]);
            }
            else if (state is DeadState)
            {
                playEffect(GlobalConstants.SFXFiles[SFXEnum.powerdown.GetHashCode()]);
            }
            else if(state is BumpingState)
            {
                playEffect(GlobalConstants.SFXFiles[SFXEnum.bump.GetHashCode()]);
            }else if(state is SuperState)
            {

            }
        }
    }
}
