using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private WindowView _startView;
    [SerializeField] private WindowView _gameOverView;
    [SerializeField] private Health _playerHealth;
    
    private void OnValidate()
    {
        if (_startView == null)
            throw new NullReferenceException(nameof(_startView));
        
        if (_gameOverView == null)
            throw new NullReferenceException(nameof(_gameOverView));
        
        if (_playerHealth == null)
            throw new NullReferenceException(nameof(_playerHealth));
    }

    private void OnEnable()
    {
        _startView.Closed += StartGame;
        _gameOverView.Closed += RestartGame;
        _playerHealth.Died += Stop;
    }

    private void OnDisable()
    {
        _startView.Closed -= StartGame;
        _gameOverView.Closed -= RestartGame;
        _playerHealth.Died -= Stop;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startView.Show();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void Stop()
    {
        Time.timeScale = 0;
        _gameOverView.Show();
    }
}
