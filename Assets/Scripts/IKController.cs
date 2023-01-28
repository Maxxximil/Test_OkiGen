using UnityEngine;

public class IKController : MonoBehaviour
{
    public static IKController Instance;

    [Header("Left Hand")]
    [Range(0, 1.0f)]
    [SerializeField] private float _weightLeftHandPosition;
    [SerializeField] private Transform _leftHandPosition;
    [SerializeField] private Transform _leftElbowPosition;

    [Header("Right Hand")]
    [Range(0, 1.0f)]
    [SerializeField] private float _weightRightHandPosition;
    [SerializeField] private Transform _rightHandPosition;
    [SerializeField] private Transform _rightElbowPosition;

    public bool ToBasket = false;
    public float WeightSpeed = 3f;


    private Animator _targetAnimator;

    private void Start()
    {
        Instance = this;
        _targetAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (ToBasket && _weightLeftHandPosition < 1 && _weightRightHandPosition < 1)
        {
            _weightLeftHandPosition += Time.deltaTime * WeightSpeed;
            _weightRightHandPosition += Time.deltaTime * WeightSpeed;
        }
        if (!ToBasket && _weightLeftHandPosition > 0 && _weightRightHandPosition > 0)
        {
            _weightLeftHandPosition -= Time.deltaTime * WeightSpeed;
            _weightRightHandPosition -= Time.deltaTime * WeightSpeed;
        }
    }

    private void OnAnimatorIK()
    {

        _targetAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, _weightLeftHandPosition);
        _targetAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, _weightRightHandPosition);

        _targetAnimator.SetIKPosition(AvatarIKGoal.LeftHand, _leftHandPosition.position);
        _targetAnimator.SetIKPosition(AvatarIKGoal.RightHand, _rightHandPosition.position);

        _targetAnimator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, _weightLeftHandPosition);
        _targetAnimator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, _weightRightHandPosition);

        _targetAnimator.SetIKHintPosition(AvatarIKHint.LeftElbow, _leftElbowPosition.position);
        _targetAnimator.SetIKHintPosition(AvatarIKHint.RightElbow, _rightElbowPosition.position);

    }
}
