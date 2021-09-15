using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Этот класс нужен для того, чтобы вызывать корутины НЕ из монобихевиоров
//Ключевое слово sealed запрещает наследоваться от этого класса (на всякий случай)

public sealed class Coroutines : MonoBehaviour
{
    /// <summary>
    /// Вспомогательная переменная 
    /// </summary>
    static Coroutines m_instance;

    /// <summary>
    /// Экземпляр
    /// </summary>
    static Coroutines instance
    {
        get
        {
            //если еще нет экземпляра 
            if (m_instance == null)
            {
                //создаем go
                var go = new GameObject("[COROUTINE MANAGER]");
                //и вешаем на него этот скрипт
                m_instance = go.AddComponent<Coroutines>();
                //не уничтожаем этот объект, при смене сцены (да, это синглтон)
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
