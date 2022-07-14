using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverandRotate : MonoBehaviour
{
    [Header("Hovering Info")]
    public bool hover;
    public float heightChange = 0.1f;
    public float verticleSpeed = 1.5f;

    [Header("Rotation Info")]
    public bool rotate;
    public float rotationSpeed = 0.75f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (hover)
        {
            float newY = Mathf.Sin(Time.time * verticleSpeed) * heightChange + startPos.y;
            transform.position = new Vector3(startPos.x, newY, startPos.z);
        }
        if (rotate)
        {
            transform.Rotate(new Vector3(0, rotationSpeed));
        }
    }
}
