using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private OrbitCamera orb;


    
    public Rig LeftRig;
    public Rig RightRig;
    public GameObject LeftHand;
    public Transform LeftHandPos;
    public Transform[] BasketPositions;


    public float WeightSpeed = 3f;

    private Animator _anim;
    private Take obj;
    private int _countObj = 0;
    private bool _take = false;
    private bool _toBasket = false;
    private bool _isClicked = false;


    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        #region IK
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _take = true;
        }

        if (_take)
        {
            LeftRig.weight = Mathf.MoveTowards(LeftRig.weight, 1, WeightSpeed * Time.deltaTime);
            if (LeftRig.weight == 1)
            {
                _take = false;
                StartCoroutine(ToBasket());
            } 
        }

        

        if (!_take && LeftRig.weight != 0)
        {
           LeftRig.weight = Mathf.MoveTowards(LeftRig.weight, 0, WeightSpeed * Time.deltaTime);

        }
        #endregion

        if (Input.GetMouseButton(0))
        {
            Check();
        }
    }

    IEnumerator ToBasket()
    {
        IKController.Instance.ToBasket = true;
        yield return new WaitForSeconds(0.5f);
        obj.DropObject(BasketPositions[_countObj]);
        _countObj++;
        UIController.UI.UpdateUI(_countObj);
        IKController.Instance.ToBasket = false;
        if (_countObj == UIController.UI.questNumb)
        {
            RightRig.weight = 0;
            GameContoller.Instance.WinGame();
            orb.CameraTrigger = true;
            _anim.SetBool("IsWin", true);
        }
    }

    private void Check()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mouseHit;
        if (Physics.Raycast(ray, out mouseHit))
        {
            GameObject hitObject = mouseHit.transform.gameObject;
            if (hitObject.CompareTag(GameContoller.Instance.QuestName))
            {
                obj = hitObject.GetComponent<Take>();
                IKController.Instance.ToBasket = false;
                LeftHand.transform.position = hitObject.transform.position;
                obj.pos = LeftHandPos;
                obj.TakeObject();
                GameContoller.Instance.Elements = new List<GameObject>();
                _take = true;
            }
        }
    }
}
