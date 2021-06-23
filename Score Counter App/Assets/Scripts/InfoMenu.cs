using TMPro;
using UnityEngine;

public class InfoMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI infoTitle;
    [SerializeField] private TextMeshProUGUI infoText;
    
    public void ChangeInfoText(string infoTextToChange)
    {
        infoText.text = infoTextToChange;
    }

    public void ChangeInfoTitle(string infoTitleToChange)
    {
        infoTitle.text = infoTitleToChange;
    }
}
