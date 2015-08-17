

/*****************************************************************************
 * SpineboyController created by Mitch Thompson
 * Full irrevocable rights and permissions granted to Esoteric Software
*****************************************************************************/
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SkeletonAnimation), typeof(Rigidbody))]
public class SpineboyController : MonoBehaviour {

	SkeletonAnimation skeletonAnimation;
	public string idleAnimation = "idle";
	public string walkAnimation = "walk";
	public string runAnimation = "run";
	public string hitAnimation = "hit";
	public string deathAnimation = "death";
	public float walkVelocity = 1;
	public float runVelocity = 3;
	public int hp = 10;
	string currentAnimation = "";
	bool hit = false;
	bool dead = false;

	void Start () {
		skeletonAnimation = GetComponent<SkeletonAnimation>();
	}

	void Update () {
		if (!dead) {
			float x = Input.GetAxis("Horizontal");
			float absX = Mathf.Abs(x);

			if (!hit) {
				
			} else {
				if (skeletonAnimation.state.GetCurrent(0).Animation.Name != hitAnimation)
					hit = false;
			}

            float y = Input.GetAxis("Vertical");
            float absY = Mathf.Abs(y);

            if (!hit)
            {
                if (x > 0)
                    skeletonAnimation.skeleton.FlipX = false;
                else if (x < 0)
                    skeletonAnimation.skeleton.FlipX = true;

                if (absX > 0.7f)
                {
                    SetAnimation(runAnimation, true);
                    GetComponent<Rigidbody>().velocity = new Vector3(runVelocity * Mathf.Sign(x), GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
                }
                else if (absX > 0)
                {
                    SetAnimation(walkAnimation, true);
                    GetComponent<Rigidbody>().velocity = new Vector3(walkVelocity * Mathf.Sign(x), GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
                }
    

                if (absY > 0.7f)
                {
                    SetAnimation(runAnimation, true);
                    GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, runVelocity * Mathf.Sign(y));
                }
                else if (absY > 0)
                {
                    SetAnimation(walkAnimation, true);
                    GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, walkVelocity * Mathf.Sign(y));
                }
           

                if (absX <= 0 && absY <= 0)
                {
                    SetAnimation(idleAnimation, true);
                    GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0);
                }
            }
            else
            {
                if (skeletonAnimation.state.GetCurrent(0).Animation.Name != hitAnimation)
                    hit = false;
            }


        }
	}

	void SetAnimation (string anim, bool loop) {
		if (currentAnimation != anim) {
			skeletonAnimation.state.SetAnimation(0, anim, loop);
			currentAnimation = anim;
		}
	}

	void OnMouseUp () {

		if (hp > 0) {
			hp--;

			if (hp == 0) {
				SetAnimation(deathAnimation, false);
				dead = true;
			} else {
				skeletonAnimation.state.SetAnimation(0, hitAnimation, false);
				skeletonAnimation.state.AddAnimation(0, currentAnimation, true, 0);
				GetComponent<Rigidbody>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
				hit = true;
			}

		}
	}
}