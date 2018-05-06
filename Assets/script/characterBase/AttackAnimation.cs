using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    [SerializeField]
    private bool useAttackAnimation = false;

    [SerializeField]
    private int animationTotalFlame = 1;

    [SerializeField]
    private int animationSpeed = 8;

    [SerializeField]
    private Collider2D downHitCollision;

    [SerializeField]
    private Collider2D rightHitCollision;

    [SerializeField]
    private Collider2D upHitCollision;

    [SerializeField]
    private Collider2D leftHitCollision;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip audioClip;

    private int animationFrame = 0;
    private int animationCount = 0;
    private Sprite[] sprites;

    private bool isEnd = false;
    public bool IsEnd
    {
        get
        {
            return isEnd;
        }
    }

    public bool UseAttackAnimation
    {
        get
        {
            return useAttackAnimation;
        }
    }


    void Start ()
    {
        if (!UseAttackAnimation) return;

        downHitCollision.enabled = false;
        leftHitCollision.enabled = false;
        upHitCollision.enabled = false;
        rightHitCollision.enabled = false;

        audioSource.clip = audioClip;

        sprites = Resources.LoadAll<Sprite>(GetComponent<Character>().path + "/attack/");
    }

    public Sprite GetSprite(CharacterDirection direction)
    {
        if (!UseAttackAnimation) return null;

        if(animationFrame == 0 && animationCount == 0)
        {
            GameManager.Instance.soundManager.PlayOneShot(SeType.SWISH);
        }

        animationCount++;

        if (animationSpeed <= animationCount)
        {
            animationFrame += 1;
            animationCount = 0;
        }

        if (animationTotalFlame <= animationFrame)
        {
            animationFrame = 0;

            downHitCollision.enabled  = false;
            leftHitCollision.enabled  = false;
            upHitCollision.enabled    = false;
            rightHitCollision.enabled = false;

            return null;
        }

        switch (direction)
        {
            case CharacterDirection.DOWN:
                if (downHitCollision.enabled == false) downHitCollision.enabled = true;
                return sprites[0];
            case CharacterDirection.LEFT:
                if (leftHitCollision.enabled == false) leftHitCollision.enabled = true;
                return sprites[1];
            case CharacterDirection.UP:
                if (upHitCollision.enabled == false) upHitCollision.enabled = true;
                return sprites[2];
            case CharacterDirection.RIGHT:
                if (rightHitCollision.enabled == false) rightHitCollision.enabled = true;
                return sprites[3];
        }

        return null;
    }
}
