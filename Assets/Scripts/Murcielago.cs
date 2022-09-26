using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielago : MonoBehaviour
{
    [SerializeField] public Transform jugador;

    [SerializeField] private float distancia;

    public Vector3 puntoInicial;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    private int Health = 2;

    private AudioSource muerteSonido;
    public  AudioClip SonidoMuerte;


    
    private void Start() {
        animator = GetComponent<Animator>();
        puntoInicial = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        muerteSonido = Camera.main.GetComponent<AudioSource>();
    }

    private void Update(){
        distancia = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("Distancia", distancia);
    }

    public void Girar(Vector3 objetivo){
        if (transform.position.x <objetivo.x)
        {
            spriteRenderer.flipX = true;
        }else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<JohnMovement>().Hit();
        }
    }

        public void Hita(){
        Health -= 1;
        if (Health == 0) {
            Destroy(gameObject);
            muerteSonido.PlayOneShot(SonidoMuerte, 0.6f);
        }
    }
}
