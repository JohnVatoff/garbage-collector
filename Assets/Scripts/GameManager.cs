using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Player
    public static GameObject player;
    public static GameObject helmet;
    public static GameObject gameMenu;
    private GameObject trashRondom;
    public GameObject perlConch; //Bonus 10%
    public GameObject perlShell;
    public GameObject perlSnail;

    public GameObject trashBanana; //Bonus 60%
    public GameObject trashApple;
    public GameObject trashEgg;
    public GameObject trashCola;
    public GameObject mine;

    public GameObject trashInk; //Bonus 25%
    public GameObject trashPoison;
    public GameObject trashBottle;
    public GameObject trashPvcBottle;
    public GameObject trashPaper;

    public GameObject trashMetalHead; //Bonus 10%
    public GameObject trashRobotHead;

    public GameObject whale; //Bonus 5%
    public GameObject explosion;
    public GameObject deadPlayer;

    public List<GameObject> trashItems10persent = new List<GameObject>();
    public List<GameObject> trashItems25persent = new List<GameObject>();
    public List<GameObject> trashItems60persent = new List<GameObject>();

    int uRand;
    //Sound Effects
    static AudioSource source;
    public AudioClip pickupSound;
    public AudioClip explosionSound;
    public AudioClip damageSound;
    public AudioClip bonusSound;
    public AudioClip timeSound;
    public AudioClip helmetSound;

    public Text pointsText;
    public Text timeText;
    static int points;
    static bool isGameOver = false;
    static bool isStunned = false;
    static bool isHitted = false;
    static bool isHelmProtected = false;
    static bool isPause = false;
    //Timers
    static float time = 300;
    static float hyperStun = 0;
    static float hitStun = 0;
    static float helmetTime = 0;
    static float bonusTime = 0;          






    System.Random rnd;
    int Seed;

    public GameObject trash;
    float respawn = 4.0f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        helmet = GameObject.FindGameObjectWithTag("Helmet");
        gameMenu = GameObject.FindGameObjectWithTag("GameMenu");

        AddItemsToList();
        points = 0;
        source = GetComponent<AudioSource>();
        helmet.SetActive(false);
        gameMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            Debug.Log("Show Menu");
            if(isPause)
            {
                isPause = false;
                gameMenu.SetActive(false);
            }
            else
            {
                isPause = true;
            }
        }
        if (!isGameOver && !isPause)
        {
            respawn -= Time.deltaTime;
            if (respawn < 0)
            {

                Instantiate(RandomGameObjectTrash(), new Vector2(Random.Range(-8, 8), 2), Quaternion.identity);
                respawn = Random.Range(1, 3);
                if (bonusTime > 0)
                {
                    respawn = respawn / 3;
                }
            }

            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                isGameOver = true;
            }
            if (hitStun > 0)
            {
                hitStun -= Time.deltaTime;
            }
            else if (isHitted)
            {
                player.GetComponent<PlayerController>().ReleaseDammage();
                isHitted = false;
            }
            if (bonusTime > 0)
            {
                bonusTime -= Time.deltaTime;
            }
            if (helmetTime > 0)
            {
                helmetTime -= Time.deltaTime;
            }
            else if (isHelmProtected)
            {
                helmet.SetActive(false);
                isHelmProtected = false;
            }

            if (hyperStun > 0)
            {
                hyperStun -= Time.deltaTime;
            }
            else if (isStunned)
            {
                player.SetActive(true);
                player.GetComponent<PlayerController>().speed = 0;
                isStunned = false;
            }
        }
        else
        {
            //show menu
            gameMenu.SetActive(true);
        }
    }

    void LateUpdate()
    {
        pointsText.text = "Points: " + points.ToString();
       // int timeInt = (int)time;
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = (time % 60).ToString("00");

        timeText.text = "Time: " + minutes + ":"+ seconds;
    }

    public void PickUp(int p)
    {
        points+=p;
        source.PlayOneShot(pickupSound, 1);
    }

    public void AddTime()
    {
        time += 20;
        source.PlayOneShot(timeSound, 1);
    }

    public void BonusTime()
    {
        bonusTime += 20;
        source.PlayOneShot(bonusSound, 1);
    }

    public void AddHelmet()
    {
        isHelmProtected = true;
        Debug.Log(helmetTime);
        helmetTime += 20;
        helmet.SetActive(true);
        source.PlayOneShot(helmetSound, 1);
    }

    public void TakeDammage(int p)
    {
        if (helmetTime > 0)
        {
            points += p;
            source.PlayOneShot(pickupSound, 1);
        }
        else
        {
            player.GetComponent<PlayerController>().GetDammage();
            isHitted = true;
            hitStun = 1;
            source.PlayOneShot(damageSound, 1);
        }
        
    }

    public void GroundExplosion(float x, float y)
    {
        Instantiate(explosion, new Vector2(x, y+1), Quaternion.identity);
        source.PlayOneShot(explosionSound, 0.5f);
    }

    public void PlayerExplosion()
    {
        hyperStun = 10f;
        Instantiate(explosion, new Vector2(player.transform.localPosition.x, player.transform.localPosition.y), Quaternion.identity);
        source.PlayOneShot(explosionSound, 0.5f);
       
        if (helmetTime <= 0)
        {
            Instantiate(deadPlayer, new Vector3(player.transform.localPosition.x, player.transform.localPosition.y - 1, 1), Quaternion.identity);
            player.SetActive(false);
            hyperStun = 10f;
            isStunned = true;
        }
    }

    void AddItemsToList()
    {
        trashItems10persent.Add(perlConch);
        trashItems10persent.Add(perlShell);
        trashItems10persent.Add(perlSnail);

        trashItems25persent.Add(trashInk);
        trashItems25persent.Add(trashPoison);
        trashItems25persent.Add(trashBottle);
        trashItems25persent.Add(trashPvcBottle);
        trashItems25persent.Add(trashMetalHead);
        trashItems25persent.Add(trashRobotHead);

        trashItems60persent.Add(trashBanana);
        trashItems60persent.Add(trashApple);
        trashItems60persent.Add(trashEgg);
        trashItems60persent.Add(trashCola);
        trashItems60persent.Add(mine);
    }

    private GameObject RandomGameObjectTrash()
    {
        int randomIndex;
        Seed = (int)System.DateTime.Now.Ticks;
        rnd = new System.Random(Seed);

        uRand = Random.Range(0, 100);

        if (uRand < 5)
        {
            trash = whale;
        }
        else if (uRand <= 15)
        {
            randomIndex = rnd.Next(trashItems10persent.Count);
            trash = trashItems10persent[randomIndex];
        }
        else if (uRand <= 50)
        {
            randomIndex = rnd.Next(trashItems25persent.Count);
            trash = trashItems25persent[randomIndex];
        }
        else
        {
            randomIndex = rnd.Next(trashItems60persent.Count);
            trash = trashItems60persent[randomIndex];
        }
        return trash;
    }

    public void restartLevel()
    {
        time = 300;
        SceneManager.LoadScene("LoadingScene");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
