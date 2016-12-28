using SharpDX.Windows;
using System.Drawing;
using System.Threading.Tasks;

namespace CellularAutomata.View
{
    public class RenderWindow : System.IDisposable
    {
        private readonly RenderForm _renderForm;

        private const int Width = 1280;
        private const int Height = 720;

        public RenderWindow()
        {
            _renderForm = new RenderForm("My first SharpDX game");
            _renderForm.ClientSize = new Size(Width, Height);
            _renderForm.AllowUserResizing = false;
        }

        public void Run()
        {
            RenderLoop.Run(_renderForm, RenderCallback);
        }

        private void RenderCallback()
        {

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _renderForm.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~RenderWindow() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
