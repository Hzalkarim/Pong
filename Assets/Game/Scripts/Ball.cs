using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hafizh.InternAgate.DiloSubmission.Pong.Controller
{
    public class Ball : MonoBehaviour
    {

        private Rigidbody2D _rigidbody2D;

        [SerializeField]
        private float _xInitialForce;
        [SerializeField]
        private float _yInitialForce;
        // Start is called before the first frame update
    
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();

            RestartGame();
        }

        private void RestartGame()
        {
            ResetBall();

            Invoke("PushBall", 2f);
        }

        private void ResetBall()
        {
            _rigidbody2D.position = Vector2.zero;

            _rigidbody2D.velocity = Vector2.zero;
        }

        private void PushBall()
        {
            float randomYForce = Random.Range(-_yInitialForce, _yInitialForce);

            float randomDir = Random.Range(0f, 2f);

            if (randomDir < 1f)
            {
                _rigidbody2D.AddForce(new Vector2(-_xInitialForce, randomYForce));
            }
            else
            {
                _rigidbody2D.AddForce(new Vector2(_xInitialForce, randomYForce));
            }
        }
    }
}
