using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float mov;
    // Use this for initialization
    void Start()
    {
        transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
		ShipMovement();
    }
    private void ShipMovement()
    {
        float movHor = Input.GetAxis("Horizontal");
        float movVer = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(movHor, movVer) * mov * Time.deltaTime);


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
}
