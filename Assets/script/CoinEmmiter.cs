using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEmmiter : MonoBehaviour {

	void Start ()
    {
        int dropNum = Random.Range(1, 3);
        GameManager instaince = GameManager.Instance;

        for (int i = 0; i < dropNum; i++)
        {
            emmitCoin();
        }
        Destroy(gameObject);
    }

    void emmitCoin()
    {
        Vector3 force = new Vector3();
        force.x = Random.Range(-1.0f, 1.0f);
        force.y = Random.Range(-1.0f, 1.0f);
        force.z = 2f;

        GameManager instaince = GameManager.Instance;
        GameObject obj = instaince.spriteFactory.instatiateCoin(gameObject.transform.position);

        obj.GetComponent<Coin>().addForce(force);
    }
}
