using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Clone_Skill_Controller : MonoBehaviour
{
    private SpriteRenderer sr;

    [SerializeField] private float colorLosingSpeed;
    private float cloneTimer;

    private void Awake() 
    {
        sr = GetComponent<SpriteRenderer>();    
    }

    private void Update()
    {
        cloneTimer -= Time.deltaTime;

        if (cloneTimer < 0)
        {
            sr.color = new Color(1, 1, 1, sr.color.a - (Time.deltaTime * colorLosingSpeed));
        }
    }


    public void SetupClone(Transform _newTransform, float _cloneDuration)
    {
        transform.position = _newTransform.position;
        cloneTimer = _cloneDuration;
    }
}