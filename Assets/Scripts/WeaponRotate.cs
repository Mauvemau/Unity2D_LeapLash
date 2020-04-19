using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotate : MonoBehaviour
{
    [SerializeField]
    private int rotSpeed = 0;

    // Update is called once per frame
    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
        }
    }
}
