using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        public float Speed = 2.0f;

        private PlayMakerFSM _playerFSM;
        private Animator _playerAnimator;

        private void Start()
        {
            _playerFSM = GetComponent<PlayMakerFSM>();
            _playerAnimator = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            HandleKeyboardMovement();
        }

        private void HandleKeyboardMovement()
        {
            if (Input.GetKey(KeyCode.A))
            {
                // Move left
                MovePlayer(Vector2.left, Input.GetAxis("Horizontal"));
                _playerFSM.SendEvent(Constants.PlayerConstants.MoveLeftEvent);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // Move right
                MovePlayer(Vector2.right, Input.GetAxis("Horizontal"));
                _playerFSM.SendEvent(Constants.PlayerConstants.MoveRightEvent);
            }
            else
            {
                // Stop the player
                MovePlayer(new Vector2(), 0);
                _playerFSM.SendEvent(Constants.PlayerConstants.StopMovingEvent);
            }
            // This can be pressed at the same time as movement
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerFSM.SendEvent(Constants.PlayerConstants.ShootEvent);
            }
        }

        private void MovePlayer(Vector2 direction, float speed)
        {
            _playerAnimator.SetFloat("MovementDirection", speed);
            transform.Translate(direction * Time.deltaTime * Speed);
        }

    }

}

