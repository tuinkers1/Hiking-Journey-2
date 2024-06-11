using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject player; // Assign the player GameObject in the inspector
    public TextMeshProUGUI dialogueText; // Assign the TextMeshProUGUI element in the inspector
    public TextMeshProUGUI bugCountText; // Assign the bug count TextMeshProUGUI element in the inspector
    public GameObject endGameScreen; // Assign the end game screen UI in the inspector

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
                    // If dialogue was already completed, show the last line
                    DisplayEndDialogueLine();
                }
                else
                {
                    // If dialogue was not completed, start the dialogue
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

    private void DisplayEndDialogueLine()
    {
        dialogueText.gameObject.SetActive(true);
        dialogueText.text = endDialogueLine;
        isDialogueActive = true;
        if (bugCollector.AreAllBugsCaught())
        {
            StartCoroutine(ShowEndGameScreenAfterDelay(3f)); // Adjust the delay as needed
        }
    }

    private void EndDialogue()
    {
        dialogueText.gameObject.SetActive(false);
        isDialogueActive = false;
        currentLine = 0;
        dialogueCompleted = true; // Mark dialogue as completed
        ShowBugCountText();
        if (bugCollector.AreAllBugsCaught())
        {
            DisplayEndDialogueLine();
        }
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
        yield return new WaitForSeconds(2);
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
