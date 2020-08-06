using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int startSpeed = 100;
    public int speedUp = 300;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * startSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * speedUp * Time.deltaTime);
    }
}
