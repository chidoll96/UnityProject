using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Physicsbtn : MonoBehaviour
{

    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;


    private bool _isTriggered;


    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public UnityEvent onPressed1, onPressed2, onReleased;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1 && !_isTriggered)
            Pressed1();
        if (_isPressed && GetValue() - threshold <= 0)
            Released();
        if (!_isPressed && GetValue() + threshold >= 1 && _isTriggered)
            Pressed2();
    }
    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed1()
    {
        _isPressed = true;
        onPressed1.Invoke();
        Debug.Log(message: "Pressed1");
    }
    private void Released()
    {
        if (_isTriggered == false)
            _isTriggered = true;
        else if (_isTriggered == true)
            _isTriggered = false;

        _isPressed = false;
        onReleased.Invoke();
        Debug.Log(message: "Released");
    }
    private void Pressed2()
    {
        _isPressed = true;
        onPressed2.Invoke();
        Debug.Log(message: "Pressed2");
    }
}
