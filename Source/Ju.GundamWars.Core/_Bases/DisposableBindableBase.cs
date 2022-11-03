using System;
using System.Reactive.Disposables;


namespace Ju.GundamWars
{

    public abstract class DisposableBindableBase : BindableBase, IDisposable
    {

        #region ==== Implementation of IDisposable ====

        private bool isDisposed = false;

        protected CompositeDisposable Disposables { get; } = new();


        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    Disposables.Dispose();
                }
                isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }

}
