using AnimalCatcher.Components;
using Components;
using Controllers;
using Controllers.Spawners;
using UnityEngine;
using Zenject;

namespace AnimalCatcher.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [Header("Factories Components")] 
        [SerializeField] private Character characterPrefab;
        
        public override void InstallBindings()
        {
            InstallSceneComponents();
            InstallFactories();
            InstallSceneControllers();
        }

        private void InstallSceneComponents()
        {
            Container.BindInterfacesTo<CameraComponent>().FromComponentInHierarchy().AsSingle();
        }

        private void InstallFactories()
        {
            Container.BindFactory<Object, Character, Character.Factory>().FromFactory<PrefabFactory<Character>>();
            Container.BindInterfacesAndSelfTo<CharacterSpawner>().AsSingle().WithArguments(characterPrefab);
        }

        private void InstallSceneControllers()
        {
            Container.BindInterfacesTo<GameStarter>().AsSingle();
        }
    }   
}