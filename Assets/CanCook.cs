using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanCook : MonoBehaviour
{

    public bool canCook = false;
    GameObject firstCollidedObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (!canCook && collision.transform.parent)
        {
            firstCollidedObject = collision.collider.transform.parent.gameObject;
            canCook = OnOven(collision.collider.transform.parent);
        }
    }

    bool OnOven(Transform parent)
    {
        bool isPlate = false;
        while (parent != null)
        {
            if (parent.GetComponent<HotPlate>())
            {
                HotPlate hotPlate = parent.GetComponent<HotPlate>();
                if (hotPlate.plates.name == firstCollidedObject.name && hotPlate.activePlateIndices)
                {
                    isPlate = true;
                    return isPlate;
                }
            }
            parent = parent.transform.parent;
        }
        return isPlate;
    }

    public bool GetCanCook()
    {
        return canCook;
    }
}
