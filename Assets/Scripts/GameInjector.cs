using UnityEngine;

namespace KingOfHill
{
    public class GameInjector : MonoBehaviour
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
        private MoveStairsSystem _stairs;
        [SerializeField]
        private EnemyDeathArea _enemyDeathArea;
        [SerializeField]
        private UI _ui;

        private void Awake()
        {
            var inputSystem = _ui.gameObject.AddComponent<MobileInputSystem>();

            var player = new PlayerSpawner(_playerPrefab).Create(inputSystem);

            _stairs.Init(player.Trigger);

            gameObject
                .AddComponent<CameraFollowSystem>()
                .Init(player.transform, _camera);

            EnemyInit(player);

            var scoreData = ScoreInit(player);

            _enemyDeathArea.Init(player.Trigger, _stairs);

            _ui.Init(player.Trigger, scoreData);
        }

        private void EnemyInit(Player player)
        {
            var enemyPool = new EnemyPool(_enemyPrefab, 5, _enemyParent, _stairs);
            gameObject
                .AddComponent<EnemySpawner>()
                .Init(enemyPool, player.transform)
                .StartSpawn();
        }

        private ScoreData ScoreInit(Player player)
        {
            var scoreData = new ScoreData();
            new ScoreRefreshSystem(scoreData, player.Trigger, _ui.CurrentScoreUI);
            new ScoreSaveSystem(_ui, scoreData);
            return scoreData;
        }
    }
}

