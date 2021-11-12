using UnityEditor;
using UnityEngine;
//управляет отображением класса CharacterInfo в инспекторе
[CustomEditor(typeof(CharacterInfo))]

public class CharacterInfoEditor : Editor
{
    CharacterInfo info;

    private void OnEnable()
    {
        info = (CharacterInfo)target;
    }

    protected override void OnHeaderGUI()
    {
        info.IsHero = EditorGUILayout.Toggle("Герой", info.IsHero);

        info.Name = EditorGUILayout.TextField("Имя", info.Name);
        info.Rank = EditorGUILayout.IntField("Ранг", info.Rank);

        info.Health = EditorGUILayout.IntField("Запас здоровья", info.Health);

        info.PhysicalProtection = EditorGUILayout.IntField("Физическая защита", info.PhysicalProtection);
        info.MagicProtection = EditorGUILayout.IntField("Магическая защита", info.MagicProtection);

        info.AttackPower = EditorGUILayout.IntField("Сила атаки", info.AttackPower);
        info.AttackSpeed = EditorGUILayout.FloatField("Скорость атаки", info.AttackSpeed);
        info.AttackRange = EditorGUILayout.IntField("Дальность атаки", info.AttackRange);

        if (info.IsHero)
        {
            info.Fraction = (Fraction)EditorGUILayout.EnumPopup("Фракция", info.Fraction);
            info.Class = (Class)EditorGUILayout.EnumPopup("Класс", info.Class);
            info.HasUltimateAbility = EditorGUILayout.Toggle("Имеет ульту", info.HasUltimateAbility);
            info.AttackType = (AttackType)EditorGUILayout.EnumPopup("Тип атаки", info.AttackType);
            info.Mana = EditorGUILayout.IntField("Запас маны", info.Mana);

            if (info.HasUltimateAbility)
            {
                info.Energy = EditorGUILayout.IntField("Запас энергии", info.Energy);
                info.EnergyStorageRate = EditorGUILayout.IntField("Сколько энергии герой получает за одну атаку по цели", info.EnergyStorageRate);
            }
        }
        else
        {
            info.СombatType = (CombatType)EditorGUILayout.EnumPopup("Стиль боя", info.СombatType);
        }

        if (GUI.changed)
        {
            Undo.RecordObject(info, "Test Scriptable Editor Modify");
            EditorUtility.SetDirty(info);
        }

    }
}
