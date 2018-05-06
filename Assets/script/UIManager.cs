using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image[] coins;

    const string BASE_PATH = "ui/";
    private Sprite[] allSprits;
    private Sprite[] coinSprits;
    private Sprite[] numSprits;

    private int currentCoin = 0;
    private int maxCoin = 999;

    void Start()
    {
        allSprits = Resources.LoadAll<Sprite>(BASE_PATH);

        coinSprits = new Sprite[1];
        coinSprits[0] = allSprits[4];

        numSprits = new Sprite[10];
        numSprits[0] = allSprits[5];
        numSprits[1] = allSprits[6];
        numSprits[2] = allSprits[7];
        numSprits[3] = allSprits[8];
        numSprits[4] = allSprits[9];
        numSprits[5] = allSprits[10];
        numSprits[6] = allSprits[11];
        numSprits[7] = allSprits[12];
        numSprits[8] = allSprits[13];
        numSprits[9] = allSprits[14];
    }

    public void AddCoin(int num)
    {
        currentCoin += num;

        if (currentCoin > maxCoin)
        {
            currentCoin = maxCoin;
        }

        changeNum(0, currentCoin % 10 );
        changeNum(1, (currentCoin / 10) % 10);
        changeNum(2, (currentCoin / 100) % 10);
    }

    private void changeNum(int unit, int num)
    {
        coins[unit].sprite = numSprits[num];
    }
}
