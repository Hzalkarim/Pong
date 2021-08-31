using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hafizh.InternAgate.DiloSubmission.Pong.Controller
{
    public class Trajectory : MonoBehaviour
    {
        [SerializeField]
        private GameObject _ballAtCollition;

        [SerializeField]
        private Ball _ball;
        private CircleCollider2D _ballCollider;
        private Rigidbody2D _ballRigidbody;

        private bool _drawBallAtCollision = false;

        private Vector2 offsetHitPoint = new Vector2();

        private void Start()
        {
            _ballCollider = _ball.GetComponent<CircleCollider2D>();
            _ballRigidbody = _ball.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            
            RaycastHit2D[] raycastHit2DArray =
                Physics2D.CircleCastAll(_ballRigidbody.position, _ballCollider.radius, _ballRigidbody.velocity.normalized);

            foreach (RaycastHit2D hit in raycastHit2DArray)
            {
                if (hit.collider != null && hit.collider.GetComponent<Ball>() == null)
                {
                    offsetHitPoint = hit.point + hit.normal * _ballCollider.radius;
                    
                    DottedLine.DottedLine.Instance.DrawDottedLine(_ballRigidbody.position, offsetHitPoint);

                    if (hit.collider.GetComponent<SideWall>() == null)
                    {
                        Vector2 originTrajectory = new Vector2(_ball.transform.position.x, _ball.transform.position.y);
                        Vector2 inVector = (offsetHitPoint - originTrajectory).normalized;
                        Vector2 outVector = Vector2.Reflect(inVector, hit.normal);

                        float outDot = Vector2.Dot(outVector, hit.normal);
                        if (outDot > -1f && outDot < 1f)
                        {
                            DottedLine.DottedLine.Instance.DrawDottedLine(
                                offsetHitPoint, offsetHitPoint + outVector * 10f);

                            _drawBallAtCollision = true;
                        }
                        break;
                    }
                }
            }

            if (_drawBallAtCollision)
            {
                _ballAtCollition.transform.position = offsetHitPoint;
                _ballAtCollition.SetActive(true);
            }
            else
            {
                _ballAtCollition.SetActive(false);
            }
        }
    }

}

