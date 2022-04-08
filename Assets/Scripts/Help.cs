using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public Transform[] photos;
    int i = 0;
     void OnMouseDown()
    {
        if(i<3)
        {
            photos[i].gameObject.SetActive(true);
            i++;
        }
    }
}
