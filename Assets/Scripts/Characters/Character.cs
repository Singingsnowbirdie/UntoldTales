using UnityEngine;

//общий класс для моба и героя

public class Character : MonoBehaviour
{
    /// <summary>
    /// Аниматор
    /// </summary>
    public Animator Anim { get; set; }

    /// <summary>
    /// Модель
    /// </summary>
    public CharacterModel Model { get; set; }

    /// <summary>
    /// Инфо
    /// </summary>
    [SerializeField] CharacterInfo info;
    public CharacterInfo Info { get => info; set => info = value; }

    /// <summary>
    /// стейт-машина
    /// </summary>
    public StateMachine StateMachine { get; set; }

    /// <summary>
    /// текущая цель
    /// </summary>
    public Character CurrentTarget { get; set; }

    /// <summary>
    /// Точка, на которой стоит персонаж (?)
    /// </summary>
    public Point Point { get; set; }

    /// <summary>
    /// У героя вызвается при размещении в резерве
    /// У моба вызывается при размещении на поле
    /// </summary>
    protected virtual void OnCharacterEnable()
    {
        Model = new CharacterModel(Info);
        StateMachine = new CharacterStateMachine(this);
    }

    /// <summary>
    /// Атака
    /// </summary>
    public virtual void Attack()
    {
        Debug.Log("Персонаж атакует");
    }

    /// <summary>
    /// Единичная атака по цели
    /// </summary>
    public void Hit()
    {
        //рассчитываем потенциальный урон
        float damage = Damage();
        //наносим удар по цели
        CurrentTarget.TakeDamage(damage);
    }

    /// <summary>
    /// расчет урона
    /// </summary>
    public float Damage()
    {
        //тест
        return 10;
    }

    /// <summary>
    /// Получение урона
    /// </summary>
    public void TakeDamage(float potentialDamage)
    {
        Debug.Log($"Health = {Info.Health}");
        Model.Health -= potentialDamage - Protection();
        Debug.Log(transform.name + " " + Info.Health);
    }

    /// <summary>
    /// Расчет защиты
    /// </summary>
    private float Protection()
    {
        //тест
        return 1;
    }
}
