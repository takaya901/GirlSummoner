using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//https: //qiita.com/shun-shun123/items/1aa646049474d0e244be
[RequireComponent(typeof(ARRaycastManager))]
public class Summoner : MonoBehaviour
{
    [SerializeField] GameObject _girlPrefab = null;
    GameObject _girl;
    ARRaycastManager _raycastManager;
    static List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    
    void Start()
    {
        Input.backButtonLeavesApp = true;
        _raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount <= 0) {
            return;
        }

        var touchPos = Input.GetTouch(0).position;
        if (!_raycastManager.Raycast(touchPos, _hits, TrackableType.Planes)) {
            return;
        }
        
        // Raycastの衝突情報は距離によってソートされるため、0番目が最も近い場所でヒットした情報となります
        var hitPose = _hits[0].pose;
        var pos = hitPose.position;
//        var pos = hitPose.position + new Vector3(0f, 0.5f, 0f);
        
        if (_girl) {
            _girl.transform.position = pos;
        }
        else {
            _girl = Instantiate(_girlPrefab, pos, Quaternion.identity);
            _girl.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
