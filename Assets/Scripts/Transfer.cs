using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transfer : MonoBehaviour
{
    Material _transferMat;
    string _threshold = "_Threshold";
    float _currentVelocity;
    
    void Start()
    {
        _transferMat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        var height = Mathf.SmoothDamp(_transferMat.GetFloat(_threshold), 1f, ref _currentVelocity, 2f);
        if (_transferMat.HasProperty(_threshold)) {
            _transferMat.SetFloat(_threshold, height);
        }
    }
}
