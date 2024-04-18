using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //if (SystemInfo.deviceType == DeviceType.Handheld)
        //{
            IInput _mobileInput = GetComponent<MobileInput>();
            GetComponent<MobileInput>().enabled = true;
            Container.Bind<IInput>().FromInstance(_mobileInput).NonLazy();
            Debug.Log("Mobile input injected.");
        //}
        //else if (SystemInfo.deviceType == DeviceType.Desktop)
        //{
        //    IInput _mobileInput = GetComponent<DesktopInput>();
        //    GetComponent<DesktopInput>().enabled = true;
        //    Container.Bind<IInput>().FromInstance(_mobileInput).NonLazy();
        //    Debug.Log("Desktop input injected.");
        //}
    }
}