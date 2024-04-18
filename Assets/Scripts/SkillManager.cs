using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    private void Awake() 
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }
}
