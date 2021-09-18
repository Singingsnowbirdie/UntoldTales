using UnityEngine;

//Запускает игру
//Вешаем на го в нулевой сцене

public class GameRunner : MonoBehaviour
{
    private void Start()
    {
        Game.Run();
    }
}
