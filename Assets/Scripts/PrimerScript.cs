using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimerScript : MonoBehaviour
{
    // Variables
    public int numeroEntero = 5; // Variable para numeros enteros

    private float numeroDecimal = 7.5f; // Variable para numeros con decimales

    bool boleana = true; // Variable verdadero o falso
    
    string cadenaTexto = "Hola, Mundo"; // Variable para poder poner texto

    // Start is called before the first frame update
    void Start()
    {
       Calculos();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void Calculos()
    {
         Debug.Log(numeroEntero); // Enseñar en la consola algún valor
        numeroEntero = 17;
        Debug.Log(numeroEntero);
        numeroEntero = 7 * 3; // Puedo hacer otras divisiones con + - * /
        Debug.Log(numeroEntero);
        numeroEntero ++; // Con ++ sumo 1 y con -- Resto 1
        numeroEntero -= 5; // Puedo sumar o restar el valor que yo quiera

    }

}
