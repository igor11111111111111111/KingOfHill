using UnityEngine;
using Zenject;

namespace KingOfHill
{
    public class SceneMonoInstaller : MonoInstaller
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
        public enum ID
        {
            EnemyParent
        }

        public override void InstallBindings()
        {
            EnemyParentTransform();
            Camera();
            UI();
            SaveExistanceChecker();
            Player();
            EnemyPool();
            EnemySpawner();
            ScoreData();
            EnemyDeathArea();

            InputSystem();
            MoveStairsSystem();
            CameraFollowSystem();
            ScoreRefreshSystem();
            ScoreSaveSystem();
        }

        private void EnemyDeathArea()
        {
            Container.QueueForInject(_enemyDeathArea);
        }

        private void ScoreSaveSystem()
        {
            Container
                .BindInterfacesAndSelfTo<ScoreSaveSystem>()
                .FromNew()
                .AsSingle();
        }

        private void ScoreRefreshSystem()
        {
            Container.QueueForInject(new ScoreRefreshSystem());
        }

        private void ScoreData()
        {
            Container
                .Bind<ScoreData>()
                .FromNew()
                .AsSingle();
        }

        private void EnemySpawner()
        {
            Container
                .QueueForInject(new EnemySpawner());
        }

        private void EnemyPool()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyPool>()
                .FromNew()
                .AsSingle();
        }

        private void CameraFollowSystem()
        {
            Container
                .QueueForInject(gameObject.AddComponent<CameraFollowSystem>());
        }

        private void MoveStairsSystem()
        {
            Container
                .BindInterfacesAndSelfTo<MoveStairsSystem>()
                .FromInstance(_stairs)
                .AsSingle();
        }

        private void Player()
        {
            Container
                .BindInterfacesAndSelfTo<Player>()
                .FromComponentInNewPrefabResource(nameof(KingOfHill.Player))
                .AsSingle();
        }

        private void InputSystem()
        {
            Container
                .Bind<IInputSystem>()
                .To<MobileInputSystem>()
                .FromNewComponentOn(_ui.gameObject)
                .AsSingle();
        }

        private static void SaveExistanceChecker()
        {
            new SaveExistanceChecker();
        }

        private void UI()
        {
            Container
                .BindInterfacesAndSelfTo<UI>()
                .FromInstance(_ui)
                .AsSingle();
        }

        private void Camera()
        {
            Container
                .Bind<Camera>()
                .FromInstance(_camera)
                .AsSingle();
        }

        private void EnemyParentTransform()
        {
            Container
                .Bind<Transform>()
                .WithId(ID.EnemyParent)
                .FromInstance(_enemyParent)
                .AsSingle();
        }
    }
}

