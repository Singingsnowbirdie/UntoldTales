using TMPro;
using UnityEngine;
using UnityEngine.UI;

//карточка героя в магазине (или во временном хранилище)

public class HeroMarketCard : MonoBehaviour
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
    //рамочка карточки
    [SerializeField] Image frame;

    /// <summary>
    /// Заполняет карточку героя в магазине
    /// </summary>
    public void ShowHeroInfo(Hero hero, int sameHeroes)
    {
        heroNameText.text = hero.Info.Name;
        heroClassText.text = hero.Info.Class.ToString();
        heroFractionText.text = hero.Info.Fraction.ToString();
        heroCostText.text = hero.Info.Cost.ToString();
        heroRankText.text = hero.Info.Rank.ToString();

        //перекрашиваем рамочку
        if (sameHeroes == 1) frame.color = Color.yellow;
        else if (sameHeroes == 2) frame.color = Color.green;
        else frame.color = Color.white;
    }

    /// <summary>
    /// Заполняет карточку героя во временном хранилище
    /// </summary>
    internal void ShowHeroInfo(Hero hero)
    {
        heroNameText.text = hero.Info.Name;
        heroClassText.text = hero.Info.Class.ToString();
        heroFractionText.text = hero.Info.Fraction.ToString();
        heroCostText.text = hero.Info.Cost.ToString();
        heroRankText.text = hero.Info.Rank.ToString();
    }
}
