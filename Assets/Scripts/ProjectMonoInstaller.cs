using UnityEngine;
using Zenject;

namespace KingOfHill
{
    public class ProjectMonoInstaller : MonoInstaller
    {
        [SerializeField]
        private SoundManager _soundManager;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<SoundManager>()
                .FromInstance(_soundManager)
                .AsSingle();
        }
    }
}

