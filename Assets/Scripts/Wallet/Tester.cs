using System.Collections;
using UnityEngine;

public class Tester : MonoBehaviour
{

    //temp debug
    public static Scene scene;

    private void Start()
    {
        var sceneConfig = new SceneConfigExample();
        scene = new Scene(sceneConfig);

        StartCoroutine(scene.InitializeRoutine());
    }
}
