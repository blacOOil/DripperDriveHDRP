using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HologrameLevel : MonoBehaviour
{
    public GameObject Player, MissionText, MissionComplete, MissionFail, StartBeefing;
    [SerializeField] TextMeshProUGUI RemainingOBJ, Timetext, TimeScore, Score;
    [SerializeField] public float remaingTime;
    private float StartingTime, TimeTaken;
    public float Dropped;
    public float TargetPoint;
    private Rigidbody playerRigidbody;
    public Transform Spawnpoint;


    // Start is called before the first frame update
    void Start()
    {

        StartingTime = remaingTime;
        Time.timeScale = 1f;
        playerRigidbody = Player.GetComponent<Rigidbody>();
        MissionComplete.SetActive(false);
        MissionFail.SetActive(false);
        MissionText.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(StartBeefingCat());
        RemainingOBJ.text = string.Format("{0}", Dropped);
        remaingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remaingTime / 60);
        int second = Mathf.FloorToInt(remaingTime % 60);
        Timetext.text = string.Format("{0:00}:{1:00}", minutes, second);
        if (remaingTime < 0)
        {
            Fail();
            Timetext.text = "00:00";

        }
        if (Dropped == TargetPoint)
        {
            playerRigidbody.constraints = RigidbodyConstraints.FreezePosition;
            EndLevel();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TargetTag"))
        {
            Dropped++;
            RemainingOBJ.text = Dropped.ToString();
        }
        if (other.CompareTag("InstanceSpotlightTag"))
        {
            transform.position = Spawnpoint.position;
            // Fail();

        }
    }
    void EndLevel()
    {
        ScoreCalculation();
        MissionComplete.SetActive(true);
        MissionText.SetActive(false);
    }
    void Fail()
    {

        playerRigidbody.constraints = RigidbodyConstraints.FreezePosition;
        MissionFail.SetActive(true);
        MissionText.SetActive(false);

    }
    public void ScoreCalculation()
    {
        float a = StartingTime / 4
            , b = StartingTime / 3
            , c = StartingTime - (StartingTime / 4)
            , d = StartingTime;
        TimeTaken = StartingTime - remaingTime;
        int minutes = Mathf.FloorToInt(TimeTaken / 60);
        int second = Mathf.FloorToInt(TimeTaken % 60);
        TimeScore.text = string.Format("{0:00}:{1:00}", minutes, second);
        if (TimeTaken <= a)
        {
            Score.text = "A";
        }
        else if (TimeTaken <= b)
        {
            Score.text = "B";
        }
        else if (TimeTaken <= c)
        {
            Score.text = "C";
        }
        else if (TimeTaken <= d)
        {
            Score.text = "D";
        }

    }
    IEnumerator StartBeefingCat()
    {
        yield return new WaitForSeconds(5);
        StartBeefing.SetActive(false);

    }

    public void RestartGame() {
        // Get the active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Reload the current scene
        SceneManager.LoadScene(currentScene.name);
    }

}

