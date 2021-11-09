
//игроки

using System;
using System.Collections.Generic;

public class Players
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public Players()
    {
        players = CreatePlayers();
    }

    /// <summary>
    /// Все игроки
    /// </summary>
    private List<Player> players;

    /// <summary>
    /// Максимальное кол-во игроков
    /// </summary>
    readonly int maxPlayers = 8;

    /// <summary>
    /// Создает список игроков
    /// </summary>
    /// <returns></returns>
    private List<Player> CreatePlayers()
    {
        List<Player> players = new List<Player>
        {
            new RealPlayer(0)
        };
        //добавляем AI игроков
        for (int i = 1; i < maxPlayers; i++)
        {
            players.Add(new AIPlayer(i));
        }
        return players;
    }

    /// <summary>
    /// Возвращает список всех игроков
    /// </summary>
    /// <returns></returns>
    internal List<Player> GetPlayers()
    {
        return players;
    }

    /// <summary>
    /// Возвращает всех AI игроков
    /// </summary>
    /// <returns></returns>
    internal List<AIPlayer> GetAIPlayers()
    {
        List<AIPlayer> temp = new List<AIPlayer>();

        foreach (var item in players)
        {
            if (item is AIPlayer)
            {
                temp.Add(item as AIPlayer);
            }
        }

        return temp;
    }


}
