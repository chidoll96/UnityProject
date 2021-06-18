using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodOnFire : MonoBehaviour

/* ���� ���� ź ��Ⱑ �� ��ũ��Ʈ�� ������ ���̴�. */
{
    [SerializeField]
    int time1; // �ʹ� �ð�
    [SerializeField]
    int time2; // Ÿ�� �ð�
    float currentTime; // ������Ʈ�� ���� �ð�. time �� ���޽�ų ��.

    private bool done; // �������� �� �̻� �ҿ� �־ ��� ������ �� �ְԲ�

    [SerializeField]
    private Material go_Cooked_Material1;
    [SerializeField]
    private Material go_Cooked_Material2;
    private GameObject go_CookedItem_Prefab; // ������ Ȥ�� ź ��� ������ ��ü


    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Fire" && !done)
        {
            currentTime += Time.deltaTime;

            Debug.Log(currentTime);
            if (currentTime > time1 && time2 > currentTime)
            {
                gameObject.GetComponent<Renderer>().material = go_Cooked_Material1;
                // Instantiate(go_CookedItem_Prefab, transform.position, Quaternion.Euler(transform.eulerAngles));
                // Destroy(gameObject); // ������� �ڱ� �ڽ��� �ı�
            }
            else if (currentTime >time2)
            {
                done = true;
                gameObject.GetComponent<Renderer>().material = go_Cooked_Material2;
            }
        }
    }
}
