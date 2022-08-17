using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AndroidBehaviour : MonoBehaviour {

    private Touch touch;

    public GameObject fractured;
    public GameObject NewPrefab;
    public GameObject EnemyBall;
 
    
    private Rigidbody androidooRigidbody;
   

    public Sprite lostHPSprite;
    public Sprite heartSprite;
    public Image[] Hearts;

    public static float timeRemaining;
    public float LoadScreenDelayTime;
    public bool LoadScreenDelayTimeIsRunning = false;
    public static bool timerIsRunning;

    public static int points;
    private int currentHealth;



    void Start()
    {
        timerIsRunning = false;

        currentHealth = 5;

        switch (LevelSelect.Level)
        {
            case "Easy":
                timeRemaining = 40;
                break;

            case "Medium":
                timeRemaining = 30;
                break;

            case "Hard":
                timeRemaining = 20;
                break;
        }


        androidooRigidbody = this.GetComponent<Rigidbody>();


        points = 0;
    }



    // Update is called once per frame
    void Update() 
	{
        
        GetComponent<Animator>().enabled = false;


        androidooRigidbody.Sleep();


        AndroidooHealthManagement();
        
        AndroidooMovement();

        TimeManagement();

        LoadScoreScreen();
    }

    void OnCollisionEnter(Collision collision)
    {
        var Ballposition = new Vector3(Random.Range(-0.5f, 0.6f), 0.07f, Random.Range(-0.9f, 0.7f));
        var Boxposition = new Vector3(Random.Range(-0.600f, 0.6f), 0.296f, Random.Range(-1.150f, 1.050f));

        switch (collision.gameObject.tag)
        {
            case "BoxyDestroyToPieces":
                if (points == 0)
                    timerIsRunning = true;

                Destroy(collision.gameObject);
                Instantiate(fractured, transform.position, transform.rotation);

                Instantiate(NewPrefab, Boxposition, Quaternion.identity);
          

               if(LevelSelect.Level == "Medium" || LevelSelect.Level == "Hard")
                {
                    if (points % 4 == 0)
                        Instantiate(EnemyBall, Ballposition, Quaternion.identity);
                }

                points++;
                break;

            case "EnemyBall":
                Destroy(collision.gameObject);
                currentHealth--;

                if (currentHealth == 0)
                {
                    SceneManager.LoadScene("GameOverScene");
                }

                Instantiate(EnemyBall, Ballposition, Quaternion.identity);
                break;

            case "EnemyGhost":
                Destroy(collision.gameObject);


                if (points >= 2)
                {
                    points = points - 2;
                }

                else if (points == 1)
                    points--;

                break;



            case "SuperStar":
                Destroy(collision.gameObject);
                points += 10;
                break;
        }
    }

    public void TimeManagement()
    {
        if (timerIsRunning)
        {

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                LoadScreenDelayTimeIsRunning = true;
                androidooRigidbody.constraints = RigidbodyConstraints.FreezePosition;
                timeRemaining = 0;
            }
        }
    }

    public void LoadScoreScreen()
    {

        if (LoadScreenDelayTimeIsRunning)
        {
            if (LoadScreenDelayTime > 0)
            {
                LoadScreenDelayTime -= Time.deltaTime;
            }
            else
            {
                LoadScreenDelayTime = 0;
                LoadScreenDelayTimeIsRunning = false;


                SceneManager.LoadScene("GameOverScene");
            }
        }
    }

    public void AndroidooMovement()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);



                if (timeRemaining > 0)
                    GetComponent<Animator>().enabled = true;



                float move_x = touch.deltaPosition.x;
                float move_y = touch.deltaPosition.y;
                float move_z = touch.deltaPosition.y;



                Vector3 movement = new Vector3(move_x * 0.002f, move_y * 0.002f, move_z * 0.002f);

                Vector3 actualDirection = Camera.main.transform.TransformDirection(movement);

                androidooRigidbody.velocity = actualDirection * 30.0f;


                Quaternion rotation = Quaternion.LookRotation(androidooRigidbody.velocity); //LookRotation(Vector3)
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 4.5f);
        }
    }

    public void AndroidooHealthManagement()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < currentHealth)
                Hearts[i].sprite = heartSprite;
            else
                Hearts[i].sprite = lostHPSprite;

        }
    }
}
