using System;
using System.ComponentModel;

namespace GenericBackgroundWorker
{
    public abstract class BackgroundWorkerBase<T>
    {
        private readonly BackgroundWorker _bw = new BackgroundWorker();

        private T _workerObj;

        public BackgroundWorkerBase(T obj)
        {
            _workerObj = obj;
            _bw.DoWork += Bw_DoWork;
            _bw.ProgressChanged += Bw_ProgressChanged;
            _bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            _bw.WorkerSupportsCancellation = true;
            _bw.WorkerReportsProgress = true;
        }

        public bool IsWorkerBusy
        {
            get => _bw.IsBusy;
        }

        public void StartWorker()
        {
            _bw.RunWorkerAsync(_workerObj);
        }

        public void ReportProgressChanged(double percentComplete, object progressObject)
        {
            _bw.ReportProgress((int) Math.Ceiling(percentComplete), progressObject);
        }

        public void AbortWorker()
        {
            if (_bw.IsBusy)
                _bw.CancelAsync();
        }

        public bool IsAborted
        {
            get => _bw.CancellationPending;
        }

        protected abstract void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e);

        protected abstract void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e);

        protected abstract void Bw_DoWork(object sender, DoWorkEventArgs e);
    }
}
