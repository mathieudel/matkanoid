using System;

using UnityEngine;

namespace Matkanoid {

    public class TriggerEvent2D : MonoBehaviour {

        public event Action<TriggerEvent2D, Collider2D> entered;
        public event Action<TriggerEvent2D, Collider2D> stayed;
        public event Action<TriggerEvent2D, Collider2D> exited;

        void OnTriggerEnter2D(Collider2D other) => entered?.Invoke(this, other);

        void OnTriggerStay2D(Collider2D other) => stayed?.Invoke(this, other);

        void OnTriggerExit2D(Collider2D other) => exited?.Invoke(this, other);
    }
}
