using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    private IInput _mobileInput;
    //private IInput _desctopInput;

    public override void InstallBindings()
    {

        _mobileInput = GetComponent<MobileInput>();
        Container.Bind<IInput>().FromInstance(_mobileInput).NonLazy();
        Debug.Log("Mobile input injected.");

    }
}