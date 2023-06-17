using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] string playerNameSpeaker;

    public GameObject awatar;

    public Sprite playerImg;
    private Sprite otherImg;

    private Dialog dialog1;

    public GameObject DialogPanel, StartDialogPanel, player;
    public Text dialogText, nameText;
    private Queue<Dialog.Sentences> sentences;

    int indexQueue = 0;
    private void Start()
    {
        sentences = new Queue<Dialog.Sentences>();
        EndDialog();
        //StartDialogPanel.SetActive(false);
    }

    public void StartDialog(Dialog dialog)
    {
        otherImg = dialog.awatarSpeaker;
        if (dialog.sent[0].isPlayerSpeak)
        {
            nameText.text = playerNameSpeaker;
            dialog.awatarSpeaker = playerImg;
            awatar.GetComponent<Image>().sprite = dialog.awatarSpeaker;
        }
        player.GetComponent<PlayerMove>().enabled = false;

        DialogPanel.SetActive(true);
        StartDialogPanel.SetActive(false);

        nameText.text = dialog.name;
        sentences.Clear();

        foreach(Dialog.Sentences sentence in dialog.sent)
        {
            sentences.Enqueue(sentence);
        }
        dialog1 = dialog;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        if (dialog1.sent[indexQueue].isPlayerSpeak)
        {
            nameText.text = playerNameSpeaker;
            dialog1.awatarSpeaker = playerImg;
            awatar.GetComponent<Image>().sprite = dialog1.awatarSpeaker;
        }
        else
        {
            nameText.text = dialog1.name;
            dialog1.awatarSpeaker = otherImg;
            awatar.GetComponent<Image>().sprite = dialog1.awatarSpeaker;
        }
        Dialog.Sentences sen = sentences.Dequeue();
            //sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sen.sentence));
        indexQueue++;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void EndDialog()
    {
        indexQueue = 0;
        DialogPanel.SetActive(false);
        player.GetComponent<PlayerMove>().enabled = true;
    }
}
