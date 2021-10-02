//Загружает и сохраняет данные

using System;

public abstract class Repository
{
    /// <summary>
    /// Отвечает за все сохранения
    /// </summary>
    public abstract void Save();

    /// <summary>
    /// Срабатывает после создания всех контроллеров и репозиториев
    /// </summary>
    internal abstract void OnCreate();

    /// <summary>
    /// Этот метод будет инициализировать все репозитории
    /// </summary>
    public abstract void Initialize();

    /// <summary>
    /// Вызывается при старте
    /// </summary>
    internal abstract void OnStart();
}
