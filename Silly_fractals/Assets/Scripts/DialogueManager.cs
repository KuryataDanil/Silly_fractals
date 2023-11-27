using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public GameObject TraderStart;
    public GameObject TraderEnd;
    private Queue<string> sentences;
    private float startPosY;

    private bool _endOfGame;

    void Start()
    {
        startPosY = transform.position.y;
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, bool endOfGame)
    {
        _endOfGame = endOfGame;
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            StartCoroutine(EndDialogue());
            return;
        }

        string sentence = sentences.Dequeue();
        if (sentences.Count == 1)
            PlayerManager.instance.player.GetComponent<Shooting>().enabled = true;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void SkipDialogue()
    {
        PlayerManager.instance.player.GetComponent<Shooting>().enabled = true;
        StopAllCoroutines();
        StartCoroutine(EndDialogue());
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

    }

    IEnumerator EndDialogue()
    {
        TraderStart.SetActive(false);
        TraderEnd.SetActive(false);
        DialogueManager manager = FindObjectOfType<DialogueManager>();
        while (manager.transform.position.y < startPosY)
        {
            manager.transform.position += new Vector3(0, 4, 0);
            yield return null;
        }
        if (!_endOfGame)
        {
            FindObjectOfType<EnemySpawner>().FirstSpawn();
        }
        else
        {
            EnemiesManager.instance.OpenHatches();
        }
        
    }
}
