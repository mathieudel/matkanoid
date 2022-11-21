using System;

using UnityEngine;
using UnityEngine.UI;

namespace Matkanoid {

  public class Popup : MonoBehaviour {

    static readonly int _openedParameter = Animator.StringToHash("Opened");

    [SerializeField] Button _validationButton;
    [SerializeField] Animator _animator;

    public event Action<Popup> validated;

    void OnEnable() => _validationButton.onClick.AddListener(OnValidationButtonClicked);

    void OnDisable() => _validationButton.onClick.RemoveListener(OnValidationButtonClicked);

    public void Open() {
      gameObject.SetActive(true);
      _animator.SetBool(_openedParameter, true);
    }

    public void Close() => _animator.SetBool(_openedParameter, false);

    void OnValidationButtonClicked() {
      validated?.Invoke(this);
    }

    void NotifyClosed() => gameObject.SetActive(false);
  }
}
