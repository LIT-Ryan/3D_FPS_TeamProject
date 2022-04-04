using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform _playerCam;
    public Transform _portal;
    public Transform _otherPortal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromPortal = _playerCam.position - _otherPortal.position;
        transform.position = _portal.position + playerOffsetFromPortal;


        float angualarDiff = Quaternion.Angle(_portal.rotation, _otherPortal.rotation);

         Quaternion portalRotationDiff = Quaternion.AngleAxis(angualarDiff, Vector3.up);
        Vector3 newCamDirection = portalRotationDiff * _playerCam.forward;
        transform.rotation = Quaternion.LookRotation(newCamDirection, Vector3.up);
    }
}
