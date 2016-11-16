using MarioGame.Core;
using MarioGame.Entities;
using MarioGame.States;
using MarioGame.States.BlockStates.ActionStates;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MarioGame.Theming
{
    
    public class AudioManager :ISubscriber
    {
        private Song _backgroundSong;
        private Song _starSong;
        private static bool _mute;
        private static Dictionary<string, SoundEffect> _dictionary;
        public enum SFXEnum
        { up, breakblock, bump, coin, fireball, flagpole, gameover, jump, pipedown, powerdown, powerup, powerupappear, stomp, timewarning }

        private Script _script;
        public AudioManager(Song song, Song star, Script script)
        {
            _mute = false;
            _backgroundSong = song;
            _starSong = star;
            _dictionary = new Dictionary<string, SoundEffect>();
            MediaPlayer.Play(_backgroundSong);

            _script = script;
            Enum.GetValues(typeof(EventTypes)).Cast<EventTypes>().ToList().ForEach(e => script.Subscribe(e, this));
            //EventTypes.Get   _script.Subscribe();
        }
        public void AddSFX(string effect, SoundEffect sfx)
        {
            _dictionary.Add(effect, sfx);
        }
        public void playEffect(string key)
        {
            if (!_mute)
            {
                SoundEffect effect;
                _dictionary.TryGetValue(key, out effect);
                effect.CreateInstance().Play();
            }
        }
        public void StartStarSong()
        {
                MediaPlayer.Stop();
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(_starSong);
            
        }
        public void StopStarSong()
        {
                MediaPlayer.Stop();
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(_backgroundSong);
            

        }
        public void SFXPlayer(IState state, IState prevState)
        {
                if (state is JumpingMarioState)
                {
                    playEffect(GlobalConstants.SFXFiles[SFXEnum.jump.GetHashCode()]);
                }
                else if (state is DeadState)
                {
                    playEffect(GlobalConstants.SFXFiles[SFXEnum.powerdown.GetHashCode()]);
                }
                else if (state is BumpingState)
                {
                    playEffect(GlobalConstants.SFXFiles[SFXEnum.bump.GetHashCode()]);
                }
                else if (state is SuperState)
                {

                }
        }

        public void Mute()
        {
            _mute = !_mute;
            MediaPlayer.Volume = _mute ? 0.0f : 1.0f;
            
        }

        public void OnEvent(EventTypes eventType)
        {
            switch (eventType)
            {
                case EventTypes.BeginStarState:
                    StartStarSong();
                    break;
                case EventTypes.EndStarState:
                    StopStarSong();
                    break;
                case EventTypes.Gameover:
                case EventTypes.Levelclear:
                    MediaPlayer.Stop();
                    playEffect(eventType.ToString().ToLowerInvariant());
                    break;
                default:
                    playEffect(eventType.ToString().ToLowerInvariant());
                    break;
            }
        }
    }
}
