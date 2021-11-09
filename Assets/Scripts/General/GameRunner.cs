using UnityEngine;

//Запускает игру

public class GameRunner : MonoBehaviour
{
    /// <summary>
    /// Загрузчик сцены
    /// </summary>
    SceneLoader sceneLoader;

    private void OnEnable()
    {
        sceneLoader = new SceneLoader();
    }

    private void Start()
    {
        sceneLoader.LoadSceneAsync();
    }
}
