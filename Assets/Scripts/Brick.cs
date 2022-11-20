using System;

using UnityEngine;

namespace Matkanoid {

    public class Brick : MonoBehaviour {

        [SerializeField] Breakable _breakable;
        [SerializeField] Scorable _scorable;

        public bool isBroken => _breakable.isBroken;

        public event Action<Brick> broken;

        void OnValidate() => _breakable ??= GetComponent<Breakable>();

        void OnEnable() => _breakable.broken += OnBroken;

        void OnDisable() => _breakable.broken -= OnBroken;

        void OnBroken(Breakable damageable) {
            _scorable.NotifyScored();
            broken?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
