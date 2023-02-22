using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{

    public float speed = 5f; // bicagin gidis hizi
    private Rigidbody myBody;
    private bool onWood; //tahtaya saplandi mi sorgusu

    private KnifeSpawner knifeSpawner; //birazdan bicak spawn icin olusturulacak

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>(); // Rigidbody'i instance ettik
        knifeSpawner = GameObject.Find("Knife Spawner").GetComponent<KnifeSpawner>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !onWood)
        {
            myBody.velocity = new Vector3(0f, speed, 0f); //hareket islemi
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wood"))
        {
            myBody.velocity = Vector3.zero; //bicagin hareketini durdur
            onWood = true; //tahtaya saplandi islemi.(update icindeki input calismaz)
            gameObject.transform.SetParent(other.transform); // bicak, tahta ile birlikte donsun diye
            myBody.detectCollisions = false; //bicagin tahta ile olan temasini kontrol etmeyi birak

            knifeSpawner.SpawnKnife();
            knifeSpawner.IncrementScore();


        }
        else if (other.CompareTag("Knife"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }






}
