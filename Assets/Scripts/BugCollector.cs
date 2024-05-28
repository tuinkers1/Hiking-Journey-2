using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BugCollector : MonoBehaviour
{
    [SerializeField]
    private List<Bug> bugs = new List<Bug>();

    private Dictionary<string, Image> bugImages = new Dictionary<string, Image>();
    private Dictionary<string, bool> bugsCaught = new Dictionary<string, bool>();

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
        }
    }

    
    public void OnCatch(string bugName)
    {
        if (bugsCaught.ContainsKey(bugName))
        {
            bugsCaught[bugName] = true;
            if (bugImages.ContainsKey(bugName))
            {
                bugImages[bugName].enabled = true;
            }
        }
        else
        {
            Debug.LogWarning("Bug not found in the dictionary.");
        }
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
}
