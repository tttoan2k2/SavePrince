using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLobbyController : MonoBehaviour
{
    //[SerializeField] private Button playButton;
    //public string targetPlayScene;

    //private void Start()
    //{
    //    playButton.onClick.AddListener(OnPlayClicked);
    //}

    //void OnPlayClicked()
    //{
    //    SceneLoader.Instance.LoadSceneWithLoading(targetPlayScene);
    //}

    [SerializeField] private Button playButton;
    public string targetPlayScene;

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayClicked);
    }

    void OnPlayClicked()
    {
        SceneManager.LoadSceneAsync(targetPlayScene);
    }
}
