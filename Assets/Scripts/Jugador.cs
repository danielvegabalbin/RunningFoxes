using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public int fuerzaSalto;
    public int velocidadMovimiento;
    bool piso = false;
    

    private void OnTriggerEnter2D(Collider2D Col)
    {

        if (Col.tag == "Obstaculo" )
        {
            GameObject.Destroy(this. gameObject);
        }
        if (Col.tag == "Piso")
        {
            piso = true;
        }
        if (Col.gameObject.CompareTag("Coin"))
        {
            Destroy(Col.gameObject);
        }
    }
    private void OnTriggerStay2D (Collider2D c1)
    {
        if (c1.tag == "Piso")
        {
            piso = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        piso = false;
    }
    public void FixedUpdate()
    {


        if ((Input.GetKeyDown(KeyCode.Space) && piso)|| Input.GetKeyDown(KeyCode.A) && piso)
        {
            Jump();
        }
        

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadMovimiento, this.GetComponent<Rigidbody2D>().velocity.y);
    }
    void Jump()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, fuerzaSalto));

    }

}
