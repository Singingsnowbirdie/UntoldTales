using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Загрузчик сцен

public class SceneLoader
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public SceneLoader()
    {
        ScenesConfigs = new Dictionary<string, SceneConfig>();

        //инициализируем все сцены
        ScenesConfigs["MatchScene"] = new MatchScene();

        //подписываемся
        EventManager.OnSceneLoad += LoadScene;
    }

    /// <summary>
    /// Загружает сцену по событию
    /// </summary>
    /// <param name="sceneName"></param>
    private void LoadScene(string sceneName)
    {
        LoadSceneAsync(sceneName);
    }

    /// <summary>
    /// Конфиги всех сцен
    /// </summary>
    Dictionary<string, SceneConfig> ScenesConfigs;

    /// <summary>
    /// Текущая сцена
    /// </summary>
    Scene currentScene;

    /// <summary>
    /// Загрузка открытой сцены
    /// </summary>
    public Coroutine LoadSceneAsync()
    {
        //получаем конфиг открытой сейчас сцены
        var config = ScenesConfigs[SceneManager.GetActiveScene().name];
        //запускаем загрузку
        return UtilsManager.StartRoutine(LoadSceneRoutine(config, false));
    }

    /// <summary>
    /// Загрузка новой сцены
    /// </summary>
    public Coroutine LoadSceneAsync(string sceneName)
    {
        //освобождаемся от всех ненужных подписок
        currentScene.UnsubscribeAll();
        //получаем конфиг новой сцены
        var config = ScenesConfigs[sceneName];
        //запускаем загрузку
        return UtilsManager.StartRoutine(LoadSceneRoutine(config, true));
    }

    /// <summary>
    /// Загрузка сцены (корутина)
    /// </summary>
    IEnumerator LoadSceneRoutine(SceneConfig sceneConfig, bool isNew)
    {
        //если новая сцена, сначала загружаем ее
        if (isNew) yield return UtilsManager.StartRoutine(LoadSceneRoutine(sceneConfig));
        //инициализируем
        yield return UtilsManager.StartRoutine(InitializeSceneRoutine(sceneConfig));
    }

    /// <summary>
    /// Загрузчик сцены
    /// </summary>
    IEnumerator LoadSceneRoutine(SceneConfig sceneConfig)
    {
        //загружаем сцену
        var async = SceneManager.LoadSceneAsync(sceneConfig.ToString());
        //запрещаем автоматическую активацию сцены на время загрузки (чтоб не забаговался показ заставки)
        async.allowSceneActivation = false;
        //пока идет процесс загрузки, показываем заставку
        while (async.progress < 0.9f)
        {
            //здесь будем показывать заставку
            yield return null;
        }
        //запускаем сцену
        async.allowSceneActivation = true;
    }

    /// <summary>
    /// Инициализатор сцены
    /// </summary>
    /// <param name="sceneConfig"></param>
    /// <returns></returns>
    IEnumerator InitializeSceneRoutine(SceneConfig sceneConfig)
    {
        //запоминаем текущую сцену
        currentScene = new Scene(sceneConfig);
        //инициализируем ее
        yield return currentScene.InitializeAsync();
        //стартуем
        currentScene.StartScene();
    }
}