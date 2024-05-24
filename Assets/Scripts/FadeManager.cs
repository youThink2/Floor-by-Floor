using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeManager : MonoBehaviour
{
    public Image fadeOverlay; // The image used for fading
    public float fadeDuration = 7.0f; // Duration of fade in seconds
    private static FadeManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist this object through scene changes
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    private void Start()
    {
        StartCoroutine(StartGameSequence());
    }

    private IEnumerator StartGameSequence()
    {
        // Initial fade in from black to show the image
        yield return StartCoroutine(FadeFromBlack());

        // Wait for a few seconds (showing the image)
        yield return new WaitForSeconds(2.0f); // Adjust this duration as needed

        // Fade out to black
        yield return StartCoroutine(FadeToBlack());

        // Load the next scene
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("TimeTrialSurvival");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the new fade overlay in the loaded scene
        fadeOverlay = GameObject.Find("FadeOverlay").GetComponent<Image>();
        StartCoroutine(FadeFromBlackInNewScene());
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private IEnumerator FadeFromBlack()
    {
        float elapsedTime = 0.0f;
        Color color = fadeOverlay.color;
        color.a = 1.0f; // Ensure alpha is set to 1 at the start
        fadeOverlay.color = color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeOverlay.color = color;
            yield return null;
        }

        color.a = 0.0f;
        fadeOverlay.color = color;
    }

    private IEnumerator FadeToBlack()
    {
        float elapsedTime = 0.0f;
        Color color = fadeOverlay.color;
        color.a = 0.0f; // Ensure alpha is set to 0 at the start
        fadeOverlay.color = color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeOverlay.color = color;
            yield return null;
        }

        color.a = 1.0f;
        fadeOverlay.color = color;
    }

    private IEnumerator FadeFromBlackInNewScene()
    {
        float elapsedTime = 0.0f;
        Color color = fadeOverlay.color;
        color.a = 1.0f; // Ensure alpha is set to 1 at the start
        fadeOverlay.color = color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeOverlay.color = color;
            yield return null;
        }

        color.a = 0.0f;
        fadeOverlay.color = color;

        yield return new WaitForSeconds(7.0f); // Wait for 7 seconds

        // Destroy the fade overlay
        Destroy(fadeOverlay.gameObject);

    }
    //public void LoadScene(string sceneName)
    //{
   //     SceneManager.LoadScene(TimeTrialSurvival);
    //}

   // public void LoadNextScene()
   // {
  //      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
   //     SceneManager.LoadScene(currentSceneIndex + 1);
   // }
}
