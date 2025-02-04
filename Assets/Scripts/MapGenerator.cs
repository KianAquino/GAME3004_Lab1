using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] Vector2 _size = new Vector2(3, 3);
    [SerializeField] GameObject _startTile;
    [SerializeField] GameObject _mazeTile;
    [SerializeField] GameObject _endTile;

    private Vector2 _tileSize = new Vector2(16, 16);

    private void Start()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        GameObject map = new GameObject("Generated Maze");

        // Row
        for (int row = 0; row < _size.x; row++)
        {
            // Column
            for (int col = 0; col < _size.y; col++)
            {
                GameObject tile;

                // Start Tile
                if (row == 0 && col == 0)
                    tile = Instantiate(_startTile, map.transform);
                // End Tile
                else if (row == _size.x - 1 && col == _size.y - 1)
                    tile = Instantiate(_endTile, map.transform);
                // Regular Maze Tile
                else
                    tile = Instantiate(_mazeTile, map.transform);

                tile.transform.position = new Vector3(_tileSize.x * row, 0,_tileSize.y * col);
            }
        }
    }

    private void OnValidate()
    {
        _size.x = Mathf.FloorToInt(_size.x);
        _size.y = Mathf.FloorToInt(_size.y);

        _size.x = _size.x < 3 ? 3 : _size.x;
        _size.y = _size.y < 3 ? 3 : _size.y;
    }
}
