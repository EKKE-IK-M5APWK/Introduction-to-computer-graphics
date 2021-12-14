using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] Transform targetTemplate;
    [SerializeField] bool gotHit;
    // Start is called before the first frame update
    void Start()
    {
        targetTemplate.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        gotHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gotHit)
        {
            System.Random r = new System.Random();
            int s = r.Next(1, 5);
            Debug.Log(s);
            switch (s)
            {
                case 1:
                    targetTemplate.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
                    break;
                case 2:
                    targetTemplate.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
                    break;
                case 3:
                    targetTemplate.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                    break;
                case 4:
                    targetTemplate.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.yellow);
                    break;
                default:
                    targetTemplate.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                    break;
            }

        }
        gotHit = false;

    }
    public void hitTarget()
    {
        gotHit = true;
    }

}
