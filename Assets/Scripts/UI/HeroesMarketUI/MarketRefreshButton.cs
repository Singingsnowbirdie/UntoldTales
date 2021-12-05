using UnityEngine;

//кнопка обновления ассортимента магазина

public class MarketRefreshButton : MonoBehaviour
{
    /// <summary>
    /// Кнопка "Обновить"
    /// </summary>
    public void RefreshBttnPress()
    {
        EventManager.OnBttnPressedEventInvoke(Bttn.UpdateAssortmentBttn);
    }
}
