using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shots
{
    public class Fireball : MonoBehaviour
    {
        public int Damage = 1;
        public float Speed = 5.0f;

        private SpriteRenderer _fireBallRenderer;

        private void Start()
        {
            _fireBallRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector2.up * Time.deltaTime * Speed);
            if (!_fireBallRenderer.isVisible)
            {
                Destroy(gameObject);
            }
        }
    }
}
