using UnityEngine;

//кнопка покупки опыта хранителя

public class ExperencePurchaseButton : MonoBehaviour
{
    /// <summary>
    /// Кнопка "купить опыт Хранителя"
    /// </summary>
    public void BuyExperience()
    {
        EventManager.OnBttnPressedEventInvoke(Bttn.BuyExperienceBttn);
    }
}
