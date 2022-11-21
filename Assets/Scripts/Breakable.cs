using System;

using UnityEngine;

namespace Matkanoid {

    public class Breakable : MonoBehaviour {

        [SerializeField] int _health;
        public int health => _health;

        public event Action<Breakable> hit;

        public bool isBroken => health <= 0;

        void OnCollisionEnter2D(Collision2D collision) {
            var damageCaster = collision.gameObject.GetComponent<DamageCaster>();
            if (damageCaster != null) {
                _health = Mathf.Max(0, _health - damageCaster.damage);
            }

            hit?.Invoke(this);
        }
    }
}
