using System;

using UnityEngine;

namespace Matkanoid {

    public class Brick : MonoBehaviour {

        static readonly int _hitTrigger = Animator.StringToHash("Hit");
        static readonly int _brokenTrigger = Animator.StringToHash("Broken");

        [SerializeField] Breakable _breakable;
        [SerializeField] Scorable _scorable;
        [SerializeField] Animator _animator;

        [Space, SerializeField] AudioSource _audioSource;
        [SerializeField] AudioClipBank _hitSound;
        [SerializeField] AudioClipBank _breakSound;

        public bool isBroken => _breakable.isBroken;

        public event Action<Brick> broken;

        void OnValidate() => _breakable ??= GetComponent<Breakable>();

        void OnEnable() => _breakable.hit += OnHit;

        void OnDisable() => _breakable.hit -= OnHit;

        void OnHit(Breakable breakable) {
            if (breakable.isBroken) {
                _animator.SetTrigger(_brokenTrigger);
                _audioSource.PlayRandomOneShot(_breakSound);
                _scorable.NotifyScored();

                broken?.Invoke(this);

            } else {
                _animator.SetTrigger(_hitTrigger);
                _audioSource.PlayRandomOneShot(_hitSound);
            }
        }
    }
}
