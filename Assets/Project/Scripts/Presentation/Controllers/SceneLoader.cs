using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    private string targetScene;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadSceneWithLoading(string sceneName)
    {
        targetScene = sceneName;
        SceneManager.LoadScene("SceneLoading");
    }

    public string GetTargetScene()
    {
        return targetScene;
    }

    public IEnumerator LoadTargetScene()
    {
        yield return new WaitForSeconds(3f);
        AsyncOperation op = SceneManager.LoadSceneAsync(targetScene);

        while (!op.isDone)
        {
            yield return null;
        }
    }
}
