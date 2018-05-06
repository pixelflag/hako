using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
	void Start ()
    {
        GameManager.Instance.Initialise(gameObject);
    }
	
	void Update ()
    {
		
	}
}
