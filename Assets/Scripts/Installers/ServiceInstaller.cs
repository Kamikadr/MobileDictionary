using Common.Interfaces;
using Common.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ServiceInstaller : MonoInstaller
{
    [SerializeField] DialogService dialogService;
    public override void InstallBindings()
    {
        Container.Bind<IDialogService>().FromInstance(dialogService).AsSingle();
    }
}
