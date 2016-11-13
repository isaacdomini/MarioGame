using MarioGame.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Entities
{
    public class Scoreboard
    {
        private static readonly Dictionary<string, int> _scoreboard = new Dictionary<string, int>();
        public Scoreboard() : base()
        {
            InitializeScoreboardList();
        }
        public void InitializeScoreboardList()
        {
            if (!_scoreboard.ContainsKey("Mario"))
                _scoreboard.Add("Mario", 1);
            else
                _scoreboard["Mario"] = 1;
            if (!_scoreboard.ContainsKey("Lives"))
            {
                ResetScoreboard();
            }
            else
            {
                if (_scoreboard["Lives"] == 0)
                {
                    //Stage.game1.Reset();
                    ResetScoreboard();
                }
                _scoreboard["Points"] = 0;
                _scoreboard["Time"] = 400;
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
                _scoreboard.Add("Lives", 3);
            else
                _scoreboard["Lives"] = 3;
            if (!_scoreboard.ContainsKey("Time"))
                _scoreboard.Add("Time", 400);
            else
                _scoreboard["Time"] = 400;
        }

        internal void AddLife()
        {
            _scoreboard["Lives"]++;
        }

        public void drawScoreboard(SpriteBatch batch)
        {
            var scoreLocation = new Vector2(5, 5);
            var spacing = new Vector2(150, 0);
            batch.Begin();
            foreach (var pair in _scoreboard)
            {
                batch.DrawString(Game1.Font, pair.Key + ": " + pair.Value, scoreLocation, Color.Black);
                scoreLocation = scoreLocation + spacing;
            }
            batch.End();
        }
        public double timeTrack = 0;
        public void UpdateTimer(int elapsedMilliseconds)
        {
            if (_scoreboard["Time"] == 0)
            {
                LoseLife();
            }
            else
            {
                timeTrack = timeTrack + elapsedMilliseconds * .001;
                if (timeTrack >= 1.0)
                {
                    _scoreboard["Time"] -= 1;
                    timeTrack = 0;
                }
            }
        }
        public void checkCoinsForLife()
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
            checkCoinsForLife();
        }
        public void AddPoint(int point)
        {
            _scoreboard["Points"] += point;
        }
        public void LoseLife()
        {
            _scoreboard["Lives"]--;
            if (_scoreboard["Lives"]==0)
            {
                //call method to end game
            }
            else
            {
                MarioGame.Entities.Entity.Script.Reset();
            }
        }

        //Call this when mario hits the flagpole
        public void FinishMultiplier(int time)
        {
            int multiplier = time / 100 + time%100;
            _scoreboard["Points"] += time * multiplier;
        }
    }
}
