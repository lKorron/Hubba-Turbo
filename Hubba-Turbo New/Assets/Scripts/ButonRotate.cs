using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ButonRotate : MonoBehaviour
{
    [SerializeField] float speed;
   

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * speed);
    }
}
