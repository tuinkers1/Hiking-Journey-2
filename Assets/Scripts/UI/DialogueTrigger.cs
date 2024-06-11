using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject player; 
    public TextMeshProUGUI dialogueText; 
    public TextMeshProUGUI bugCountText; 
    public GameObject endGameScreen; 
    

    private string[] dialogueLines = {
        "Kid: Wow, Dad! This forest is amazing. Look at all the trees and flowers!",
        "Dad: It sure is, buddy. Perfect place to find some interesting insects for your school project.",
        "Kid: I can’t wait to see what we find. Mrs. Johnson said we must collect all the insects in the book. I hope I can do it!",
        "Dad: We’ll find them, no problem. Remember to read your book, it has useful information on where to find them!",
        "Dad: Oh, and one more thing - in case you get lost, there are signs with the map on them.",
        "Kid: Okay! I’m going now!",
        "Dad: Good luck! I will be waiting for you here."
    };

    private string endDialogueLine = "Dad: Good job, kid! Now we can go home.";

    private int currentLine = 0;
    private bool isInTrigger = false;
    private bool isDialogueActive = false;
    private bool dialogueCompleted = false;
    private BugCollector bugCollector;

    void Start()
    {
        if (bugCountText != null)
        {
            bugCountText.gameObject.SetActive(false);
        }
        bugCollector = FindObjectOfType<BugCollector>();
        endGameScreen.SetActive(false);
    }

    void Update()
    {
        if (isInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            if (!isDialogueActive)
            {
                if (dialogueCompleted)
                {  
                    DisplayLastLineIfNeeded();
                }
                else
                {
                    StartDialogue();
                }
            }
            else
            {
                DisplayNextLine();
            }
        }
    }

    private void StartDialogue()
    {
        isDialogueActive = true;
        dialogueText.gameObject.SetActive(true);
        dialogueText.text = dialogueLines[currentLine];
    }

    private void DisplayNextLine()
    {
        currentLine++;
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
        }
        else
        {
            EndDialogue();
        }
    }

    private void DisplayLastLineIfNeeded()
    {
        if (bugCollector.AreAllBugsCaught())
        {
            dialogueText.gameObject.SetActive(true);
            dialogueText.text = endDialogueLine;
            isDialogueActive = true;
            StartCoroutine(ShowEndGameScreenAfterDelay(3f)); 
        }
    }


    private void EndDialogue()
    {
        dialogueText.gameObject.SetActive(false);
        isDialogueActive = false;
        currentLine = 0;
        dialogueCompleted = true; 
        ShowBugCountText();
        DisplayLastLineIfNeeded(); 
    }

    private void ShowBugCountText()
    {
        if (bugCountText != null && !bugCountText.gameObject.activeSelf)
        {
            bugCountText.gameObject.SetActive(true);
        }
    }

    private IEnumerator ShowEndGameScreenAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (endGameScreen != null)
        {
            endGameScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isInTrigger = false;
            if (isDialogueActive)
            {
                EndDialogue();
            }
        }
    }
}
