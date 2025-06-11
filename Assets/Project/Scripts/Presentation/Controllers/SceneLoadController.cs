using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoadController : MonoBehaviour
{
    //void Start()
    //{
    //    SceneTransfer.sceneToLoad = "SceneLobby";
    //    string sceneToLoad = SceneTransfer.sceneToLoad;

    //    if (!string.IsNullOrEmpty(sceneToLoad))
    //    {
    //        StartCoroutine(LoadSceneAsync(sceneToLoad));
    //    }
    //}

    //IEnumerator LoadSceneAsync(string sceneName)
    //{
    //    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

    //    while (!operation.isDone)
    //    {
    //        yield return null;
    //    }
    //}

    

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
