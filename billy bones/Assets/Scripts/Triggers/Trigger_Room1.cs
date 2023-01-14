using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Room1 : MonoBehaviour
{
    // Названия нужных объектов :
    // TriggerZone1 - триггер к которому этот скрипт привязан, найдешь в поиске
    // Darkness_Room1 - темная зона, её можно будет скопировать чтобы потом расставить как надо тебе и потом различным макаром затемнять
    public GameObject potol; // Для потолка который затемняется. Скопируй его с который есть
    public bool Player_in_Room = false; // Изначально эти объекты не находятся в том триггере к которому предназначен этот код(поэтому False),
    public bool Hand_in_Room = false; // но у тебя может быть другая ситуация

    void OnTriggerEnter (Collider other) //Функция первичного входа объекта other
    {
        if((other.tag == "Player")) // Если ТЭГ объекта other это Player
        {
            Player_in_Room = true; // Игрок в комнате = ИСТИНА
        }
        if((other.tag == "Hand")) // Если ТЭГ объекта other это Hand, т.е. если рука зашла в триггер зону
        {
            Hand_in_Room = true; // Рука в триггер зоне = ИСТИНА
        }
        if(other.tag == "Player" || other.tag == "Hand") // Если хоть кто-то из двух сущностей есть в триггере
        {
            potol.GetComponent<Darkness>().Dark(); // То запускаем анимацию прозрачности темной штучки, чтобы она плавно исчезла
        }
    }


    void OnTriggerExit (Collider other)
    {
        if((other.tag == "Player")) // если скелеток вышел из триггера
        {
            Player_in_Room = false; // Скелетон в комнате = ЛОЖЬ
        }
        if((other.tag == "Hand")) // если рука вышла из триггера 
        {
            Hand_in_Room = false; // рука в комнате ЛОЖЬ
        }
        if(Player_in_Room == false && Hand_in_Room == false) // если оба объекта НЕ находятся в триггере
        {
            potol.GetComponent<Darkness>().DeDark(); // Затемняем зону
        }
    }
}
