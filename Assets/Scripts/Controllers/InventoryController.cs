public class InventoryController : IController
{
    /// <summary>
    /// Инвентарь
    /// </summary>
    HeroInventory inventory;

    public void Initialize()
    {
        inventory = new HeroInventory();
    }

    public void OnCreate()
    {
        //здесь подписываемся на события
    }

    public void OnExit()
    {
        //здесь отписываемся
    }

    public void OnStart()
    {
        //throw new System.NotImplementedException();
    }
}
