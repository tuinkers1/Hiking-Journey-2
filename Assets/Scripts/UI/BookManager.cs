using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BookManager : MonoBehaviour
{

    [Header("References")]
    [SerializeField] GameObject bookPages;
    [SerializeField] GameObject bookCover;
    public bool bookActive = false;
    
    Dictionary<string,bool> bugCollection = new Dictionary<string,bool>();

    // Start is called before the first frame update
    void Start()
    {
        bookCover.SetActive(false);
        bookPages.SetActive(false);

        // initialy adding the bugs to the dictionary
        // if you need to add a bug to the dictionary copy this line bellow this and change the values, and change the bugname
        bugCollection.Add("bugname", false);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.I) && bookActive == false) 
        { 
        bookCover.SetActive (true);
        bookPages.SetActive (true);
        bookActive = true;
            return;
        }
        if (Input.GetKeyDown(KeyCode.I) && bookActive == true)
        {
            bookCover.SetActive (false);
            bookPages.SetActive(false);
            bookActive = false;
            return;
        }
        
    }

    private void OnCatch()
    // for optimisation reasons this is only called when you catch a bug to check which one is caught
    {
        // to change if a bug is seen as caught use the code bellow this line, of course change bugname to the actual name
        /*if (bugCollection["bugname"] == true)
        {
            

        }
        */ 

    }
    
}
