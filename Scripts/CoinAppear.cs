using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAppear : MonoBehaviour
{
    private Vector3 Min;
    private Vector3 Max;
    private float _xAxis;
    private float _yAxis;
    private Vector3 _randomPosition;
    public GameObject Coin;
    
    void Start()
    {
        SetRanges();
    }

    // Update is called once per frame
    void Update()
    {
        _xAxis = Random.Range(Min.x, Max.x);
        _yAxis = Random.Range(Min.y, Max.y);

        _randomPosition = new Vector3(_xAxis, _yAxis, Min.z);

        SpawnCoin(_randomPosition);

    }
    private void SetRanges()
    {
        Min = new Vector3(0, 0, 0);
        Max = new Vector3(10, 10, 0);
    }


    private void SpawnCoin(Vector3 random)
    {
        Instantiate(Coin, random, Quaternion.identity);
    }
}
