using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;


    [SerializeField]private Slider _progressBar;
    [SerializeField] private ParticleSystem[] _finishParticles; 
    private GameState _gameState;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public static GameManager Instance()
    {
        return _instance;
    }


    private void Start()
    {
        PrepareGame();
    }

    private void PrepareGame()
    {
        _gameState = new GameState();
        _gameState.totalCheckPoint = 5;
        ChangeProgressValue();
    }

    public void ChangeCheckPoint(int id)
    {
        _gameState.currentCheckPoint = id + 1;
        if(id + 1== _gameState.totalCheckPoint)
        { 
            EndLevel();
        }
        ChangeProgressValue();
    }

    

    private void ChangeProgressValue()
    {
        float progressValue = (float)_gameState.currentCheckPoint / (float)_gameState.totalCheckPoint;
        _progressBar.value = progressValue;
    }


    private void EndLevel()
    {
        foreach(var item in _finishParticles)
        {
            var emmision = item.emission; 
            emmision.enabled = true;
        }
    }





}
