using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public UI_Manager uiManager;
    public GameManager gameManager;
    public SpawnManager spawnManager;


    void Start()
    {
        transform.position = new Vector2(0, 0);
        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (uiManager != null)
        {
            uiManager.UpdateLives(lifePoints);
        }
        spawnManager.startMyGame();
    }

    void Update()
    {
        ShipMovement();

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) && Time.time >= _nextFire)
        {
            ShootLaser();
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
    public void finishGame()
    {
        uiManager.title.gameObject.SetActive(true);
        if (gameManager != null)
        {
            gameManager.gameOver = true;
        }

    }
    public void ShipLife()
    {
        if (lifePoints < 1)
        {
            Instantiate(myExplosion, transform.position, Quaternion.identity);
            finishGame();
            Destroy(this.gameObject);
        }
    }
    private void ShootLaser()
    {
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
