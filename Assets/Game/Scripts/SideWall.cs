using System.Collections;
using System.Collections.Generic;
using Hafizh.InternAgate.DiloSubmission.Pong.Controller;
using Hafizh.InternAgate.DiloSubmission.Pong.Manager;
using UnityEngine;

namespace Hafizh.InternAgate.DiloSubmission.Pong
{
    public class SideWall : MonoBehaviour
    {
        public Player player;

        [SerializeField]
        private GameManager _gameManager;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.name == "Ball")
            {
                player.IncreaseScore();

                if (player.Score < _gameManager.MaxScore)
                {
                    collision.gameObject.SendMessage("RestartGame", 2f, SendMessageOptions.RequireReceiver);
                }
            }
        }
    }
}

