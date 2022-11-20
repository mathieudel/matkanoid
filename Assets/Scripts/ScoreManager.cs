using System.Linq;

using UnityEngine;

using TMPro;

namespace Matkanoid {

    public class ScoreManager : MonoBehaviour {

        [SerializeField] Transform _scorablesRoot;
        [SerializeField] TMP_Text _scoreText;

        Scorable[] _scorables;
        int _score;

        void Awake() => _scorables = _scorablesRoot.GetComponentsInChildren<Scorable>(true).ToArray();

        void OnEnable() {
            foreach (var scorable in _scorables) {
                scorable.scored += OnScored;
            }
        }

        void OnDisable() {
            foreach (var scorable in _scorables) {
                scorable.scored -= OnScored;
            }
        }

        void OnScored(Scorable scorable) {
            _score += scorable.points;
            _scoreText.text = $"{_score}";
        }
    }
}
