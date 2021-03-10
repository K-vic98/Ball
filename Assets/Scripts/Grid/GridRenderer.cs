using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(GridGenerator))]
public class GridRenderer : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    [SerializeField] private GridObject[] _templates;
    [SerializeField] private int _gridSizeInLength;
    [SerializeField] private float _timeAfterWhichBlockWillDelete;

    private GridGenerator _gridGenerator;
    private List<int> _pointsWhereDoNotNeedToDrawGrid = new List<int>();
    private Queue<GameObject> _queueWithGameObjectsToDelete = new Queue<GameObject>();
    private float _runningTime;

    private void Awake()
    {
        _gridGenerator = gameObject.GetComponent<GridGenerator>();
    }

    private void Start()
    {
        DrawGrid(TranslateWorldToGridPosition(_ball.position) + new Vector2Int(-_gridSizeInLength, 0));
    }

    private void Update()
    {
        if (TranslateWorldToGridPosition(_ball.position).x % _gridSizeInLength == 0 && !_pointsWhereDoNotNeedToDrawGrid.Contains(TranslateWorldToGridPosition(_ball.position).x))
            DrawGrid(TranslateWorldToGridPosition(_ball.position));

        _runningTime += Time.deltaTime;

        if (_runningTime >= _timeAfterWhichBlockWillDelete)
        {
            Destroy(_queueWithGameObjectsToDelete.Dequeue());
            _runningTime = 0;
        }
    }

    private void DrawGrid(Vector2Int playerPosition)
    {
        Vector2Int playerPositionOnGrid = playerPosition + new Vector2Int(10, 0);
        playerPositionOnGrid.y = 0;

        for (int i = 0; i < _gridSizeInLength; i++)
        {
            Vector2Int OnGroundPosition = playerPositionOnGrid + new Vector2Int(i, 0);
            Vector2Int GroundPosition = playerPositionOnGrid + new Vector2Int(i, -1);

            StateInGrid onGroundState = _gridGenerator.GenerateStateAtTopOfGrid(OnGroundPosition.x);
            StateInGrid groundState = StateInGrid.Ground;

            GameObject onGroundGameObject = Instantiate(_templates.First(template => template.StateInGrid == onGroundState).GameObjectTemplate, TranslateGridToWorldPosition(OnGroundPosition), Quaternion.identity);
            GameObject groundGameObject = Instantiate(_templates.First(template => template.StateInGrid == groundState).GameObjectTemplate, TranslateGridToWorldPosition(GroundPosition), Quaternion.identity);

            _queueWithGameObjectsToDelete.Enqueue(onGroundGameObject);
            _queueWithGameObjectsToDelete.Enqueue(groundGameObject);
        }

        _pointsWhereDoNotNeedToDrawGrid.Add(TranslateWorldToGridPosition(playerPosition).x);
    }

    private Vector2 TranslateGridToWorldPosition(Vector2Int gridPosition)
    {
        return new Vector2(gridPosition.x, gridPosition.y);
    }

    private Vector2Int TranslateWorldToGridPosition(Vector2 worldPosition)
    {
        return new Vector2Int((int)worldPosition.x, (int)worldPosition.y);
    }
}