using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chagecolor : MonoBehaviour
{
    [SerializeField]
    private GameObject meat;



    private Renderer meatRenderer;

    [SerializeField]
    private float time; // �����ų� Ÿ�µ� �ɸ��� �ð�
    private float currentTime; // ������Ʈ�� ���� �ð�. time �� ���޽�ų ��.

    private bool done; // �������� �� �̻� �ҿ� �־ ��� ������ �� �ְԲ�

    [SerializeField]
    private GameObject go_CookedItem_Prefab; // ������ Ȥ�� ź ��� ������ ��ü


    void Start()
    {
        meatRenderer = meat.GetComponent<Renderer>();
        gameObject.GetComponent<Physicsbtn>().onPressed1.AddListener(ChangeMeatTexture);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.transform.tag == "Fire" && !done)
       // {

//        }



       if (other.CompareTag("Meat") && !done)
        {
            

            currentTime += Time.deltaTime;

          //  if (currentTime >= time)
         //   {
                done = true;
                Instantiate(go_CookedItem_Prefab, transform.position, Quaternion.Euler(transform.eulerAngles));

               // meatRenderer.material.color = Color.black;

                Destroy(gameObject); // ������� �ڱ� �ڽ��� �ı�
          //  }

        }
    }
    private void ChangeMeatTexture()
    {
        
    }

    void Update()
    {

    }
}
