using Common.Interfaces;
using Common.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMvvmToolkit.Core.Interfaces;
using UnityMvvmToolkit.UITK;
using ViewModels;
using Zenject;

public class AppInstaller: MonoInstaller
{
    [SerializeField] DialogService dialogService;
    public override void InstallBindings()
    {
        Container.Bind<IDialogService>().FromInstance(dialogService).AsSingle();

        Container.Bind<IBindableElementsFactory>().FromInstance(new CustomBindableFactory()).AsSingle();
        Container.Bind<IntroViewModel>()
            .FromInstance(new IntroViewModel()).AsSingle();
        Container.Bind<LogInViewModel>().
            FromInstance(new LogInViewModel(dialogService)).AsSingle();

        Container.Bind<DictionaryViewModel>()
            .FromInstance(new DictionaryViewModel()).AsSingle();

        Container.Bind<TrainingViewModel>()
            .FromInstance(new TrainingViewModel()).AsSingle();
        Container.Bind<VideoViewModel>()
            .FromInstance(new VideoViewModel()).AsSingle();
        Container.Bind<BottomBarViewModel>()
            .FromInstance(new BottomBarViewModel()).AsSingle();
    }

}
