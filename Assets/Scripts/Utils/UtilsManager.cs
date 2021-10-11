using System.Collections;
using System.Collections.Generic;
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
    /// Все мобы с ближней атакой
    /// </summary>
    static List<Mob> meleeMobsDB;

    /// <summary>
    /// Все мобы с дальней атакой
    /// </summary>
    static List<Mob> rangeMobsDB;

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
    /// Возвращает список всех милишных мобов
    /// </summary>
    internal static List<Mob> GetMeleeMobsDB()
    {
        if (meleeMobsDB == null)
        {
            InitMobsDB();
        }
        return meleeMobsDB;
    }

    /// <summary>
    /// Возвращает список всех дальних мобов
    /// </summary>
    internal static List<Mob> GetRangeMobsDB()
    {
        if (rangeMobsDB == null)
        {
            InitMobsDB();
        }
        return rangeMobsDB;
    }

    /// <summary>
    /// Подгружает базу мобов
    /// </summary>
    private static void InitMobsDB()
    {
        //БД мобов
        var mobsDB = Resources.LoadAll("TestObjects/Mobs");
        meleeMobsDB = new List<Mob>();
        rangeMobsDB = new List<Mob>();

        //заполняем списки
        foreach (var item in mobsDB)
        {
            if ((item as GameObject).GetComponent<Mob>().info.СombatType == CombatType.Melee)
            {
                meleeMobsDB.Add((item as GameObject).GetComponent<Mob>());
            }
            else
            {
                rangeMobsDB.Add((item as GameObject).GetComponent<Mob>());
            }
        }
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
