using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : MonoBehaviour
{
    private AudioSource curaSonido;
    public  AudioClip sonidoVida;

    void Start(){
        //camara.main si va
        curaSonido = Camera.main.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<JohnMovement>().Curar(1);
            curaSonido.PlayOneShot(sonidoVida, 1.0f);
            Destroy(gameObject);
        }
    }
}
