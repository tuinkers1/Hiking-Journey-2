using UnityEngine;
using UnityEngine.EventSystems;

public class InfoPage : MonoBehaviour, IPointerClickHandler
{
    public string bugName;
    public BugCollector bugCollector;
    public GameObject infoPage;
    public GameObject infoPageSilhouette;
    public GameObject infoPageColored;
    private static InfoPage currentActiveInfoPage; 

    private void Start()
    {
        infoPage.SetActive(false);
        infoPageSilhouette.SetActive(false);
        infoPageColored.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentActiveInfoPage != null && currentActiveInfoPage != this)
        {
            currentActiveInfoPage.HideInfoPage();
        }

        currentActiveInfoPage = this;

        ShowInfoPage();
    }

    private void ShowInfoPage()
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

    private void HideInfoPage()
    {
        infoPage.SetActive(false);
        infoPageSilhouette.SetActive(false);
        infoPageColored.SetActive(false);
    }
}
