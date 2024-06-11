using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Unity.UI;
using TMPro;

public class removetext : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float fadeSpeed = 1f;
    [SerializeField] string Textstring;
    [SerializeField] KeyCode[] inputKeys;

    private bool isComplete = false;

    void Start()
    {
        textMesh.text = Textstring;
    }

    void Update()
    {
        foreach (KeyCode key in inputKeys)
        {
            if (Input.GetKeyDown(key))
            {
                FadeOutAndDelete();
                break;
            }
        }
    }

    void FadeOutAndDelete()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    IEnumerator FadeOutCoroutine()
    {
        while (textMesh.color.a > 0)
        {
            Color newColor = textMesh.color;
            newColor.a -= fadeSpeed * Time.deltaTime;
            textMesh.color = newColor;
            yield return null;
        }

        Destroy(gameObject);
    }

    public void CompleteText()
    {
        if (!isComplete)
        {
            textMesh.text = "COMPLETE";
            isComplete = true;
        }
    }
}
