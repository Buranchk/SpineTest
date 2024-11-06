using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Spine.Unity;
using Spine;

public class PlayerController : MonoBehaviour
{
    public enum CharacterMovementState
    {
        None,
        Idle,
        Walk
    }

    public enum CharacterInventoryState
    {
        None,
        Shoot,
        AttackAxe,
        Hit,
        HolstAxe,
        HolstPistol,
        GetWeaponAxe,
        GetWeaponPistol
    }

    public float speed = 10f;

    public bool axeOut = false;

    public bool pistolOut = false;

    float input = default(float);

    Vector2 velocity = default(Vector2);

    SkeletonAnimation skeletonAnimation;

    public CharacterMovementState characterMoveState = CharacterMovementState.None;

    public CharacterInventoryState charInvState = CharacterInventoryState.None;

    private void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
    }

    private void Update()
    {
        input = Input.GetAxis("Horizontal");

        velocity = new Vector2(input * speed, 0);

        gameObject.transform.Translate(velocity * Time.deltaTime);


        if (characterMoveState != CharacterMovementState.Idle && input == 0)
        {
            characterMoveState = CharacterMovementState.Idle;

            skeletonAnimation.AnimationState.SetAnimation(0, "0-idle", true);
            skeletonAnimation.timeScale = 1f;
        }

        if (characterMoveState != CharacterMovementState.Walk && input != 0)
        {
            characterMoveState = CharacterMovementState.Walk;

            skeletonAnimation.AnimationState.SetAnimation(0, "walk", true);
        }

        if (characterMoveState == CharacterMovementState.Walk)
        {
            skeletonAnimation.timeScale = Mathf.Abs(input);
        }

        if (input < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        if (input > 0)
            transform.localScale = new Vector3(1, 1, 1);


        if (Input.GetKeyDown(KeyCode.J) && charInvState == CharacterInventoryState.None)
        {
            if (charInvState != CharacterInventoryState.GetWeaponAxe && !axeOut)
            {
                charInvState = CharacterInventoryState.GetWeaponAxe;
                TrackEntry trackEntry = skeletonAnimation.AnimationState.SetAnimation(1, "axe-1out", false);
                trackEntry.Complete += (TrackEntry trackEntry) => { axeOut = true; charInvState = CharacterInventoryState.None; };
            }

            if (charInvState != CharacterInventoryState.AttackAxe && axeOut)
            {
                charInvState = CharacterInventoryState.AttackAxe;
                TrackEntry trackEntry;
                if (Random.Range(0, 1) == 0)
                {
                    trackEntry = skeletonAnimation.AnimationState.SetAnimation(1, "axe-2hit1nolegs", false);
                }
                else
                {
                    trackEntry = skeletonAnimation.AnimationState.SetAnimation(1, "axe-2hit2nolegs", false);
                }
                trackEntry.Complete += (TrackEntry trackEntry) => { axeOut = true; charInvState = CharacterInventoryState.None; };
            }
        }

        if (Input.GetKeyDown(KeyCode.U) && charInvState == CharacterInventoryState.None)
        {
            if (charInvState != CharacterInventoryState.HolstAxe && axeOut)
            {
                charInvState = CharacterInventoryState.HolstAxe;
                TrackEntry trackEntry = skeletonAnimation.AnimationState.SetAnimation(1, "axe-3out1nolegs", false);
                trackEntry.Complete += (TrackEntry trackEntry) => { axeOut = false; charInvState = CharacterInventoryState.None; };
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (charInvState != CharacterInventoryState.GetWeaponPistol && !pistolOut)
            {
                charInvState = CharacterInventoryState.GetWeaponPistol;
                TrackEntry trackEntry = skeletonAnimation.AnimationState.SetAnimation(1, "gun-1outnolegs", false);
                trackEntry.Complete += (TrackEntry trackEntry) => { pistolOut = true; charInvState = CharacterInventoryState.None; };
            }

            if (charInvState != CharacterInventoryState.AttackAxe && axeOut)
            {
                charInvState = CharacterInventoryState.AttackAxe;
                TrackEntry trackEntry;
                if (Random.Range(0, 1) == 0)
                {
                    trackEntry = skeletonAnimation.AnimationState.SetAnimation(1, "axe-2hit1nolegs", false);
                }
                else
                {
                    trackEntry = skeletonAnimation.AnimationState.SetAnimation(1, "axe-2hit2nolegs", false);
                }
                trackEntry.Complete += (TrackEntry trackEntry) => { axeOut = true; charInvState = CharacterInventoryState.None; };
            }
        }
    }
}
