using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLobbyController : MonoBehaviour
{
    //public void LoadPlayScene()
    //{


    //    SceneManager.LoadScene("ScenePlay");
    //}

    [SerializeField]private Button playButton;
    public string targetPlayScene;

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayClicked);
    }

    void OnPlayClicked()
    {
        // Giả sử bạn muốn vào Level 1
       

        // Gọi SceneLoader để chuyển sang Loading trước, rồi mới load Level
        SceneLoader.Instance.LoadSceneWithLoading(targetPlayScene);
    }
}
