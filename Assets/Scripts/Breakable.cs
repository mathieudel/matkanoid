using System;

using UnityEngine;

namespace Matkanoid {

    public class Breakable : MonoBehaviour {

        [SerializeField] int _health;
        public int health => _health;

        public event Action<Breakable> broken;

        void OnCollisionEnter2D(Collision2D collision) {
            if (_health == 0) { return; }

            var damageCaster = collision.gameObject.GetComponent<DamageCaster>();
            if (damageCaster != null) {
                ReceiveDamage(damageCaster.damage);
            }
        }

        void ReceiveDamage(int damage) {
            _health = Mathf.Max(0, _health - damage);
            if (_health == 0) {
                broken?.Invoke(this);
            }
        }
    }
}
