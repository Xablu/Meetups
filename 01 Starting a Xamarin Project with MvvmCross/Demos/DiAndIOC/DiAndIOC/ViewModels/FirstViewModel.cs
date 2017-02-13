using DiAndIOC.Core.Interfaces;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace DiAndIOC.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private string _hello = "Hello MvvmCross";
        public string Hello
        { 
            get { return _hello; }
            set { SetProperty (ref _hello, value); }
        }


        public FirstViewModel(ITextProvider textprovider)
        {
            Hello = textprovider.Text;
        }

        //public FirstViewModel()
        //{
        //    var textProvider = Mvx.Resolve<ITextProvider>();
        //    Hello = textProvider.Text;
        //}
    }
}
