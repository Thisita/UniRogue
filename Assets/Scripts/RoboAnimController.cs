using UnityEngine;
using System.Collections;

public class RoboAnimController : MonoBehaviour
{
    public enum RoboLoop
    {
        Idle,
        Walk
    }
    RoboLoop loop;
    public enum RoboAnimation
    {
        PunchHighLeft,
        PunchHighRight,
        KickJumpRight,
        KickLowRight
    }
    Animation anim;
    // Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animation>();
        SetLoop(RoboLoop.Idle);
	}

    // Reset to loop
    void Update()
    {
        if (!anim.isPlaying)
        {
            anim.CrossFade(EnumToLoopAnim(loop));
        }
    }
	
	// Play a anim based on its name
    public void PlayAnimation(RoboAnimation ani)
    {
        anim.CrossFade(EnumToAnim(ani));
    }

    // Set the the loop
    public void SetLoop(RoboLoop lp)
    {
        loop = lp;
        anim.CrossFade(EnumToLoopAnim(loop));
    }

    // convert enum to loop anim
    string EnumToLoopAnim(RoboLoop ani)
    {
        switch (ani)
        {
            case RoboLoop.Idle:
                return "loop_idle";
            case RoboLoop.Walk:
                return "loop_walk_funny";
            default:
                throw new System.Exception("Wat?");
        }
    }

    // convert enum to anim
    string EnumToAnim(RoboAnimation ani)
    {
        switch (ani)
        {
            case RoboAnimation.KickJumpRight:
                return "kick_jump_right";
            case RoboAnimation.KickLowRight:
                return "kick_lo_right";
            case RoboAnimation.PunchHighLeft:
                return "punch_hi_left";
            case RoboAnimation.PunchHighRight:
                return "punch_hi_right";
            default:
                throw new System.Exception("Wat?");
        }
    }
}
