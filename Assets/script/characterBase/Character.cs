using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : PixelObjectBase
{
    [SerializeField]
    public string path = "sprite/";

    [SerializeField]
    protected float accsele = 24.0f;

    [SerializeField]
    private float friction = 0.8f;

    [SerializeField]
    private float nockBackFriction = 0.8f;

    private float nockBackForce = 300.0f;

    private GameObject baseSprite;
    protected SpriteRenderer spriteRenderer;

    protected Vector2 speed;

    protected GameObject effectParent;
    protected GameObject shadowParent;

    private IdleAnimation idleAnimation;
    private WalkAnimation walkAnimation;
    private DamageAnimation damageAnimation;
    private AttackAnimation attackAnimation;

    protected enum CharacterStatus
    {
        IDLE,
        WALK,
        ATTACK,
        NOCK_BACK
    }

    protected CharacterStatus status;
    protected CharacterDirection direction;

    protected virtual void Start ()
    {
        speed = new Vector2(0, 0);

        direction = CharacterDirection.DOWN;
        status    = CharacterStatus.IDLE;

        baseSprite   = transform.Find("BaseSprite").gameObject;
        spriteRenderer = baseSprite.GetComponent<SpriteRenderer>();

        effectParent = transform.Find("EffectParent").gameObject;
        shadowParent = transform.Find("ShadowParent").gameObject;

        idleAnimation   = GetComponent<IdleAnimation>();
        walkAnimation   = GetComponent<WalkAnimation>();
        damageAnimation = GetComponent<DamageAnimation>();
        attackAnimation = GetComponent<AttackAnimation>();

        GameManager instaince = GameManager.Instance;
        GameObject shadow = instaince.spriteFactory.instatiateShadow(shadowParent, SpriteFactory.ShadowType.Midiam);
        shadow.transform.Translate(new Vector3(0, 0, -1));
    }

    protected virtual void FixedUpdate()
    {
        Move();
	}

    public void Move()
    {
        switch (status)
        {
            case CharacterStatus.IDLE:
            case CharacterStatus.WALK:
                if( status != CharacterStatus.ATTACK)
                {
                    speed = speed * friction;
                    if (Mathf.Abs(speed.x) <= 1) speed.x = 0;
                    if (Mathf.Abs(speed.y) <= 1) speed.y = 0;
                    if (speed.x == 0 && speed.y == 0)
                    {
                        status = CharacterStatus.IDLE;
                    }
                    else
                    {
                        CalculateDirection();
                        status = CharacterStatus.WALK;
                    }
                }
                break;

            case CharacterStatus.ATTACK:
                speed.x = 0;
                speed.y = 0;
                break;

            case CharacterStatus.NOCK_BACK:
                speed = speed * nockBackFriction;
                if (Mathf.Abs(speed.x) <= 1) speed.x = 0;
                if (Mathf.Abs(speed.y) <= 1) speed.y = 0;
                if (speed.x == 0 && speed.y == 0)
                {
                    status = CharacterStatus.IDLE;
                }
                else
                {
                    CalculateDirection();
                    status = CharacterStatus.NOCK_BACK;
                }
                break;

            default:
                break;
        }

        transform.Translate(speed * Time.deltaTime);
        AnimationControll();
    }

    protected void knockBack(Vector2 direction)
    {
        speed = direction.normalized * nockBackForce;
        status = CharacterStatus.NOCK_BACK;
    }

    public void AnimationControll()
    {
        switch (status)
        {
            case CharacterStatus.IDLE:
                spriteRenderer.sprite = idleAnimation.GetSprite(direction);
                break;

            case CharacterStatus.WALK:
                spriteRenderer.sprite = walkAnimation.GetSprite(direction);
                break;

            case CharacterStatus.ATTACK:
                if (!attackAnimation.UseAttackAnimation)
                {
                    status = CharacterStatus.IDLE;
                    return;
                }

                walkAnimation.ResetFrame();

                Sprite sprite = attackAnimation.GetSprite(direction);
                if (sprite)
                {
                    spriteRenderer.sprite = sprite;
                }
                else
                {
                    status = CharacterStatus.IDLE;
                }
                break;

            case CharacterStatus.NOCK_BACK:
                spriteRenderer.sprite = damageAnimation.GetSprite(direction);
                break;

            default:
                break;

        }
    }

    private void CalculateDirection()
    {
        float radian = Mathf.Atan2(speed.y, speed.x);
        if (radian < 0)
        {
            radian = radian + 2 * Mathf.PI;
        }
        float degree = Mathf.Floor(radian * Mathf.Rad2Deg);

        if (0 <= degree && degree < 45)
        {
            direction = CharacterDirection.RIGHT;
        }
        else if (45 <= degree && degree < 135)
        {
            direction = CharacterDirection.UP;
        }
        else if (135 <= degree && degree < 225)
        {
            direction = CharacterDirection.LEFT;
        }
        else if (225 <= degree && degree < 315)
        {
            direction = CharacterDirection.DOWN;
        }
        else
        {
            direction = CharacterDirection.RIGHT;
        }
    }

}