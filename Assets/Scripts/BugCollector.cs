using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BugCollector : MonoBehaviour
{
    [SerializeField]
    private List<Bug> bugs = new List<Bug>();

    private Dictionary<string, Image> bugImages = new Dictionary<string, Image>();
    private Dictionary<string, bool> bugsCaught = new Dictionary<string, bool>();
    private Dictionary<string, GameObject> bugCaughtMessages = new Dictionary<string, GameObject>();

    public GameObject duplicateBugMessage;

    void Start()
    {
        foreach (var bug in bugs)
        {
            bugsCaught[bug.bugName] = false;

            Image bugImage = GameObject.Find(bug.bugName + "Image").GetComponent<Image>();
            if (bugImage != null)
            {
                bugImages[bug.bugName] = bugImage;
                bugImage.sprite = bug.coloredSprite;
                bugImage.enabled = false;
            }
            else
            {
                Debug.LogWarning("UI Image for bug " + bug.bugName + " not found.");
            }

            GameObject bugCaughtMessage = GameObject.Find(bug.bugName + "CaughtMessage");
            if (bugCaughtMessage != null)
            {
                bugCaughtMessages[bug.bugName] = bugCaughtMessage;
                bugCaughtMessage.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Caught message for bug " + bug.bugName + " not found.");
            }
        }

        duplicateBugMessage.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            CatchAllBugs();
        }
    }

    public void OnCatch(string bugName)
    {
        if (bugsCaught.ContainsKey(bugName))
        {
            if (bugsCaught[bugName])
            {
                StartCoroutine(ShowMessage(duplicateBugMessage));
            }
            else
            {
                bugsCaught[bugName] = true;
                if (bugImages.ContainsKey(bugName))
                {
                    bugImages[bugName].enabled = true;
                }
                if (bugCaughtMessages.ContainsKey(bugName))
                {
                    StartCoroutine(ShowMessage(bugCaughtMessages[bugName]));
                }
                else
                {
                    Debug.LogWarning("Caught message for bug " + bugName + " not found.");
                }
            }
        }
        else
        {
            Debug.LogWarning("Bug not found in the dictionary.");
        }
    }

    private IEnumerator ShowMessage(GameObject messageObject)
    {
        messageObject.SetActive(true);
        yield return new WaitForSeconds(2);
        messageObject.SetActive(false);
    }

    public bool IsBugCaught(string bugName)
    {
        if (bugsCaught.ContainsKey(bugName))
        {
            return bugsCaught[bugName];
        }
        else
        {
            Debug.LogWarning("Bug not found in the dictionary.");
            return false;
        }
    }

    private void CatchAllBugs()
    {
        foreach (var bug in bugs)
        {
            string bugName = bug.bugName;
            bugsCaught[bugName] = true;

            if (bugImages.ContainsKey(bugName))
            {
                bugImages[bugName].enabled = true;
            }

            if (bugCaughtMessages.ContainsKey(bugName))
            {
                StartCoroutine(ShowMessage(bugCaughtMessages[bugName]));
            }
        }
    }
}
