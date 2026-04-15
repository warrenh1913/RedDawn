using UnityEngine;
using Spine.Unity;

public class SpineAnimationController : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation; // Spine 애니메이션 컨트롤러
    public string currentAnimation = "standing"; // 기본 애니메이션

    public void PlayAnimation(string animationName)
    {
        if (skeletonAnimation == null) return;
        
        skeletonAnimation.AnimationState.SetAnimation(0, animationName, true);
        currentAnimation = animationName;
    }
}
