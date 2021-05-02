using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Core.DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        public GameObject dialogueBox;
        public Animator dialogueBoxAnimator;

        private Queue<string> sentences;

        public bool dialogueOpen = false;

        public static DialogueManager current;

        void Start()
        {
            sentences = new Queue<string>();
        }

        public void StartDialogue(Dialogue dialogue)
        {
            Debug.Log("Starting dialogue with " + dialogue.name);

            dialogueOpen = true;
            dialogueBoxAnimator.SetBool("dialogueOpen", true);

            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence(dialogue);

            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().enabled = false;
        }

        public void DisplayNextSentence(Dialogue dialogue)
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            dialogueBox.GetComponentInChildren<TextMeshProUGUI>().text = dialogue.name + ": " + sentences.Dequeue();
        }

        void EndDialogue()
        {
            dialogueOpen = false;
            dialogueBoxAnimator.SetBool("dialogueOpen", false);

            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().enabled = true;
        }
    }
}
