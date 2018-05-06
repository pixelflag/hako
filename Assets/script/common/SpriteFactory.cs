using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject rootGameObject;

    [SerializeField]
    private GameObject shadowSpriteS;

    [SerializeField]
    private GameObject shadowSpriteM;

    [SerializeField]
    private GameObject shadowSpriteL;

    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private GameObject coinEmmiter;


    public enum ShadowType
    {
        Small,
        Midiam,
        Large
    }

    public GameObject instatiateShadow(GameObject parent, ShadowType shadowType)
    {
        switch(shadowType)
        {
            case ShadowType.Small:
                return Instantiate(shadowSpriteS, parent.transform);
            case ShadowType.Midiam:
                return Instantiate(shadowSpriteM, parent.transform);
            case ShadowType.Large:
                return Instantiate(shadowSpriteL, parent.transform);
        }
        return null;
    }

    public GameObject instatiateCoinEmmiter(Vector3 position)
    {
        GameObject obj = Instantiate(coinEmmiter, rootGameObject.transform);
        obj.transform.position = position;
        return obj;
    }

    public GameObject instatiateCoin(Vector3 position)
    {
        GameObject obj = Instantiate(coin, rootGameObject.transform);
        obj.transform.position = position;
        return obj;
    }
}
