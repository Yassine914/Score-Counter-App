using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    private string text;

    private void Start()
    {
        inputField.text = "" + text;
    }

    public void AddNumber(int numberToAdd)
    {
        text += numberToAdd;
        inputField.text = "" + text;
    }

    public void MinusNumber()
    {
        text = text.Substring(0, text.Length - 1);
        inputField.text = "" + text;
    }

    public void Enter()
    {
        text = "";
    }
}
