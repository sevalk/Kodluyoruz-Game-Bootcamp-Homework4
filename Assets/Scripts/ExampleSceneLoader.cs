using UnityEngine;
using UnityEngine.SceneManagement;

public class ExampleSceneLoader : MonoBehaviour
{
   
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index , LoadSceneMode.Additive);
    }

    public void UnLoadScene(int index)
    {
        SceneManager.UnloadSceneAsync(index);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(7);
    }
}

public enum Scenes
{
    SampleScene,
    UITEST
}
