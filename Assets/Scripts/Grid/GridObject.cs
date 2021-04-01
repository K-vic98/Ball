using UnityEngine;

[System.Serializable]
struct GridObject
{
    [SerializeField] private GameObject _gameObjectTemplate;
    [SerializeField] private StateInGrid _stateInGrid;

    public GameObject GameObjectTemplate => _gameObjectTemplate;
    public StateInGrid StateInGrid => _stateInGrid;
}