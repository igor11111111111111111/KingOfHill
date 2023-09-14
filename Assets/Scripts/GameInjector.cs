using UnityEngine;

namespace KingOfHill
{
    public class GameInjector : MonoBehaviour
    {
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
        [SerializeField]
        private SoundManager _soundManager;

        private void Awake()
        {
            new SaveExistanceChecker();

            var inputSystem = _ui.gameObject.AddComponent<MobileInputSystem>();

            var playerPrefab = Resources.Load<Player>(nameof(Player));
            var player = new PlayerSpawner(playerPrefab).Create(inputSystem);

            _stairs.Init(player.Trigger);

            gameObject
                .AddComponent<CameraFollowSystem>()
                .Init(player.transform, _camera);

            EnemyInit(player);

            var scoreData = ScoreInit(player);

            _enemyDeathArea.Init(player.Trigger, _stairs);

            _ui.Init(player.Trigger, scoreData);

            _soundManager.Init();
        }

        private void EnemyInit(Player player)
        {
            var enemyPrefab = Resources.Load<Enemy>(nameof(Enemy));
            var enemyPool = new EnemyPool(enemyPrefab, 5, _enemyParent, _stairs);
            gameObject
                .AddComponent<EnemySpawner>()
                .Init(enemyPool, player.transform)
                .StartSpawn();
        }

        private ScoreData ScoreInit(Player player)
        {
            var scoreData = new ScoreData();
            new ScoreRefreshSystem(scoreData, player.Trigger, _ui.CurrentScoreUI);
            new ScoreSaveSystem(_ui.SaveScoreUI, scoreData);
            return scoreData;
        }
    }
}

