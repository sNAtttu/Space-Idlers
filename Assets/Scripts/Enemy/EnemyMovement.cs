using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public bool IsEnemiesGoingToRight = true;
        public bool shouldEnemyLinesMove = true;
        public float MovementIntervalSeconds = 0.5f;
        public float MovementAmount = 0.2f;
        public float LineDropAmount = 0.1f;

        private void Start()
        {
            StartCoroutine(MoveEnemyLine());
        }

        private void DropLine()
        {
            float newHeight = transform.position.y - LineDropAmount;
            transform.position = new Vector3(transform.position.x, newHeight);
        }

        private void MoveLine(bool isGoingRight)
        {
            float newHorizontalPosition = isGoingRight ? transform.position.x + MovementAmount : transform.position.x - MovementAmount;
            transform.position = new Vector3(newHorizontalPosition, transform.position.y, 0);
            return;
        }

        public void SetEnemyDirection(bool isGoingRight)
        {
            DropLine();
            IsEnemiesGoingToRight = isGoingRight;
        }

        IEnumerator MoveEnemyLine()
        {
            while (shouldEnemyLinesMove)
            {
                yield return new WaitForSeconds(MovementIntervalSeconds);
                MoveLine(IsEnemiesGoingToRight);
            }
            
        }

    }
}
