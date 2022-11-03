using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;


namespace Ju.GundamWars.ViewModels
{

    public class MessageDialogViewModel : DisposableBindableBase
    {

        public MessageDialogViewModel()
        {
            IconKind = new ReactivePropertySlim<string>("Alert").AddTo(Disposables);
            Message = new ReactivePropertySlim<string>("").AddTo(Disposables);
        }


        public ReactivePropertySlim<string> IconKind { get; }
        public ReactivePropertySlim<string> Message { get; }

    }

}
