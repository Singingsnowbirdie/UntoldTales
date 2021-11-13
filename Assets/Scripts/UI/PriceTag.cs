using TMPro;
using UnityEngine;

//карточка героя в магазине

public class PriceTag : MonoBehaviour
{
    //поле: имя героя
    [SerializeField] TextMeshProUGUI heroNameText;
    //поле: класс героя
    [SerializeField] TextMeshProUGUI heroClassText;
    //поле: фракция героя
    [SerializeField] TextMeshProUGUI heroFractionText;
    //поле: стоимость героя
    [SerializeField] TextMeshProUGUI heroCostText;
    //поле: ранг (редкость) героя
    [SerializeField] TextMeshProUGUI heroRankText;

    /// <summary>
    /// Отображает новую карточку героя
    /// </summary>
    public void ShowHeroInfo(Hero hero)
    {
        heroNameText.text = hero.Info.Name;
        heroClassText.text = hero.Info.Class.ToString();
        heroFractionText.text = hero.Info.Fraction.ToString();
        heroCostText.text = hero.Info.Cost.ToString();
        heroRankText.text = hero.Info.Rank.ToString();
    }
}
