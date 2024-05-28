using UnityEngine;
using UnityEngine.EventSystems;

public class InfoPage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string bugName; 
    public BugCollector bugCollector; 
    public GameObject infoPage; 
    public GameObject infoPageSilhouette; 
    public GameObject infoPageColored; 

    private void Start()
    {
        
        infoPage.SetActive(false);
        infoPageSilhouette.SetActive(false);
        infoPageColored.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        infoPage.SetActive(true);
        

        if (bugCollector != null && bugCollector.IsBugCaught(bugName))
        {
            infoPageColored.SetActive(true);
            infoPageSilhouette.SetActive(false);
        }
        else
        {
            infoPageColored.SetActive(false);
            infoPageSilhouette.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        infoPage.SetActive(false);
        infoPageSilhouette.SetActive(false);
        infoPageColored.SetActive(false);
    }
}