using UnityEngine;

namespace Matkanoid {

    public static class IAudioSourceExtensions {

        public static void PlayRandom(this AudioSource audioSource, AudioClipBank audioClipBank) {
            if (audioClipBank.TryGetRandom(out var clip)) {
              audioSource.clip = clip;
              audioSource.Play();
            }
        }

        public static void PlayRandomOneShot(this AudioSource audioSource, AudioClipBank audioClipBank) {
            if (audioClipBank.TryGetRandom(out var clip)) {
              audioSource.PlayOneShot(clip);
            }
        }
    }
}
