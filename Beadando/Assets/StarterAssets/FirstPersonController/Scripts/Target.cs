using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] Transform targetTemplate;
    [SerializeField] bool gotHit;
    private float duration;
    // Start is called before the first frame update
    void Start()
    {
        targetTemplate.GetComponent<MeshRenderer>().material.SetColor("_Color", generateColor());
        gotHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gotHit)
        {
            targetTemplate.GetComponent<MeshRenderer>().material.SetColor("_Color", generateColor());
        }
        gotHit = false;
    }

    public void hitTarget()
    {
        gotHit = true;
    }

    private Color generateColor()
    {
        System.Random r = new System.Random();
        int s = r.Next(1, 5);
        Debug.Log(s);
        switch (s)
        {
            case 1:
                return Color.blue;
            case 2:
                return Color.red;
            case 3:
                return Color.green;
            case 4:
                return Color.yellow;
            default:
                return Color.white;
        }
    }


}
