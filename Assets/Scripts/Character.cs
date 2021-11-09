using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator anim;
    /// <summary>
    /// Статы героя
    /// </summary>
    protected CharacterModel characterModel;

    /// <summary>
    /// Информация о герое (скриптабл обдж.)
    /// </summary>
    [SerializeField] CharacterInfo characterInfo;

    /// </summary>
    /// состояния
    /// </summary>
    public StateMachine heroStateMachine;

    /// <summary>
    /// Текущая цель
    /// </summary>

    public Hero CurrentTarget { get; set; }

    /// <summary>
    /// Суммарная стоимость всех экипированных предметов (в единицах)
    /// </summary>
    public int EquipmentСost { get; set; }

    private void Awake()
    {
        heroStateMachine = new HeroStateMachine(this);
    }

    /// <summary>
    /// Жизненный цикл героя (после активации = после помещения на поле боя)
    /// </summary>
    /// <returns></returns>
    public IEnumerator HeroLifeCycleRoutine()
    {
        yield return null;
    }

    /// <summary>
    /// "Снимает" с героя все надетые на него предметы
    /// Передает их во временный рюкзак
    /// </summary>
    /// <returns></returns>
    internal List<Item> TakeOffAllItems()
    {
        //дописать
        return new List<Item>();
    }

    /// <summary>
    /// Повышает ранг героя
    /// </summary>
    internal void Raise()
    {
        //ищем инфо героя с таким же именем, но выше рангом, "наклеиваем" его на этого героя
    }

    /// <summary>
    /// Атака
    /// </summary>
    public virtual void Attack()
    {
        Debug.Log("Герой атакует");
    }

    /// <summary>
    /// Информация о герое
    /// </summary>
    public HeroInfo info;

    /// <summary>
    /// ID героя в отряде (присваивается при добавлении героя в отряд)
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Самоуничтожение
    /// </summary>
    internal void SelfDestruction()
    {
        Destroy(gameObject);
    }

    public void Hit()
    {
        float damage = GetDamage();

        CurrentTarget.TakeDamage(damage);
    }

    /// <summary>
    /// расчет урона
    /// </summary>
    public float GetDamage()
    {
        return 10;
    }

    /// <summary>
    /// получение урона
    /// </summary>
    public void TakeDamage(float take)
    {
        Debug.Log(health);
        health -= (take - GetProtection());
        Debug.Log(transform.name + " " + health);
    }

    /// <summary>
    /// расчет защиты
    /// </summary>
    private float GetProtection()
    {
        return 1;
    }

    /// <summary>
    /// Инициализация
    /// </summary>
    private void Init()
    {
        characterModel = new CharacterModel(characterInfo);
    }
}
