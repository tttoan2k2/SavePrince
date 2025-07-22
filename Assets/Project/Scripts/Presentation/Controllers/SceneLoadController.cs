using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoadController : MonoBehaviour
{
    private void Start()
    {
        // Nếu chưa có target scene nào được set, mặc định là vào Lobby
        if (string.IsNullOrEmpty(SceneLoader.Instance.GetTargetScene()))
        {
            // targetScene chưa được thiết lập → mặc định vào Scene_Lobby
            SceneLoader.Instance.LoadSceneWithLoading("SceneLobby");
            return;
        }

        StartCoroutine(SceneLoader.Instance.LoadTargetScene());
    }
}
