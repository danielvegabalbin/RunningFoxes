using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class ControlScene : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI puntosTXT;
    public GameObject jugador;
    public Camera camaraJuego;

    public GameObject[] bloquePrefab;
    public float punteroJuego;
    public float lugarGeneracion = 12;
    

    private bool perdiste = false;
    private bool ganaste = false;
    Score score;
    Coin coin;

    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject wonPanel;
    [SerializeField] GameObject LosePanel;


    void Start()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        score = GameObject.FindGameObjectWithTag("ScoreGO").GetComponent<Score>();
        punteroJuego = -7;
    }

    void Update()
    {

        if (jugador != null)
        {
            camaraJuego.transform.position = new Vector3(jugador.transform.position.x, camaraJuego.transform.position.y, camaraJuego.transform.position.z);
            puntosTXT.text = "Puntos = " + Mathf.Floor(jugador.transform.position.x);

            if (score.score >= 5)
            {
                ganaste = true;
                Gana();
            }
        }
        else
        {
            if (!perdiste )
            {
               perdiste = true;
               Pierde();
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
            PauseGame();
            wonPanel.SetActive(true);
            LosePanel.SetActive(false);
            
        }
        void Pierde()
        {
            PauseGame();
            wonPanel.SetActive(false);
            LosePanel.SetActive(true);

        }

        void PauseGame()
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }

    }
}