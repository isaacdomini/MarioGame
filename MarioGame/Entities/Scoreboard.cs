using MarioGame.Core;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Theming;
using MarioGame.Theming.Scenes;

namespace MarioGame.Entities
{
    public class Scoreboard
    {
        private static readonly Dictionary<string, int> _scoreboard = new Dictionary<string, int>();
        public bool HasLives => _scoreboard["Lives"] > 0;
        public Scoreboard() : base()
        {
            InitializeScoreboardList();
        }

        private static int warningTime = 30;
        private static int startTime = 100;
        private bool _timeWarningCalled = false;
        public bool timeWarningCalled { get { return _timeWarningCalled; } set { _timeWarningCalled = value; } }

        public void InitializeScoreboardList()
        {
            if (!_scoreboard.ContainsKey("Player"))
                _scoreboard.Add("Player", 1);
            else
                _scoreboard["Player"] = 1;
            if (!_scoreboard.ContainsKey("Lives"))
            {
                ResetScoreboard();
            }
            else
            {
                if (_scoreboard["Lives"] == 0)
                {
               //     //Stage.game1.Reset();
               //     Mario.GoToGameOver();
                    ResetScoreboard();
                }
                _scoreboard["Points"] = 0;
                _scoreboard["Time"] = startTime;
                _scoreboard["Coins"] = 0;
            }
            
            
        }
        public void ResetScoreboard()
        {
            if (!_scoreboard.ContainsKey("Coins"))
                _scoreboard.Add("Coins", 0);
            else
                _scoreboard["Coins"] = 0;
            if (!_scoreboard.ContainsKey("Points"))
                _scoreboard.Add("Points", 0);
            else
                _scoreboard["Points"] = 0;
            if (!_scoreboard.ContainsKey("Lives"))
                _scoreboard.Add("Lives", GlobalConstants.MaxLives);
            else if (_scoreboard["Lives"] == 0)
                _scoreboard["Lives"] = GlobalConstants.MaxLives;
            if (!_scoreboard.ContainsKey("Time"))
                _scoreboard.Add("Time", startTime);
            else
                _scoreboard["Time"] = startTime;
        }

        internal void AddLife()
        {
            _scoreboard["Lives"]++;
        }

        public void DrawScoreboard(SpriteBatch batch)
        {
            var scoreLocation = new Vector2(5, 5);
            var spacing = new Vector2(150, 0);
            batch.Begin();
            foreach (var pair in _scoreboard)
            {
                batch.DrawString(Game1.Font, pair.Key + ": " + pair.Value, scoreLocation, Color.White);
                scoreLocation = scoreLocation + spacing;
            }
            batch.End();
        }

        public double TimeTrack { get; set; } = 0;

        public void UpdateTimer(int elapsedMilliseconds)
        {
            if (_scoreboard["Time"] == 0)
            {
                LoseLife();
            }
            else
            {
                TimeTrack = TimeTrack + elapsedMilliseconds * .001;
                if (TimeTrack >= 1.0)
                {
                    _scoreboard["Time"]--;
                    TimeTrack = 0;
                }
            }
            if (_scoreboard["Time"] < warningTime && !timeWarningCalled)
            {
                timeWarningCalled = true;
                Entity.Script.Announce(EventTypes.Timewarning);
            }
        }
        public void CheckCoinsForLife()
        {
            if (_scoreboard["Coins"] != 0 && _scoreboard["Coins"] % 100 == 0)
            {
                _scoreboard["Lives"]++;
                _scoreboard["Coins"] = 0;
            }
        }
        public void AddCoin()
        {
            _scoreboard["Coins"]++;
            _scoreboard["Points"] += 200;
            CheckCoinsForLife();
        }
        public void AddPoint(int point)
        {
            _scoreboard["Points"] += point;
        }
        public void LoseLife()
        {
            _scoreboard["Lives"]--;
            if (!HasLives)
            {
                //Stage.game1.Reset();
                Mario.GoToGameOver();
            }
            else
            {
                ResetScoreboard();
            }
        }

        //Call this when mario hits the flagpole
        public void FinishMultiplier()
        {
            int time = _scoreboard["Time"];
            int multiplier = (time / 100 + time%100)%10;
            _scoreboard["Points"] += time * multiplier;
        }
    }
}
