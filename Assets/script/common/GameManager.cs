using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    [SerializeField]
    private GameObject uiManager;

    [SerializeField]
    private SlimeSpawner[] slimeSpawners;

    [SerializeField]
    private GameObject slime;

    private GameObject rootGameObject;

    public SoundManager  soundManager;
    public SpriteFactory spriteFactory;
    public EffectFactory effectFactory;

    private List<GameObject> slimes;

    private int count = 0;


    public void Initialise(GameObject root)
    {
        rootGameObject = root;
        slimes = new List<GameObject>();
    }

    public void addCoin(int num)
    {
        uiManager.GetComponent<UIManager>().AddCoin(num);
    }

    public GameObject addSlime(Vector3 position)
    {
        GameObject obj = Instantiate(slime, rootGameObject.transform);
        obj.transform.position = position;
        return obj;
    }

    private void SpawnSlime()
    {
        int head = Random.Range(0, slimeSpawners.Length);
        for (int i = 0; i < slimeSpawners.Length; i++)
        {
            if (slimeSpawners[head].IsReady)
           {
                Vector3 pos = slimeSpawners[head].GetSlimeSpawnPosition();
                GameManager.Instance.soundManager.PlayOneShot(SeType.SPAWN);
                effectFactory.instatiateDeadEffect(pos);
                pos.y -= 10;
                slimes.Add(addSlime(pos));
                return;
           }
           else
           {
                head++;
                if (head >= slimeSpawners.Length)
                {
                    head = 0;
                }
           }
        }
    }



    void Update()
    {
        count++;
        if(count >= 120)
        {
            SpawnSlime();
            count = 0;
        }
    }
}
