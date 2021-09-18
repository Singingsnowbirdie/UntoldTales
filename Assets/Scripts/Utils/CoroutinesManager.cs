using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Это синглтон
//Этот класс нужен для того, чтобы вызывать корутины НЕ из монобихевиоров
//Для этого монобеха НЕ НУЖНО создавать объект в сцене и навешивать его вручную (он все это делает сам)
//Ключевое слово sealed запрещает наследоваться от этого класса (на всякий случай)

public sealed class CoroutinesManager : MonoBehaviour
{
    /// <summary>
    /// Вспомогательная переменная 
    /// </summary>
    static CoroutinesManager m_instance;

    /// <summary>
    /// Экземпляр
    /// </summary>
    static CoroutinesManager instance
    {
        get
        {
            //если еще нет экземпляра 
            if (m_instance == null)
            {
                //создаем go
                var go = new GameObject("CoroutinesManager");
                //и вешаем на него этот скрипт
                m_instance = go.AddComponent<CoroutinesManager>();
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
}
