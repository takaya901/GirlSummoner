using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Transfer : MonoBehaviour
{
//    Material _transferMat;
//    string _threshold = "_Threshold";
//    float _currentVelocity;
//    
//    void Start()
//    {
//        _transferMat = GetComponent<Renderer>().material;
//    }
//
//    void Update()
//    {
//        var height = Mathf.SmoothDamp(_transferMat.GetFloat(_threshold), 1f, ref _currentVelocity, 2f);
//        if (_transferMat.HasProperty(_threshold)) {
//            _transferMat.SetFloat(_threshold, height);
//        }
//    }

    // mesh_root下のパーツのシェーダーを操作する
    List<Material> _materials = new List<Material>();
    string _threshold = "_Threshold";
    float _currentVelocity;

    void Start()
    {
        var parts = gameObject.GetDecendants().Where(part => part.GetComponent<Renderer>());
        foreach (var part in parts) {
//            Debug.Log(part.name);
            _materials.Add(part.GetComponent<Renderer>().material);
        }
    }

    void Update()
    {
        foreach (var material in _materials) 
        {
            if (!material.HasProperty(_threshold)) continue;
            
            var height = Mathf.SmoothDamp(material.GetFloat(_threshold), 1f, ref _currentVelocity, 2f);
            material.SetFloat(_threshold, height);
        }
    }
}
