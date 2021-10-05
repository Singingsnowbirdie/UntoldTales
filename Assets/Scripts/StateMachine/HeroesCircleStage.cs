using UnityEngine;

//Круг героев
//Первый и последний этапы начальной стадии матча
//Первый этап: на время
//Последний этап: по очереди

public class HeroesCircleStage : IStage
{
    /// <summary>
    /// Название стадии
    /// </summary>
    readonly string stageName = "Круг героев";

    /// <summary>
    /// Круг героев (скрипт)
    /// </summary>
    HeroesCircle heroesCircle;

    /// <summary>
    /// При входе в состояние
    /// </summary>
    public void Enter()
    {
        //сообщаем о входе в состояние
        EventManager.OnStageEnterEventInvoke(stageName);
        Debug.Log($"Вход в стадию: {stageName}");
        //создаем круг героев
        SpawnHeroesCircle();
        //подписываемся на событие "игрок выбрал себе героя"
        EventManager.OnHeroSelected += OnHeroSelected;
    }

    /// <summary>
    /// Игрок выбрал себе героя
    /// </summary>
    /// <param name="obj"></param>
    private void OnHeroSelected(Hero hero, int playerID)
    {
        //проверяем, всех ли героев разобрали
        if (heroesCircle.AllHeroesSelected(hero))
        {
            Debug.Log("AllHeroesSelected");
        }
    }

    /// <summary>
    /// Создает круг героев и размещает его в сцене
    /// </summary>
    private void SpawnHeroesCircle()
    {
        var obj = Resources.Load("TestObjects/HeroesCircle");
        GameObject heroesCircleGO = UtilsManager.Spawn(obj as GameObject);
        heroesCircle = heroesCircleGO.GetComponent<HeroesCircle>();
    }

    /// <summary>
    /// При выходе из состояния
    /// </summary>
    public void Exit()
    {
        EventManager.OnStageExitEventInvoke(stageName);
        Debug.Log($"Выход из стадии: {stageName}");
    }
}
