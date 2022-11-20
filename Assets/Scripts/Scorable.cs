using System;

using UnityEngine;

namespace Matkanoid {

    public class Scorable : MonoBehaviour {

        [SerializeField] int _points;
        public int points => _points;

        public event Action<Scorable> scored;

        public void NotifyScored() => scored?.Invoke(this);
    }
}
