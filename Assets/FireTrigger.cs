using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool cook = gameObject.transform.parent.GetComponent<CanCook>().canCook;
        if (cook == true)
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
        else
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
