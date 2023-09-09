using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterPathFollower : MonoBehaviour
{
    [SerializeField]
    public Transform pathsParent;
    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    public float rotationSpeed;
   
    [SerializeField]
    private int _currentPathIndex;
    [SerializeField]
    private Transform[] _pathPoints;

    private int listNumber;

    
    private void Start()
    {
        _pathPoints = new Transform[pathsParent.childCount];
        for (int i = 0; i < pathsParent.childCount; i++)
        {
            _pathPoints[i] = pathsParent.GetChild(i);
        }
        listNumber = _pathPoints.Length;
    }

    private void Update()
    {
        if (!Input.GetKey(KeyCode.Space)) return;
        MoveCharacter();
        RotateCharacter();
    }


    private void MoveCharacter()
    {
        Vector3 targetPosition = _pathPoints[_currentPathIndex].position;
        var distance = Vector3.Distance(transform.position, targetPosition);

        if (distance <= 0.1f && _currentPathIndex < listNumber - 1)
        {
            _currentPathIndex++;
            
            if (_currentPathIndex >= _pathPoints.Length)
            {
                return;
            }
            
            targetPosition = _pathPoints[_currentPathIndex].position;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void RotateCharacter()
    {
        Vector3 lookDir = _pathPoints[_currentPathIndex].position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
    
}

