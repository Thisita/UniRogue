using UnityEngine;
using System.Collections;

public class RoboAnimController : MonoBehaviour
{
    public enum RoboAnimation
    {
        PunchHighLeft = "punch_hi_left",
        PunchHighRight = "punch_hi_right",
        KickJumpRight = "kick_jump_right",
        KickLowRight = "kick_lo_right"
    }
    Animation anim;
    // Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animation>();
	}
	
	// Play a anim based on its name
    public void PlayAnimation(RoboAnimation ani)
    {
        anim.CrossFade(ani.ToString());
        while (anim.isPlaying)
        {
            // do nothing
            continue;
        }

        anim.CrossFade("loop_idle");
    }
}
