using System.Collections;
using UnityEngine;

// Этот вспомогательный класс нужен для работы с функционалом MonoBehaviour из классов, которые от него не наследуются
// Пока что, в этом классе лежит логика получения списка мобов. Позже, вероятнее всего, для этого будет создан отдельный класс.

public sealed class UtilsManager : MonoBehaviour
{
    /// <summary>
    /// Вспомогательная переменная 
    /// </summary>
    static UtilsManager m_instance;

    /// <summary>
    /// Экземпляр
    /// </summary>
    static UtilsManager Instance
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
        return Instance.StartCoroutine(enumerator);
    }

    /// <summary>
    /// Останавливает корутину
    /// </summary>
    /// <param name="routine"></param>
    public static void StopRoutine(Coroutine routine)
    {
        if (routine != null)
        {
            Instance.StopCoroutine(routine);
        }
    }

    /// <summary>
    /// Спавнит ГО в нулевых координатах
    /// </summary>
    /// <param name="obj"></param>
    internal static GameObject Spawn(string path)
    {
        return Instantiate(Resources.Load(path) as GameObject, new Vector3(0, 0, 0), Quaternion.identity);
    }

    /// <summary>
    /// Спавнит ГО в заданных координатах
    /// </summary>
    internal static GameObject Spawn(GameObject go, Vector3 position)
    {
        GameObject gameObject = Instantiate(go, position, Quaternion.identity);
        return gameObject;
    }


}
