using UnityEngine;
using UnityEngine.EventSystems;

public class DragonflyInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string bugName; // The name or ID of the bug
    public BugCollector bugCollector; // Reference to the BugCollector script
    public GameObject infoPage; // Reference to the main info page GameObject
    public GameObject infoPageSilhouette; // Reference to the silhouette image GameObject
    public GameObject infoPageColored; // Reference to the colored image GameObject

    private void Start()
    {
        // Ensure only the info page is initially inactive
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
