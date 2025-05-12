using UnityEngine;
using TMPro;

public class InteractiveUIManager : MonoBehaviour
{
    [Header("Interactive UI")]
    public TextMeshProUGUI interactiveText;

    public void ShowData(string text)
    {
        interactiveText.text = text;
    }

    public void HideData()
    {
        interactiveText.text = "";
    }

}
