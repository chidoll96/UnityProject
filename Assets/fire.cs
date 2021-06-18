using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private string fireName;  // ���� �̸� (����, ��ں�, ȭ�Ժ�)
    [SerializeField] private int damage; // ���� ������

    [SerializeField] private float damageTime; // �������� �� ������ (�� �����Ӹ��ٰ� �ƴ� ���� �ð����� �������� �ֱ� ���Ͽ�)
    private float currentDamageTime;

    [SerializeField] private float durationTime;  // ���� ���� �ð�
    private float currentDurationTime;

    [SerializeField]
    private ParticleSystem ps_Flame;  // �� ��ƼŬ �ý���. ���ֱ� ���Ͽ�

    // ���� ����
    private bool isFire = true;


    void Start()
    {
        currentDurationTime = durationTime;

    }

    void Update()
    {
        if (isFire)
        {
            ElapseTime();
        }
    }

    private void ElapseTime()
    {
        currentDurationTime -= Time.deltaTime;

        if (currentDurationTime <= 0)
            Off();


        if (currentDamageTime > 0)
            currentDamageTime -= Time.deltaTime;  // 1�ʿ� 1��
    }

    private void Off()
    {
        ps_Flame.Stop();
        isFire = false;
    }

    public bool GetIsFire()
    {
        return isFire;
    }


}


