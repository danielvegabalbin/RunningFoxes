using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlScene : MonoBehaviour
{
    public GameObject jugador;
    public Camera camaraJuego;

    public GameObject[] bloquePrefab;
    public float punteroJuego;
    public float lugarGeneracion = 12;
    public Text textoJuego;
    public bool perdiste;
    public bool ganaste;
    Score score;
    Coin coin;

    public GameObject pausePanel;
    public GameObject wonPanel;
    public GameObject LosePanel;


    void Start()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        score = GameObject.FindGameObjectWithTag("ScoreGO").GetComponent<Score>();
        punteroJuego = -7;
        perdiste = false;
        ganaste = false;

    }

    void Update()
    {
        #region RestartGame
        if (Input.GetKeyDown(KeyCode.R))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        #endregion

        if (jugador != null)
        {
            camaraJuego.transform.position = new Vector3(jugador.transform.position.x, camaraJuego.transform.position.y, camaraJuego.transform.position.z);
            textoJuego.text = "Puntos= " + Mathf.Floor(jugador.transform.position.x);

            if (score.score >= 5)
            {
                ganaste = true;
                Gana();
            }
        }

        else
        {
            if ( !perdiste )
            {
                perdiste = true;
                PauseGame();
                wonPanel.SetActive(false);
                LosePanel.SetActive(true);

            }
           
        }
        



        while (jugador != null && punteroJuego < jugador.transform.position.x + lugarGeneracion)
        {
            int indiceBloque = Random.Range(0, bloquePrefab.Length - 1);

            if ( punteroJuego<0)
            {
                indiceBloque = 2;
            }

            GameObject ObjetoBLoque = Instantiate(bloquePrefab[indiceBloque]);
            ObjetoBLoque.transform.SetParent(this.transform);
            Bloque bloque = ObjetoBLoque.GetComponent<Bloque>();
            ObjetoBLoque.transform.position = new Vector2(punteroJuego + bloque.tamaño / 2, 0);
            punteroJuego += bloque.tamaño;  
        }
        void Gana()
        {
            Debug.Log("Ganoooooooo ");
            PauseGame();
            wonPanel.SetActive(true);
            LosePanel.SetActive(false);
            
        }
        void PauseGame()
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }

    }
}