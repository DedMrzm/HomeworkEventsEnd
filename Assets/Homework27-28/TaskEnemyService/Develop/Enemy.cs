using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Task27_28
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private bool _isDead;
        private float _lifeTime;

        public float LifeTime => _lifeTime;
        public bool IsDead => _isDead;

        private void Update()
        {
            _lifeTime += Time.deltaTime;
        }

        public void Kill()
            => Destroy(gameObject);
    }
}
