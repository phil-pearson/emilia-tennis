using System;
using static System.Net.Mime.MediaTypeNames;

namespace Tennis {
    public class TennisGame : ITennisGame {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame(string player1Name, string player2Name) {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName) {
            if (playerName == this.player1Name)
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore() {
            if (m_score1 == m_score2) {
                return GetEvenScore(m_score1);
            }
            else if (m_score1 >= 4 || m_score2 >= 4) {
                var minusResult = m_score1 - m_score2;
                var difference = Math.Abs(m_score1 - m_score2);
                var leadPlayer = m_score1 > m_score2 ? player1Name : player2Name;

                if (difference == 1) {
                    return $"Advantage {leadPlayer}";
                }
                else {
                    return $"Win for {leadPlayer}";
                }
            }
            else {
                var playerOne = GetTempScoring(m_score1);
                var playerTwo = GetTempScoring(m_score2);
                return $"{playerOne}-{playerTwo}";
            }
        }

        private string GetTempScoring(int playerScore) {
            return playerScore switch {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => throw new System.Exception("Invalid score")
            };
        }

        private string GetEvenScore(int playerScore) {
            return playerScore switch {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
        }
    }
}

