using System.Collections;
using UnityEngine;
using TMPro;

public class InfoButton : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] private GameObject infoGameObject;
    [SerializeField] private string countUpModeName;
    [TextArea(3,10)] [SerializeField] private string countUpModeInfoText;
    [SerializeField] private string countDownModeName;
    [TextArea(3,10)] [SerializeField] private string countDownModeInfoText;
    [SerializeField] private Animator infoPopUpAnimator;
    [SerializeField] private float disableMenuTime = 0.6f;

    private void Start()
    {
        infoGameObject.SetActive(false);
    }

    public void OpenInfoPopUp(int modeIndex)
    {
        infoGameObject.SetActive(true);

        var modeNameText = infoGameObject.GetComponentsInChildren<TextMeshProUGUI>()[0];
        var infoText = infoGameObject.GetComponentsInChildren<TextMeshProUGUI>()[1];

        if (modeIndex == 0)
        {
            infoText.text = countUpModeInfoText;
            modeNameText.text = countUpModeName;
        }
        else if (modeIndex == 1)
        {
            infoText.text = countDownModeInfoText;
            modeNameText.text = countDownModeName;
        }
    }

    public void CloseInfoPopUp()
    {
        StartCoroutine(CloseInfoAnim());
    }

    private IEnumerator CloseInfoAnim()
    {
        infoPopUpAnimator.SetTrigger("playehHasClickedBack");
        yield return new WaitForSeconds(disableMenuTime);
        infoGameObject.SetActive(false);
    }
}
