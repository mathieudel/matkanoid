using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Matkanoid {

    [CreateAssetMenu(menuName = "Matkanoid/Audio clip bank", fileName = "Audio clip bank")]
    public class AudioClipBank : ScriptableObject, IReadOnlyList<AudioClip> {

        [SerializeField] AudioClip[] _audioClips;

        public int Count => _audioClips.Length;

        public AudioClip this[int index] => _audioClips[index];

        public IEnumerator<AudioClip> GetEnumerator() => ((IEnumerable<AudioClip>) _audioClips).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}
