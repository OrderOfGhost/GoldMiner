using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;
	public int Levelload = 0;
    public int NextLevelload = 0;

    [SerializeField]
    private Text countdownText;

    public int countdownTimer = 60;

    [SerializeField]
    private Text scoreText;

    private int scoreCount;

    [SerializeField]
    private Text MucTieuText;
    public int muctieu;

    void Awake() {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start() {

        DisplayScore(0);

        countdownText.text = countdownTimer.ToString();
        MucTieuText.text = muctieu.ToString();

        StartCoroutine("Countdown");

    }

    IEnumerator Countdown() {
        yield return new WaitForSeconds(1f);

        countdownTimer -= 1;

        countdownText.text = countdownTimer.ToString();

        if(countdownTimer <= 10) {
            SoundManager.instance.Touch(true);
        }

        StartCoroutine("Countdown");

        if(countdownTimer <= 0) {
            StopCoroutine("Countdown");

            SoundManager.instance.Fail();
            SoundManager.instance.Touch(false);

            StartCoroutine(RestartGame());
        }

    } // countdown

    public void DisplayScore(int scoreValue) {

        if (scoreText == null)
            return;

        scoreCount += scoreValue;
        scoreText.text = "" + scoreCount;

        if(scoreCount >= muctieu) {
            StopCoroutine("Countdown");
            SoundManager.instance.Win();
            StartCoroutine(NextGame());
        }

    }

    IEnumerator RestartGame() {
        yield return new WaitForSeconds(4f);

        UnityEngine.SceneManagement.SceneManager.LoadScene(Levelload);
    }

    IEnumerator NextGame() {
        yield return new WaitForSeconds(4f);

        UnityEngine.SceneManagement.SceneManager.LoadScene(NextLevelload);
    }
}
