﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private float velocidadX = 2;
    private float velocidadY = -1.1f;
    private float velocidadDisparo = 2;
    [SerializeField] Transform prefabDisparoEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disparar());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidadX * Time.deltaTime, velocidadY * Time.deltaTime, 0);

        if ((transform.position.x < -4) || (transform.position.x > 4))
            velocidadX = -velocidadX;
        if ((transform.position.y < -2.5) || (transform.position.y > 2.5))
            velocidadY = -velocidadY;
    }

    // For the Enemy to shoot
    IEnumerator Disparar()
    {
        float pausa = Random.Range(5.0f, 8.0f);
        //i dont get this
        yield return new WaitForSeconds(pausa);
        Transform disparo = Instantiate(prefabDisparoEnemigo, transform.position, Quaternion.identity);
        //neither this
        disparo.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, velocidadDisparo, 0);
        StartCoroutine(Disparar());
    }
}
