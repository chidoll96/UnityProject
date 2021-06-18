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
    private float time; // 익히거나 타는데 걸리는 시간
    private float currentTime; // 업데이트해 나갈 시간. time 에 도달시킬 것.

    private bool done; // 끝났으면 더 이상 불에 있어도 계산 무시할 수 있게끔

    [SerializeField]
    private GameObject go_CookedItem_Prefab; // 익혀진 혹은 탄 고기 아이템 교체


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

                Destroy(gameObject); // 날고기인 자기 자신은 파괴
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
