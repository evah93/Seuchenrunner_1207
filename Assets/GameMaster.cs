using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [SerializeField] public int m_Life = 3;
    //public int collCounter;
    //public Text scoreText;


    public static GameMaster gm;
    public static Text livesText;

    void Start()
    {
        //collCounter = 0;
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }
    public Transform playerPrefab;
    public Transform spawnPoint;

    public static void CheckPoint(Transform checkpoint)
    {
        gm.spawnPoint = checkpoint;
    }

    public void RespawnPlayer()
    {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    public static void KillPlayer(GameObject player)
    {
        Destroy(player.gameObject);
        gm.m_Life -= 1;
        Debug.Log("Er hat " + gm.m_Life);
        livesText = GameObject.Find("LivesText").GetComponent<Text>();  //Anzeige die Anzahl der Leben;
        livesText.text = "Lives: " + gm.m_Life;                         // Ein Leben weg;

        if (gm.m_Life == 0)
        {
            Debug.Log("GameOver");                                      // Fangen wir das Spiel von vorne;
            SceneManager.LoadScene("GameOver");
        }
        gm.RespawnPlayer();

    }

    /*public static void IncrementScore (GameObject other)
        if (other.tag == "Collectible")
        {
            collCounter++;
            SoundManager.PlaySound("coins");                //Musik bei Sammeln der Münzen ;
            Destroy(other.gameObject);
            scoreText.text = "Score: " + collCounter.ToString();
            Debug.Log("Score: " + collCounter);

        }
        else
        {
            return;
        }

        if(other.tag == "Levelende")
        {
            if(m_Life == 3)
            {
                collCounter =+ 10;
                scoreText.text = "Bonus! New score: " + collCounter.ToString();
                Debug.Log("Score: " + collCounter);
            }

            else
            {
                return;
            }
        }
        else
        {
            return;
        }*/
}

