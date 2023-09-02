using UnityEngine;

namespace KingOfHill
{
    public class SceneInit : MonoBehaviour
    {
        [SerializeField]
        private Player _playerPrefab;
        [SerializeField]
        private Enemy _enemyPrefab;
        [SerializeField]
        private Transform _enemyParent;
        [SerializeField]
        private Camera _camera;
        [SerializeField]
        private Stairs _stairs;
        [SerializeField]
        private MobileInput _mobileInput;
        [SerializeField]
        private EnemyDeathArea _enemyDeathArea;
        [SerializeField]
        private UI _ui;

        private void Awake()
        {
            var player = new PlayerSpawner(_playerPrefab)
                        .Create()
                        .Init(_mobileInput);

            _stairs.Init(player.Trigger);

            gameObject
                .AddComponent<CameraFollowSystem>()
                .Init(player, _camera);

            var enemyPool = new EnemyPool(_enemyPrefab, 5, _enemyParent, _stairs);
            gameObject
                .AddComponent<EnemySpawner>()
                .Init(enemyPool, player)
                .StartSpawn();

            var scoreData = new ScoreData();
            new ScoreRefreshSystem(scoreData, player.Trigger, _ui.CurrentScoreUI);
            new ScoreSaveSystem(_ui.SaveScoreUI, _ui.AllPlayersScoreUI, scoreData);

            _enemyDeathArea.Init(player.Trigger, _stairs);

            _ui.Init(player.Trigger, scoreData);
        }
    }
}

