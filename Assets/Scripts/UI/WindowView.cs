using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class WindowView : MonoBehaviour
{
    [SerializeField] private Button _closeButton;

    public event Action Closed;
    
    private void OnValidate()
    {
        if (_closeButton == null)
            throw new NullReferenceException(nameof(_closeButton));
    }

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(Close);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Closed?.Invoke();
    }
}
