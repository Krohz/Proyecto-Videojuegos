using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPausado : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] public GameObject Menupausa;

    private bool juegoPausado = false;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(juegoPausado){
                Reanudar();
            }else{
                Pausa();
            }
        }
    }
    public void Pausa(){
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        Menupausa.SetActive(true);
    }

    public void Reanudar(){
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        Menupausa.SetActive(false);
    }

    public void Reiniciar(){
        juegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Cerrar(){
        Debug.Log("Juego Cerrado...");
        Application.Quit();
    }
}
