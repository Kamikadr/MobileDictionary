using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMvvmToolkit.Core.Interfaces;
using UnityMvvmToolkit.UITK;
using ViewModels;
using Zenject;

public class AppInstaller: MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IBindableElementsFactory>().FromInstance(new CustomBindableFactory()).AsSingle();
        Container.Bind<IntroViewModel>()
            .FromInstance(new IntroViewModel()).AsSingle();
        
    }

}
