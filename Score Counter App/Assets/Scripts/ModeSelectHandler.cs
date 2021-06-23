using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModeSelectHandler : MonoBehaviour
{
    [SerializeField] private float openSceneDelay = 1f;
    [SerializeField] private Animator[] modesAnimators;
    [SerializeField] private Animator[] animators;
    [SerializeField] private Button countUpModeButton;
    [SerializeField] private Button countDownModeButton;
    
    private void Start()
    {
        countDownModeButton.enabled = true;
        countUpModeButton.enabled = true;
    }

    public void CountUpModeSelect()
    {
        foreach (var animator in modesAnimators)
        {
            animator.SetTrigger("CountUpModeSelect");
        }
        
        foreach (var animator in animators)
        {
            animator.SetTrigger("ModeSelected");
        }

        countDownModeButton.enabled = false;
        StartCoroutine(OpenMode(2));
    }
    

    public void CountDownModeSelect()
    {
        foreach (var animator in modesAnimators)
        {
            animator.SetTrigger("CountDownModeSelect");
        }

        foreach (var animator in animators)
        {
            animator.SetTrigger("ModeSelected");
        }

        countUpModeButton.enabled = false;
        StartCoroutine(OpenMode(3));
    }

    private IEnumerator OpenMode(int buildIndex)
    {
        yield return new WaitForSeconds(openSceneDelay);
        SceneManager.LoadScene(buildIndex);
    }
}
