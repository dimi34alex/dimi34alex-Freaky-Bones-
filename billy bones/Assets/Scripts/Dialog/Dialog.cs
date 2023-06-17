using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    [System.Serializable]
    public class Sentences
    {
        [TextArea(3, 10)]
        public string sentence;
        public bool isPlayerSpeak;

        public Sentences(string sen, bool playerSpeak = false)
        {
            sentence = sen;
            isPlayerSpeak = playerSpeak;
        }
    }
    public string name;
    public List<Sentences> sent;
    public Sprite awatarSpeaker;

    public void Clear()
    {
        sent.Clear();
    }
}
