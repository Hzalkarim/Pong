using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hafizh.InternAgate.DiloSubmission.Pong.Controller
{
    public class Player : MonoBehaviour
    {

        [SerializeField]
        private KeyCode _upButton;
        [SerializeField]
        private KeyCode _downButton;

        [SerializeField]
        private float _speed = 10f;

        [SerializeField]
        private float _yBoundary = 9f;

        private Rigidbody2D _rigidbody2D;

        private int _score = 0;
        public int Score
        {
            get
            {
                return _score;
            }
        }

        private void Start()
        {
            if (_rigidbody2D == null)
            {
                _rigidbody2D = GetComponent<Rigidbody2D>();
            }

        }

        private void Update()
        {
            UpdateVelocity();

            UpdateBoundToSpace();

        }

        private void UpdateBoundToSpace()
        {
            Vector3 position = transform.position;

            if (position.y > _yBoundary)
            {
                position.y = _yBoundary;
            }
            else if (position.y < -_yBoundary)
            {
                position.y = -_yBoundary;
            }

            transform.position = position;
        }

        private void UpdateVelocity()
        {
            Vector2 velocity = _rigidbody2D.velocity;

            if (Input.GetKey(_upButton))
            {
                velocity.y = _speed;
            }
            else if (Input.GetKey(_downButton))
            {
                velocity.y = -_speed;
            }
            else
            {
                velocity.y = 0f;
            }

            _rigidbody2D.velocity = velocity;
        }

        public void IncreaseScore()
        {
            _score++;
        }

        public void ResetScore()
        {
            _score = 0;
        }
    }
}
