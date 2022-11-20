using UnityEngine;

namespace Matkanoid {

    public class Brick : MonoBehaviour {

        [SerializeField] Breakable _breakable;

        void OnValidate() => _breakable ??= GetComponent<Breakable>();

        void OnEnable() => _breakable.broken += OnBroken;

        void OnDisable() => _breakable.broken -= OnBroken;

        void OnBroken(Breakable damageable) => Destroy(gameObject);
    }
}
