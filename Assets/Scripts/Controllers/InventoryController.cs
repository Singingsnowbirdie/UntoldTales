public class InventoryController : IController
{
    /// <summary>
    /// Инвентарь
    /// </summary>
    Inventory inventory;

    public void Initialize()
    {
        inventory = new Inventory();
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
