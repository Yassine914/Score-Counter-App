using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountUpMode : MonoBehaviour
{
    [SerializeField] private GameObject CountUpModeOldObjects;
    [SerializeField] private GameObject infoMenu;
    [SerializeField] private Animator[] animators;
    
    [Header("Winning Score")]
    [SerializeField] private TMP_InputField winningScoreInputField;
    [SerializeField] private string winningScoreTitle = "";
    [SerializeField] private string winningScorePlaceholder = "";
    [Header("Counting Score")]
    [SerializeField] private TMP_InputField countingScoreInputField;
    [SerializeField] private string countingScoreTitle = "";
    [SerializeField] private string countingScorePlaceholder = "";
    [Header("Calculator")]
    [SerializeField] private GameObject calculator;
    [SerializeField] private TextMeshProUGUI calculatorTitleText;
    [SerializeField] private TMP_InputField calculatorInputField;
    [SerializeField] private TextMeshProUGUI calcPlaceholder;

    private bool isPingPongModeOn;

    private void Start()
    {
        calculator.SetActive(false);
        infoMenu.SetActive(false);
    }

    public void DeleteOldGameObjects()
    {
        Destroy(CountUpModeOldObjects);
    }

    public void WinningScoreInput()
    {
        calculator.SetActive(true);
        calculatorTitleText.text = winningScoreTitle;
        calcPlaceholder.text = winningScorePlaceholder;
        calculatorInputField.text = "";
    }

    public void CountingScoreInput()
    {
        calculator.SetActive(true);
        calculatorTitleText.text = countingScoreTitle;
        calcPlaceholder.text = countingScorePlaceholder;
        calculatorInputField.text = "";
    }

    public void CloseCalculator()
    {
        calculator.GetComponent<Animator>().SetTrigger("CloseCalculator");
        StartCoroutine(CloseCalculatorDelay());

        if (calculatorTitleText.text == winningScoreTitle)
        {
            winningScoreInputField.text = calculatorInputField.text;
        }
        else if (calculatorTitleText.text == countingScoreTitle)
        {
            countingScoreInputField.text = calculatorInputField.text;
        }
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

    public void PingPongMode(bool isEnabled)
    {
        if (isEnabled)
        {
            isPingPongModeOn = true;
            PlayerPrefs.SetInt("PingPongMode", 1);
        }
        else
        {
            isPingPongModeOn = false;
            PlayerPrefs.SetInt("PingPongMode", 0);
        }
    }

    public void Continue()
    {
        PlayerPrefs.SetString("WinningScore", winningScoreInputField.text);
        PlayerPrefs.SetString("CountingScore", countingScoreInputField.text);
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