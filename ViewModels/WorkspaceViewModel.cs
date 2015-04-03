using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetrics.Commands;

namespace Timetrics.ViewModels
{

    public delegate void OnRequestClosed(object Sender, EventArgs e);

    public class WorkspaceViewModel : ViewModelBase
    {

        #region Constructors

        public WorkspaceViewModel()
        {
            //Initially, all workspaces can close.
            CanClose = true;
        }

        #endregion

        #region Properties

        public bool CanClose { get; set; }

        #endregion

        #region Commands

        private RelayCommand _CloseCommand;

        public RelayCommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                {
                    _CloseCommand = new RelayCommand(param => this.Close(), param => this.CanClose);
                }
                return _CloseCommand;                
            }
        }

        public virtual void Close()
        {
            OnClose(EventArgs.Empty);
        }
        #endregion

        #region Methods

        //Nothing here yet.

        #endregion

        #region Events
        ///<summary>Workspace Base Class Specific Events</summary>
        /// 
        /// 
        /// <summary>
        /// Allows workspace to close.
        /// </summary>
        /// <param name="Sender">Standard event handler sender.</param>
        /// <param name="e">Standard event args.</param>

        /// <summary>
        /// Event sent by requesting that the workspace closes. This can mean different things in different workspace contexts.
        /// </summary>
        public event OnRequestClosed RequestClose;

        protected virtual void OnClose(EventArgs e)
        {
            if (RequestClose != null)
            {
                RequestClose(this, e);
            }
        }

        #endregion

    }
}
