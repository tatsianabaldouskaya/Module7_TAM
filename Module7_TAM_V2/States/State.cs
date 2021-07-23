using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7_TAM_V2.States
{
    public abstract class State
    {
        protected FolderD folderD;
        protected int level;

        public FolderD FolderD
        {
            get { return folderD; }
            set { folderD = value; }
        }

        public abstract void Highlight();
        public abstract void UnHighlight();
    }
}
