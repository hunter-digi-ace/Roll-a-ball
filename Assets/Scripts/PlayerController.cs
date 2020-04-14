using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //faltaba un reference para que funcionara: https://forum.unity.com/threads/missing-unityengine-ui.735755/

public class PlayerController : MonoBehaviour{
    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private int count;
    void Start(){
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement*speed);
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag ("PickUp")){
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();
        }
    }
    
    void SetCountText(){
        countText.text = "Countador: " + count.ToString();
        if (count >= 12){
            winText.text = "Has ganado!";
        }
    }
}