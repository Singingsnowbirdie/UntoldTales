//Загружает и сохраняет данные

public abstract class Repository
{
    /// <summary>
    /// Этот метод будет инициализировать все репозитории
    /// </summary>
    public abstract void Initialize();

    /// <summary>
    /// Этот метод отвечает за все сохранения
    /// </summary>
    public abstract void Save();
}
