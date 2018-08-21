using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{

    [SerializeField]
    private GameObject _laser;
    [SerializeField]
    private float _mov = 8.0f;
    [SerializeField]
    private GameObject myExplosion;
    [SerializeField]
    public GameObject _shieldPlayer;
    [SerializeField]
    private float _fireRate = 0.40f;
    private float _nextFire = 0.0f;
    public bool canTripleShot = false;
    public bool canSpeedUp = false;
    public bool canShield = false;
    public int lifePoints = 3;
    public int lifePointsP2 = 3;
    public UI_Manager uiManager;
    public GameManager gameManager;
    public SpawnManager spawnManager;
    private AudioSource _laserShoot;
    public GameObject[] enginesFire;
    public int hitCount = 0;
    [SerializeField]
    private int _randomEngineDamage;

    private int finishGameCount = 0;
    void Start()
    {

        _randomEngineDamage = Random.Range(0, 2);

        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _laserShoot = GetComponent<AudioSource>();
        if (uiManager != null)
        {
            uiManager.UpdateLives(lifePoints);
            uiManager.UpdateLivesP2(lifePointsP2);
        }
        SingleOrCoop(gameManager.CheckGameMode());
        spawnManager.startMyGame();
        hitCount = 0;

        lifePoints = 3;
        lifePointsP2 = 3;
    }
    void Update()
    {
        if (this.gameObject.name == "Player_1(Clone)")
        {

            ShipMovement();

            if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && Time.time >= _nextFire)
            {
                ShootLaser();
            }
            /*#if UNITY_ANDROID
                        if ((CrossPlatformInputManager.GetButtonDown("Shoot")) && Time.time >= _nextFire)
                        {
                            ShootLaser();
                        }
            #endif */
        }
        else if (this.gameObject.name == "Player_2(Clone)")
        {
            ShipMovementP2();

            if ((Input.GetKey(KeyCode.RightShift) || Input.GetMouseButton(1)) && Time.time >= _nextFire)
            {
                ShootLaserP2();
            }
        }
    }
    private void SingleOrCoop(string checkGame)
    {
        checkGame = gameManager.CheckGameMode();
        Debug.Log("My game mode is now: " + checkGame);
        if (checkGame == "Single-Player")
        {
            transform.position = new Vector2(0, 0);
        }
        else if (checkGame == "Co-Op")
        {
            if (this.gameObject.name == "Player_1")
            {
                this.gameObject.transform.position = new Vector2(5, 0);
                Debug.Log("I'm player one!" + transform.position);
            }
            if (this.gameObject.name == "Player_2")
            {
                this.gameObject.transform.position = new Vector2(-5, 0);
                Debug.Log("I'm player two!" + transform.position);
            }
        }
    }
    private void ShipMovement()
    {
        float movHor = Input.GetAxis("Horizontal");
        float movVer = Input.GetAxis("Vertical");


        if (canSpeedUp == false)
        {
            transform.Translate(new Vector2(movHor, movVer) * _mov * Time.deltaTime);
        }
        else if (canSpeedUp == true)
        {
            transform.Translate(new Vector2(movHor, movVer) * _mov * 1.75f * Time.deltaTime);
        }





        //Y
        if (transform.position.y <= -4.2f)
        {
            transform.position = new Vector2(transform.position.x, -4.2f);
        }
        else if (transform.position.y >= 0)
        {
            transform.position = new Vector2(transform.position.x, 0f);
        }



        //X
        if (transform.position.x > 9.4f)
        {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
            Debug.Log("Passei pra direita");
        }
        else if (transform.position.x < -9.4f)
        {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
            Debug.Log("Passei pra esquerda");
        }
    }


    private void ShipMovementP2()
    {



        if (canSpeedUp == false)
        {
            if (Input.GetKey(KeyCode.Keypad8))
            {
                transform.Translate(Vector2.up * _mov * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad4))
            {
                transform.Translate(Vector2.left * _mov * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad6))
            {
                transform.Translate(Vector2.right * _mov * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad5))
            {
                transform.Translate(Vector2.down * _mov * Time.deltaTime);
            }
        }
        else if (canSpeedUp == true)
        {
            if (Input.GetKey(KeyCode.Keypad8))
            {
                transform.Translate(Vector2.up * _mov * 1.75f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad4))
            {
                transform.Translate(Vector2.left * _mov * 1.75f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad6))
            {
                transform.Translate(Vector2.right * _mov * 1.75f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad5))
            {
                transform.Translate(Vector2.down * _mov * 1.75f * Time.deltaTime);
            }
        }





        //Y
        if (transform.position.y <= -4.2f)
        {
            transform.position = new Vector2(transform.position.x, -4.2f);
        }
        else if (transform.position.y >= 0)
        {
            transform.position = new Vector2(transform.position.x, 0f);
        }



        //X
        if (transform.position.x > 9.4f)
        {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
            Debug.Log("Passei pra direita");
        }
        else if (transform.position.x < -9.4f)
        {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
            Debug.Log("Passei pra esquerda");
        }
    }
    public void finishGame()
    {
        uiManager.title.gameObject.SetActive(true);
        if (gameManager != null)
        {
            gameManager.gameOver = true;
        }

    }
    public void Damage()
    {
        hitCount++;

        if (hitCount == 1 && _randomEngineDamage == 0)
        {
            enginesFire[0].SetActive(true);
        }
        if (hitCount == 2 && _randomEngineDamage == 0)
        {
            enginesFire[1].SetActive(true);
        }
        if (hitCount == 1 && _randomEngineDamage == 1)
        {
            enginesFire[1].SetActive(true);
        }
        if (hitCount == 2 && _randomEngineDamage == 1)
        {
            enginesFire[0].SetActive(true);
        }


    }
    public void ShipLife()
    {
        if (gameManager.CheckGameMode() == "Single-Player")
        {
            if (lifePoints < 1)
            {
                Instantiate(myExplosion, transform.position, Quaternion.identity);
                uiManager.ResetScore();
                finishGame();
                Destroy(this.gameObject);
            }
        }
        else if (gameManager.CheckGameMode() == "Co-Op")
        {
            if (lifePoints < 1 && this.gameObject.name == "Player_1(Clone)" == true)
            {
                Instantiate(myExplosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                gameManager.finishGameCount++;
            }
            else if (lifePointsP2 < 1 && this.gameObject.name == "Player_2(Clone)" == true)
            {
                Instantiate(myExplosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                gameManager.finishGameCount++;
            }
            if (gameManager.finishGameCount == 2)
            {
                uiManager.ResetScore();
                finishGame();
            }
        }
    }
    private void ShootLaser()
    {
        _laserShoot.Play();
        if (canTripleShot == false)
        {
            Instantiate(_laser, new Vector3(transform.position.x, transform.position.y + 0.88f, 0), Quaternion.identity);
        }
        else if (canTripleShot == true)
        {
            Instantiate(_laser, new Vector3(transform.position.x, transform.position.y + 0.88f, 0), Quaternion.identity);
            Instantiate(_laser, new Vector3(transform.position.x + 0.555f, transform.position.y + 0.3f, 0), Quaternion.identity);
            Instantiate(_laser, new Vector3(transform.position.x - 0.555f, transform.position.y + 0.3f, 0), Quaternion.identity);
        }
        _nextFire = Time.time + _fireRate;
    }
    private void ShootLaserP2()
    {
        _laserShoot.Play();
        if (canTripleShot == false)
        {
            Instantiate(_laser, new Vector3(transform.position.x, transform.position.y + 0.88f, 0), Quaternion.identity);
        }
        else if (canTripleShot == true)
        {
            Instantiate(_laser, new Vector3(transform.position.x, transform.position.y + 0.88f, 0), Quaternion.identity);
            Instantiate(_laser, new Vector3(transform.position.x + 0.555f, transform.position.y + 0.3f, 0), Quaternion.identity);
            Instantiate(_laser, new Vector3(transform.position.x - 0.555f, transform.position.y + 0.3f, 0), Quaternion.identity);
        }
        _nextFire = Time.time + _fireRate;
    }
    public void TripleShotPowerUpOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }
    public void SpeedPowerUpOn()
    {
        canSpeedUp = true;

        StartCoroutine(SpeedDownRountine());
    }
    public void ShieldPowerUpOn()
    {
        canShield = true;
        _shieldPlayer.gameObject.SetActive(true);
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5);

        canTripleShot = false;
    }
    public IEnumerator SpeedDownRountine()
    {
        yield return new WaitForSeconds(5);
        canSpeedUp = false;
    }
}
