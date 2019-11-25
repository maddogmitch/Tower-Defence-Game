using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScaler : MonoBehaviour
{
    public float scaleSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.localScale += (new Vector3(scaleSpeed, scaleSpeed, 
        scaleSpeed) * Time.deltaTime);
    }

    public static Quaternion SmoothlyLook(Transform fromTransform, 
    Vector3 toVector3)
    {
        if (fromTransform.position == toVector3)
        {
            return fromTransform.localRotation;
        }

        Quaternion currentRotation = fromTransform.localRotation;
        Quaternion targetRotation = Quaternion.LookRotation(toVector3 - 
        fromTransform.position);

        return Quaternion.Slerp(currentRotation, targetRotation, 
        Time.deltaTime * 10f);
    }
}
