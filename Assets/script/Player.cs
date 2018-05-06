using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    protected override void FixedUpdate()
    {
        GetInput();
        base.FixedUpdate();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Coin")
        {
            GameManager instaince = GameManager.Instance;
            instaince.effectFactory.instatiateSparkleEmmiter(col.gameObject.transform.position);
            instaince.addCoin(1);

            col.gameObject.GetComponent<Coin>().CoinGet();
        }
    }

    private void GetInput()
    {
        float tempX = 0f;
        float tempY = 0f;

        if(Input.GetKey(KeyCode.W))
        {
            tempY = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            tempX = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            tempY = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            tempX = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            status = CharacterStatus.ATTACK;
        }

        if (!(tempX == 0 && tempY == 0))
        {
            var radian = Mathf.Atan2(tempY, tempX);
            speed.x += accsele * Mathf.Cos(radian);
            speed.y += accsele * Mathf.Sin(radian);
        }
    }
}
