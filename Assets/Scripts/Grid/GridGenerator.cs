using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [Header("BarrierPerlinNoise")]
    [SerializeField] private float _comparisonWithResultOfBarrierPerlinNoise;
    [Header("Sin")]
    [SerializeField] private float _comparisonWithResultOfSin;
    [SerializeField] private float _sinWaveWidth;
    [Header("CoinrPerlinNoise")]
    [SerializeField] private float _comparisonWithResultOfCoinPerlinNoise;
    
    public StateInGrid GenerateStateAtTopOfGrid(int x)
    {
        int resultOfPerlinNoise = Mathf.PerlinNoise((float)x, 0.9f) > _comparisonWithResultOfBarrierPerlinNoise ? 1 : 0;
        int resultOfSin = Mathf.Abs(Mathf.Sin(_sinWaveWidth * x)) > _comparisonWithResultOfSin ? 1 : 0;
        int possibilityToPutBarrier = resultOfPerlinNoise * resultOfSin;
        return possibilityToPutBarrier == 1 ? StateInGrid.Barrier : Mathf.PerlinNoise((float)x, 0.9f) > _comparisonWithResultOfCoinPerlinNoise ? StateInGrid.Coin : StateInGrid.Nothing;
    }
}