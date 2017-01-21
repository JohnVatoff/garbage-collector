using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Player
    public static GameObject player;
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

    public Text pointsText;
    public Text timeText;
    static int points;
    static float time = 300;
    bool isGameOver = false;
    static float hyperStun = 0;


    System.Random rnd;
    int Seed;

    public GameObject trash;
    float respawn = 4.0f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        AddItemsToList();
        points = 0;
        source = GetComponent<AudioSource>();
        //canvas.Find("ObjectName");
        //canvas.GetComponentInChildren(Text).GetComponent();
        //canvas.GetComponent<UnityEngine.UI.Text>().text = "alabala";
        //Instantiate(player, new Vector2(0, 0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            time -= Time.deltaTime;
            respawn -= Time.deltaTime;
            if (respawn < 0)
            {

                Instantiate(RandomGameObjectTrash(), new Vector2(Random.Range(-2, 6), 2), Quaternion.identity);
                respawn = Random.Range(2, 6);
            }
        }
    }

    void LateUpdate()
    {
        pointsText.text = "Points: " + points.ToString();
       // int timeInt = (int)time;
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = (time % 60).ToString("00");

        timeText.text = "Time: " + minutes + ":"+ seconds;

        if (hyperStun > 0)
            hyperStun -= Time.deltaTime;
        else
            player.SetActive(true);
    }

    public void PickUp(int p)
    {
        Debug.Log(points.ToString());
        points+=p;
        source.PlayOneShot(pickupSound, 1);
    }

    public void AddTime(float time)
    {

    }

    public void GroundExplosion(float x, float y)
    {
        Debug.Log(x);
        Debug.Log(y);
        Instantiate(explosion, new Vector2(x, y+1), Quaternion.identity);
        source.PlayOneShot(explosionSound, 0.5f);
    }

    public void PlayerExplosion()
    {
        Debug.Log("Player explosion");
        Instantiate(explosion, new Vector2(player.transform.localPosition.x, player.transform.localPosition.y), Quaternion.identity);
        source.PlayOneShot(explosionSound, 0.5f);
        player.SetActive(false);
        hyperStun = 10;
        Instantiate(deadPlayer, new Vector3(player.transform.localPosition.x, player.transform.localPosition.y-1, 1), Quaternion.identity);
    }

    void AddItemsToList()
    {
        trashItems10persent.Add(perlConch);
        trashItems10persent.Add(perlShell);
        trashItems10persent.Add(perlSnail);
        trashItems10persent.Add(trashMetalHead);
        trashItems10persent.Add(trashRobotHead);

        trashItems25persent.Add(trashInk);
        trashItems25persent.Add(trashPoison);
        trashItems25persent.Add(trashBottle);
        trashItems25persent.Add(trashPvcBottle);

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
        trash = mine;
        return trash;
    }
}
