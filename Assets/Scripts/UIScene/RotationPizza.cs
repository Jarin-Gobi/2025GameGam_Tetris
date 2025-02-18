using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPizza : MonoBehaviour
{
    public Vector3 spinRotatinoSpeed = new Vector3(0, 0, 180);

    private void FixedUpdate()
    {
        transform.eulerAngles += spinRotatinoSpeed * Time.deltaTime;
    }
}
