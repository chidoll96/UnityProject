using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPlate : MonoBehaviour
{

    public GameObject plates;         // this oven has 4 hot plates
    public bool activePlateIndices = false;

    public GameObject canHeatObjectsOnMe;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // check if user switchs on or off one of plates
        plates.transform.GetChild(0).gameObject.SetActive(true);
        activePlateIndices = true;

        if (canHeatObjectsOnMe)
        {
            if (canHeatObjectsOnMe.GetComponent<CanCook>())
            {
                canHeatObjectsOnMe.GetComponent<CanCook>().canCook = true;
            }
        }
        else
        {
            plates.transform.GetChild(0).gameObject.SetActive(false);
            activePlateIndices = false;

            if (canHeatObjectsOnMe)
            {
                if (canHeatObjectsOnMe.GetComponent<CanCook>())
                {
                    canHeatObjectsOnMe.GetComponent<CanCook>().canCook = false;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CanCook>())
        {
            string name = collision.contacts[0].thisCollider.name;
            canHeatObjectsOnMe = collision.gameObject;
            canHeatObjectsOnMe.tag = "Fire";
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (canHeatObjectsOnMe == collision.gameObject)
        {
            canHeatObjectsOnMe.gameObject.tag = "NotFire";
            canHeatObjectsOnMe = null;
            if (collision.gameObject.GetComponent<CanCook>())
            {
                collision.gameObject.GetComponent<CanCook>().canCook = false;
            }
        }
    }
}
