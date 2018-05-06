using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MovingEffect
{
    private Collider2D Collider;
    private GameObject shadowParent;
    private GameObject coinSprite;

    void Start ()
    {
        Collider = GetComponent<Collider2D>();
        Collider.enabled = false;

        shadowParent = transform.Find("ShadowParent").gameObject;
        coinSprite = transform.Find("CoinSprite").gameObject;

        GameManager instaince = GameManager.Instance;
        GameObject shadow = instaince.spriteFactory.instatiateShadow(shadowParent, SpriteFactory.ShadowType.Small);
        shadow.transform.Translate(new Vector3(0, 0, -1));
    }

    protected override void Update()
    {
        if (count == 20)
        {
            Collider.enabled = true;
        }

        base.Update();

        Vector3 pos = new Vector3();
        pos.y = speed.z;
        coinSprite.transform.Translate(pos);
    }

    public void CoinGet()
    {
        GameManager.Instance.soundManager.PlayOneShot(SeType.COIN);
        Destroy(gameObject);
    }
}
