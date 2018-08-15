using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private AudioClip _powerUpSound;
    
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -7){
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (this.CompareTag("tripleShot"))
                {
                    player.TripleShotPowerUpOn();
                }
                else if (this.CompareTag("speedPowerup"))
                {
                    player.SpeedPowerUpOn();
                }
                else if (this.CompareTag("shieldPowerUp"))
                {   
                    player.ShieldPowerUpOn();

                }
                AudioSource.PlayClipAtPoint(_powerUpSound, Camera.main.transform.position);
                Destroy(this.gameObject);
            }
        }
    }
}
