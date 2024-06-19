using AnimalCatcher.Components;
using AnimalCatcher.Controllers;
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
            Container.BindInterfacesTo<GameAreaPositionController>().FromComponentInHierarchy().AsSingle();
        }

        private void InstallFactories()
        {
            Container.BindFactory<Object, Character, Character.Factory>().FromFactory<PrefabFactory<Character>>();
            Container.BindInterfacesAndSelfTo<CharacterSpawner>().AsSingle().WithArguments(characterPrefab);
        }

        private void InstallSceneControllers()
        {
            
        }
    }   
}