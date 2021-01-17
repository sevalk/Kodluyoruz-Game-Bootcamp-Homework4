
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Vector3 _offset; //offset value

    private void Start()
    {
        _offset = _target.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float desiredAngle = _target.eulerAngles.y;

         Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);

         transform.position = _target.position - (rotation * _offset);
        transform.position = _target.position -  _offset;
        transform.LookAt(_target);   //look at target
    }
}
