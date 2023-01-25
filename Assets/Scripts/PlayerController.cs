using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerController : MonoBehaviour
{
    public Rig LeftRig;

    public float WeightSpeed = 3f;

    private bool _take = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _take = true;
        }

        if (_take)
        {
            LeftRig.weight = Mathf.MoveTowards(LeftRig.weight, 1, WeightSpeed * Time.deltaTime);
            if (LeftRig.weight == 1) _take = false; 
        }
        
        if(!_take&& LeftRig.weight != 0) LeftRig.weight = Mathf.MoveTowards(LeftRig.weight, 0, WeightSpeed * Time.deltaTime);
    }


}
