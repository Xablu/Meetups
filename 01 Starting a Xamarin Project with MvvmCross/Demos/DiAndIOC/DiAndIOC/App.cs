using DiAndIOC.Core.Interfaces;
using DiAndIOC.Core.Provider;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace DiAndIOC.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterType<ITextProvider, HelloTextProvider>();
            //Mvx.RegisterType<ITextProvider, GoodbyeTextProvider>();

            RegisterAppStart<ViewModels.FirstViewModel>();
        }
    }
}
