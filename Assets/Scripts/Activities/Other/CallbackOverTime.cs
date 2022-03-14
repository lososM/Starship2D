using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallbackOverTime : ActivityBase<Transform>
{
    protected float _duration;
    protected float _timer;

    protected Action _callback;
    public CallbackOverTime(Transform t) : base(t)
    {

    }
    public CallbackOverTime(Transform t, float duration, Action callback): base (t)
    {
        _duration = duration;
        _timer = _duration;
        _callback = callback;
    }
    public void InvokeCallback(float duration, Action callback)
    {
        _duration = duration;
        _timer = _duration;
        _callback = callback;
    }
    public override void Update()
    {
        if (_timer > 0) _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            _callback.Invoke();
            _timer = 0;
        }
    }
}
