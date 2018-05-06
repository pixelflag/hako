using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Character
{
    [SerializeField]
    protected float moveDistance = 1;

    [SerializeField]
    protected float moveTime = 0.5f;

    [SerializeField]
    protected int life = 2;

    private float time;

    private SlimeState slimeState;

    private enum SlimeState
    {
        MOVE_RIGHT,
        MOVE_UP,
        MOVE_LEFT,
        MOVE_DOWN,
        STOP
    }

    protected override void Start()
    {
        time = 0.0f;
        slimeState = SlimeState.STOP;

        base.Start();

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Attack")
        {
            Damage(col);
        }
    }

    private void Damage(Collider2D col)
    {
        life--;

        GameManager.Instance.soundManager.PlayOneShot(SeType.DAMAGE);

        GameManager instaince = GameManager.Instance;
        instaince.effectFactory.instatiateDamageEffect2(effectParent);

        Vector3 position1 = col.transform.position - gameObject.transform.position;
        Vector3 position2 = gameObject.transform.position + (position1/2);
        instaince.effectFactory.instatiateHitEffect(gameObject, position2);

        Vector3 position = col.transform.position - gameObject.transform.position;
        knockBack(new Vector2(-position.x, -position.y));

        if (life <= 0)
        {
            instaince.effectFactory.instatiateDeadEffect(gameObject.transform.position);
            instaince.spriteFactory.instatiateCoinEmmiter(gameObject.transform.position);
            GameManager.Instance.soundManager.PlayOneShot(SeType.DEAD);
            Destroy(gameObject);
        }
    }

    protected override void FixedUpdate()
    {
        switch (status)
        {
            case CharacterStatus.IDLE:
            case CharacterStatus.WALK:
                SlimeMove();
                break;

            case CharacterStatus.ATTACK:
                break;

            case CharacterStatus.NOCK_BACK:
                time = 0.0f;
                break;

            default:
                break;

        }
        base.FixedUpdate();
    }

    private void SlimeMove()
    {
        time += Time.deltaTime;

        switch (slimeState)
        {
            case SlimeState.MOVE_RIGHT:
            case SlimeState.MOVE_UP:
            case SlimeState.MOVE_LEFT:
            case SlimeState.MOVE_DOWN:
                if (moveTime <= time)
                {
                    slimeState = SlimeState.STOP;
                    time = Random.Range(0.0f, 0.5f);
                }
                break;
            case SlimeState.STOP:
            default:
                if (moveDistance <= time)
                {
                    switch (Random.Range(0, 6))
                    {
                        case 0:
                            slimeState = SlimeState.MOVE_RIGHT;
                            break;
                        case 1:
                            slimeState = SlimeState.MOVE_UP;
                            break;
                        case 2:
                            slimeState = SlimeState.MOVE_LEFT;
                            break;
                        case 3:
                            slimeState = SlimeState.MOVE_DOWN;
                            break;
                        default:
                            slimeState = SlimeState.STOP;
                            break;
                    }
                    time = 0.0f;
                }
                break;
        }

        float tempX = 0f;
        float tempY = 0f;

        switch (slimeState)
        {
            case SlimeState.MOVE_RIGHT:
                tempY = 1;
                break;
            case SlimeState.MOVE_UP:
                tempX = -1;
                break;
            case SlimeState.MOVE_LEFT:
                tempY = -1;
                break;
            case SlimeState.MOVE_DOWN:
                tempX = 1;
                break;
            default:
                break;
        }

        if (!(tempX == 0 && tempY == 0))
        {
            var radian = Mathf.Atan2(tempY, tempX);
            speed.x += accsele * Mathf.Cos(radian);
            speed.y += accsele * Mathf.Sin(radian);
        }
    }
}
