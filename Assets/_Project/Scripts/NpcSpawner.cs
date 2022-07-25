using UnityEngine;
using Random = UnityEngine.Random;

public class NpcSpawner : MonoBehaviour
{
    [SerializeField] private Transform _slimePrefab;
    [SerializeField] private Collider2D _spawnArea;

    private IInputService _input;
    private bool _isReadyToSpawn;

    private void Awake()
    {
        _input = ServiceLocator.Container.Single<IInputService>();
        _isReadyToSpawn = _slimePrefab != null;
    }

    private void OnEnable() 
        => _input.SpawnButtonClick += OnSpawnButtonClick;

    private void OnDisable() 
        => _input.SpawnButtonClick -= OnSpawnButtonClick;

    private void OnSpawnButtonClick()
    {
        if (!_isReadyToSpawn)
        {
            return;
        }

        SpawnNpc();
    }

    private void SpawnNpc()
    {
        _isReadyToSpawn = false;
        Instantiate(_slimePrefab, GetRandomPositionAtSpawnArea(), Quaternion.identity, _spawnArea.transform);
    }

    private Vector2 GetRandomPositionAtSpawnArea()
    {
        _spawnArea.enabled = true;
        var spawnPosition3d = _spawnArea.transform.position;
        var spawnPosition2d = new Vector2(spawnPosition3d.x, spawnPosition3d.y);
        spawnPosition2d += _spawnArea.offset;
        Bounds bounds = _spawnArea.bounds;
        float x = Random.Range(spawnPosition2d.x - bounds.size.x * 0.5f, spawnPosition2d.x + bounds.size.x * 0.5f);
        float y = Random.Range(spawnPosition2d.y - bounds.size.y * 0.5f, spawnPosition2d.y + bounds.size.y * 0.5f);
        _spawnArea.enabled = false;

        return new Vector2(x, y);
    }
}