using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeWriterEffect : MonoBehaviour
{
    public float delay = 0.1f; // Delay between each character
    public string fullText; // The full text to display
    private string currentText = ""; // The current text being displayed

    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in fullText.ToCharArray())
        {
            currentText += letter;
            GetComponent<TMP_Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
