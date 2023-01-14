using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Room2_out : MonoBehaviour
{
    // Названия нужных объектов :
    // TriggerZone1 - триггер к которому этот скрипт привязан, найдешь в поиске
    // Darkness_Room1 - темная зона, её можно будет скопировать чтобы потом расставить как надо тебе и потом различным макаром затемнять
    public GameObject potol1, potol4, potol5, resh; // Для потолка который затемняется. Скопируй его с который есть
    public bool Player_in_Room = false; // Изначально эти объекты не находятся в том триггере к которому предназначен этот код(поэтому False),
    public bool Hand_in_Room = false; // но у тебя может быть другая ситуация

    void OnTriggerEnter(Collider other) //Функция первичного входа объекта other
    {
        if ((other.tag == "Player")) // Если ТЭГ объекта other это Player
        {
            Player_in_Room = true; // Игрок в комнате = ИСТИНА
        }
        if ((other.tag == "Hand")) // Если ТЭГ объекта other это Hand, т.е. если рука зашла в триггер зону
        {
            Hand_in_Room = true; // Рука в триггер зоне = ИСТИНА
        }
        if (other.tag == "Player" || other.tag == "Hand") // Если хоть кто-то из двух сущностей есть в триггере
        {
            potol1.GetComponent<Darkness>().Dark(); // То запускаем анимацию прозрачности темной штучки, чтобы она плавно исчезла
            potol4.GetComponent<Darkness>().Dark();
            potol5.GetComponent<Darkness>().Dark();
            resh.SetActive(true);
        }
    }
}