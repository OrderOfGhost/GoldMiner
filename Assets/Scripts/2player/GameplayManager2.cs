using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager2 : MonoBehaviour
{
    public static GameplayManager2 instance;
    
    public int player = 0;
	public int Levelload = 0;
    public int NextLevelload = 0;

    public Text win;
    public GameObject playerWin;

    [SerializeField]
    private Text countdownText1;

    public int countdownTimer = 60;

    [SerializeField]
    private Text scoreText1;

    private int scoreCount1;

    [SerializeField]
      private Text scoreText2;

      private int scoreCount2;
    

    void InitGame() {
        // playerWin = GameObject.FindWithTag("PlayerWin");
        // win = GameObject.FindWithTag("TextWin").GetComponent<Text>();
        win.text = "Player"+ player+" win";
        playerWin.SetActive(true);
    }

    void HideplayerWin(){
        playerWin.SetActive(false);
    }

    void Awake() {
        if (instance == null)
            instance = this;
    }
    void Update() {
        if(scoreCount1>scoreCount2){
            player =1;
        }
        if(scoreCount1<scoreCount2){
            player =2;
        }
    }
    // Start is called before the first frame update
    void Start() {

        DisplayScore(0);

        countdownText1.text = countdownTimer.ToString();
        StartCoroutine("Countdown");

    }

    IEnumerator Countdown() {
        yield return new WaitForSeconds(1f);

        countdownTimer -= 1;

        countdownText1.text = countdownTimer.ToString();

        if(countdownTimer <= 10) {
            SoundManager.instance.Touch(true);
        }

        StartCoroutine("Countdown");

        if(countdownTimer <= 0) {
            StopCoroutine("Countdown");

            SoundManager.instance.Touch(false);
            InitGame();
            
            StartCoroutine(RestartGame());
        }

    } // countdown

    public void DisplayScore(int scoreValue) {

        if (scoreText1 == null)
            return;

        scoreCount1 += scoreValue;
        scoreText1.text = "" + scoreCount1;
    }
    public void DisplayScore2(int scoreValue) {

        if (scoreText2 == null)
            return;

        scoreCount2 += scoreValue;
        scoreText2.text = "" + scoreCount2;
    }
    IEnumerator RestartGame() {
        yield return new WaitForSeconds(4f);
        HideplayerWin();
        UnityEngine.SceneManagement.SceneManager.LoadScene(Levelload);
    }

    IEnumerator NextGame() {
        yield return new WaitForSeconds(4f);
        HideplayerWin();
        UnityEngine.SceneManagement.SceneManager.LoadScene(NextLevelload);
    }
}
