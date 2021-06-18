using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodOnFire : MonoBehaviour

/* 익힌 고기와 탄 고기가 이 스크립트를 공유할 것이다. */
{
    [SerializeField]
    int time1; // 익는 시간
    [SerializeField]
    int time2; // 타는 시간
    float currentTime; // 업데이트해 나갈 시간. time 에 도달시킬 것.

    private bool done; // 끝났으면 더 이상 불에 있어도 계산 무시할 수 있게끔

    [SerializeField]
    private Material go_Cooked_Material1;
    [SerializeField]
    private Material go_Cooked_Material2;
    private GameObject go_CookedItem_Prefab; // 익혀진 혹은 탄 고기 아이템 교체


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
                // Destroy(gameObject); // 날고기인 자기 자신은 파괴
            }
            else if (currentTime >time2)
            {
                done = true;
                gameObject.GetComponent<Renderer>().material = go_Cooked_Material2;
            }
        }
    }
}
