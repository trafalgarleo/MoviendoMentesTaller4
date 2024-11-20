using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class MoveUltrasVeloc : MonoBehaviour
{
    // Start is called before the first frame update
    public float vel = 1.5f;
    public int reversa = 1;
    //public float vel2 = 1.5f;


    private int rapidez;
    private int proximidad;
    //private int reversa=1;

    SerialPort puerto = new SerialPort("COM3", 9600);

    //float distanciaMov;

    //SerialPort puerto = new SerialPort("/dev/cu.usbmodem1461", 9600);

    // Use this for initialization
    void Start()
    {
        puerto.Open();
        puerto.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //distanciaMov = vel * Time.deltaTime;

        if (puerto.IsOpen == true)
        {
            try
            {
                mover(puerto.ReadLine());
                print(puerto.ReadLine());
            }
            catch (System.Exception)
            {

            }
        }
    }

    void mover(string datoArduino)  //"data1,data2"
                                    //  0      1    
                                    //datosArray[0] = "data1"
                                    //datosArray[1] = "data2"
    {
        string[] datosArray = datoArduino.Split(char.Parse(","));

        if (datosArray.Length == 2)
        {
            rapidez = int.Parse(datosArray[0]);   //data1 = "data1"
            proximidad = int.Parse(datosArray[1]);  //data2  = "data2"
            print(rapidez + "   " + proximidad);
        }


        //if (proximidad <= 15)
        if (proximidad >= 15)
        {
            reversa = -1;
        }
        else
        {
            reversa = 1;
        }
        if (rapidez != 0)
        {
            //Space.Self Space.World
            transform.Translate(Vector3.forward * ((rapidez * reversa) * vel), Space.Self);
        }
        /*else {
        
            transform.Translate(Vector3.down * vel, Space.Self);
        }
        */

    }
}
