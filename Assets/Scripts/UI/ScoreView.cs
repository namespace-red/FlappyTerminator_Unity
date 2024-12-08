using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreView : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnValidate()
    {
        if (_enemySpawner == null)
            throw new NullReferenceException(nameof(_enemySpawner));
    }

    private void OnEnable()
    {
        _enemySpawner.Released += SetValue;
    }

    private void OnDisable()
    {
        _enemySpawner.Released -= SetValue;
    }

    private void Start()
    {
        SetValue(0);
    }

    private void SetValue(int value)
    {
        _text.text = "Score: " + value.ToString();
    }
}
