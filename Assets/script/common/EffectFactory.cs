using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject rootGameObject;

    [SerializeField]
    private GameObject damageEffect;

    [SerializeField]
    private GameObject damageEffect2;

    [SerializeField]
    private GameObject deadEffect;

    [SerializeField]
    private GameObject hitEffect;

    [SerializeField]
    private GameObject sparkle;

    [SerializeField]
    private GameObject sparkleEmmiter;

    public GameObject instatiateDeadEffect(Vector3 position)
    {
        GameObject obj = Instantiate(deadEffect, rootGameObject.transform);
        obj.transform.Translate(position);
        return obj;
    }

    public GameObject instatiateDamageEffect(GameObject parent)
    {
        GameObject obj = Instantiate(damageEffect, parent.transform);
        obj.transform.Translate(new Vector3(0, -0.1f, 0));
        return obj;
    }

    public GameObject instatiateDamageEffect2(GameObject parent)
    {
        GameObject obj = Instantiate(damageEffect2, parent.transform);
        obj.transform.Translate(new Vector3(0, -0.1f, 0));
        return obj;
    }

    public GameObject instatiateHitEffect(GameObject parent, Vector3 position)
    {
        GameObject obj = Instantiate(hitEffect, rootGameObject.transform);
        position.y -= 0.15f;
        obj.transform.Translate(position);
        return obj;
    }

    public GameObject instatiateSparkleEmmiter(Vector3 position)
    {
        GameObject obj = Instantiate(sparkleEmmiter, rootGameObject.transform);
        obj.transform.position = position;
        return obj;
    }

    public GameObject instatiateSparkle(Vector3 position)
    {
        GameObject obj = Instantiate(sparkle, rootGameObject.transform);
        obj.transform.position = position;
        return obj;
    }
}
