using UnityEngine;

namespace Matkanoid {

    public class DamageCaster : MonoBehaviour {

        [SerializeField] int _damage;
        public int damage => _damage;
    }
}
