using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [Header("BarrierPerlinNoise")]
    [SerializeField] private float _barrierRandomizationRate;
    [Header("BarrierSin")]
    [SerializeField] private float _barrierLimitingFactor;
    [Header("CoinrPerlinNoise")]
    [SerializeField] private float _coinRandomizationRate;
    
    public StateInGrid GenerateObjectAtTopOfGrid(int onGroundPositionX)
    {
        bool randomBarrier = ReturnRandomBarrier(onGroundPositionX);
        bool constrainToPlaceBarrier = ReturnConstrainToPlaceBarrier(onGroundPositionX);
        bool possibilityToPlaceBarrier = ReturnPossibilityToPlaceBarrier(randomBarrier, constrainToPlaceBarrier);
        StateInGrid objectAtTopOfGrid = possibilityToPlaceBarrier == true ? StateInGrid.Barrier : ReturnCoinOrNothing(onGroundPositionX);
        return objectAtTopOfGrid;
    }

    public StateInGrid GenerateObjectAtBottomOfGrid()
    {
        return StateInGrid.Ground;
    }

    private bool ReturnRandomBarrier(int onGroundPositionX)
    {
        return Mathf.PerlinNoise((float)onGroundPositionX, 0.9f) > _barrierRandomizationRate ? true : false;
    }

    private bool ReturnConstrainToPlaceBarrier(int onGroundPositionX)
    {
        return Mathf.Abs(Mathf.Sin(_barrierLimitingFactor * onGroundPositionX)) > 0.9 ? true : false;
    }
    
    private bool ReturnPossibilityToPlaceBarrier(bool randomObstacle, bool placeWhereObstacleCanStand)
    {
        return randomObstacle && placeWhereObstacleCanStand ? true : false;
    }

    private StateInGrid ReturnCoinOrNothing(int onGroundPositionX)
    {
        return Mathf.PerlinNoise((float)onGroundPositionX, 0.9f) > _coinRandomizationRate ? StateInGrid.Coin : StateInGrid.Nothing;
    }
}