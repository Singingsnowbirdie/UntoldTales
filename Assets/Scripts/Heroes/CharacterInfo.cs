using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
//чтобы вызывать быстро из меню
[CreateAssetMenu(fileName = "CharacterInfo", menuName = "Script/CharacterInfo")]
public class CharacterInfo : ScriptableObject
{
    [Header("Имя персонажа")]
    [SerializeField] private string CharacterName;
    public string Name => this.CharacterName;

    [Header("Запас здоровья")]
    [SerializeField] int health;
    public int Health => this.health;

    [Header("Физическая защита")]
    [SerializeField] int physicalProtection;
    public int PhysicalProtection => this.physicalProtection;

     [Header("Магическая защита")]
    [SerializeField] int magicProtection;
    public int MagicProtection => this.magicProtection;

    [Header("Тип атаки (физическая, магическая, гибридная)")]
    [SerializeField] AttackType attackType;
    public AttackType AttackType => this.attackType;

    [Header("Сила атаки: (количество ед. урона за одну атаку)")]
    [SerializeField] int attackPower;
    public int AttackPower => this.attackPower;

    [Header("Скорость атаки: (количество атак в секунду)")]
    [SerializeField] float attackSpeed;
    public float AttackSpeed => this.attackSpeed;

    [Header("Дальность атаки: (в количестве ячеек по прямой)")]
    [SerializeField] int attackRange;
    public int AttackRange => this.attackRange;

    [Header("Префаб")]
    [SerializeField] GameObject pref;
    public GameObject Pref => this.pref;
}
