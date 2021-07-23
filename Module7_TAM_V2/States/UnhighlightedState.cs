using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7_TAM_V2.States
{
    public class UnhighlightedState : State
    {
        public UnhighlightedState(State state)
        {
            this.folderD = state.FolderD;
        }

        public override void Highlight()
        {
            level = 1;
            StateChangeCheck();
        }

        public override void UnHighlight()
        {
            level = 0;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            switch (level)
            {
                case 0:
                    folderD.State = this;
                    break;
                case 1:
                    folderD.State = new HighlightedState(this);
                    break;
                case 2:
                    folderD.State = new UnhighlightedState(this);
                    break;
            }
        }
    }
}
