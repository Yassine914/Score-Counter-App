using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDownMode : MonoBehaviour
{
    [SerializeField] private GameObject CountDownModeOldObjects;
    [SerializeField] private GameObject infoMenu;
    [SerializeField] private Animator[] animators;
    
    [Header("Starting Score")]
    [SerializeField] private TMP_InputField startingScoreInputField;
    [SerializeField] private string startingScoreTitle = "";
    [SerializeField] private string startingScorePlaceholder = "";
    
    [Header("Calculator")]
    [SerializeField] private GameObject calculator;
    [SerializeField] private TextMeshProUGUI calculatorTitleText;
    [SerializeField] private TMP_InputField calculatorInputField;
    [SerializeField] private TextMeshProUGUI calcPlaceholder;

    private void Start()
    {
        infoMenu.SetActive(false);
        calculator.SetActive(false);
    }

    public void DeleteOldObjects()
    {
        Destroy(CountDownModeOldObjects);
    }
    
    public void StartingScoreInput()
    {
        calculator.SetActive(true);
        calculatorTitleText.text = startingScoreTitle;
        calcPlaceholder.text = startingScorePlaceholder;
        calculatorInputField.text = "";
    }
    
    public void CloseCalculator()
    {
        calculator.GetComponent<Animator>().SetTrigger("CloseCalculator");
        StartCoroutine(CloseCalculatorDelay());
        startingScoreInputField.text = calculatorInputField.text;
    }

    private IEnumerator CloseCalculatorDelay()
    {
        yield return new WaitForSeconds(1);
        calculator.SetActive(false);
        calculatorInputField.text = "";
    }
    
    public void OpenInfoMenu()
    {
        infoMenu.SetActive(true);
    }

    public void CloseInfoMenu()
    {
        infoMenu.GetComponent<Animator>().SetTrigger("ClosedInfoMenu");
        StartCoroutine(CloseInfoDelay());
    }

    private IEnumerator CloseInfoDelay()
    {
        yield return new WaitForSeconds(0.8f);
        infoMenu.SetActive(false);
    }
    
    public void Continue()
    {
        PlayerPrefs.SetString("StartingScore", startingScoreInputField.text);
    }

    public void Back()
    {
        foreach (var animator in animators)
        {
            animator.SetTrigger("Back");
        }
        StartCoroutine(BackButton());
    }

    private IEnumerator BackButton()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
