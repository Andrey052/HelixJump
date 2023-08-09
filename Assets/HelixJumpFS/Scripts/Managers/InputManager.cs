using UnityEngine;
public class InputManager : BallEvents
{
    [SerializeField] private MouseRotator inputRotator;
    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Finish || type == SegmentType.Trap)
        {
            inputRotator.enabled = false;
        }
    }
}
