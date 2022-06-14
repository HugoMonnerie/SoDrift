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

    void OnCollisionEnter(Collision collision)
    {
        /*Destroy(gameObject);
        Car car = m_Car.GetComponent<Car>();
        car.incrementSpeed();*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
