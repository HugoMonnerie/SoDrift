using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    [SerializeField] GameObject m_Car;

    void Awake(){
     m_Rigidbody = GetComponent<Rigidbody>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other){
        //Debug.Log("collision piece");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
