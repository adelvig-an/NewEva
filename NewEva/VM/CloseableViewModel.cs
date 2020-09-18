using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.VM
{
    public abstract class CloseableViewModel : ViewModelBase
    {
        public event EventHandler ClosingRequest;

        public void OnClosingRequest()
        {
            if (this.ClosingRequest != null)
            {
                this.ClosingRequest(this, EventArgs.Empty);
            }
        }
    }
}
