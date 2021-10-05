using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Этот вспомогательный класс нужен для работы с функционалом MonoBehaviour из классов, которые от него не наследуются

public sealed class UtilsManager : MonoBehaviour
{
    /// <summary>
    /// Вспомогательная переменная 
    /// </summary>
    static UtilsManager m_instance;

    /// <summary>
    /// Экземпляр
    /// </summary>
    static UtilsManager instance
    {
        get
        {
            //если еще нет экземпляра 
            if (m_instance == null)
            {
                //создаем go
                var go = new GameObject("CoroutinesManager");
                //и вешаем на него этот скрипт
                m_instance = go.AddComponent<UtilsManager>();
                //не уничтожаем этот объект, при смене сцены
                DontDestroyOnLoad(go);
            }
            return m_instance;
        }
    }

    /// <summary>
    /// Запускает корутину
    /// </summary>
    /// <param name="enumerator"></param>
    /// <returns></returns>
    public static Coroutine StartRoutine(IEnumerator enumerator)
    {
        return instance.StartCoroutine(enumerator);
    }

    /// <summary>
    /// Останавливает корутину
    /// </summary>
    /// <param name="routine"></param>
    public static void StopRoutine(Coroutine routine)
    {
        if (routine != null)
        {
            instance.StopCoroutine(routine);
        }
    }

    /// <summary>
    /// Спавнит ГО
    /// </summary>
    /// <param name="obj"></param>
    public static GameObject Spawn(GameObject go)
    {
        GameObject gameObject = Instantiate(go, new Vector3(0, 0, 0), Quaternion.identity);
        return gameObject;
    }
}
