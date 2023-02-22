using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public int speed = 1; //tahtanin donus hizi

    private void FixedUpdate()
    {
        //tahtayi dondurme islemi
        transform.Rotate(0f, speed * Time.deltaTime, 0f);
    }
}
