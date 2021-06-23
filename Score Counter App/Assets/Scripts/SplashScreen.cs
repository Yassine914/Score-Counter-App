using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private float secondsTillLoadScene = 2f;
    [SerializeField] private Animator[] animators;
    private bool _hasClicked = false;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_hasClicked)
        {
            _hasClicked = true;
            if (_hasClicked)
            {
                AnimateOut();
                StartCoroutine(LoadNextScene());
            }
        }
    }

    private void AnimateOut()
    {
        foreach (var animator in animators)
        {
            animator.SetTrigger("playerHasClicked");
        }
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(secondsTillLoadScene);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}