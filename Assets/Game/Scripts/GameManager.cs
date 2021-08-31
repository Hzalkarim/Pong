using Hafizh.InternAgate.DiloSubmission.Pong.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hafizh.InternAgate.DiloSubmission.Pong.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private Player _player1;
        [SerializeField]
        private Player _player2;

        private Ball _ball;

        [SerializeField]
        private int _maxScore = 3;
        public int MaxScore { get { return _maxScore; } }

        void OnGUI()
        {
            GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + _player1.Score);
            GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + _player2.Score);

            if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
            {
                _player1.ResetScore();
                _player2.ResetScore();

                _ball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
            }

            if (_player1.Score == MaxScore)
            {
                GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 10, 2000, 1000), "PLAYER ONE WINS");

                _ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            }
            else if (_player2.Score == MaxScore)
            {
                GUI.Label(new Rect(Screen.width / 2 + 30, Screen.height / 2 - 10, 2000, 1000), "PLAYER TWO WINS");

                _ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            }
        }
    }
}
