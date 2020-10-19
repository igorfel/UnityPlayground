using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopCounter : MonoBehaviour
{
    [SerializeField]
    private float torqueSpeed = 40;

    [SerializeField]
    /// Quantas voltas o objeto deu
    private int loops = 0;

    [SerializeField, Range(0, 360)]
    /// Quanto o objeto tem que rodar até que conte como uma volta completa
    private float loopThreshold = 350;


    /// Habilita a contagem de voltas
    private bool canAddLoop = true;
    private Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            body.AddTorque(torqueSpeed);
        }
        
        if(transform.eulerAngles.z > loopThreshold && body.angularVelocity > 0 && canAddLoop) {
            loops += 1;
            canAddLoop = false;
        }

        if(!canAddLoop && transform.eulerAngles.z < loopThreshold) {
            canAddLoop = true;
        }
    }
}
