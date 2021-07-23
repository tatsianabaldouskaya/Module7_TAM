using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7_TAM_V2.States
{
    public class FolderD
    {
        private State state;

        public FolderD()
        {
            this.state = new UnhighlightedState(state);
        }

        public State State
        {
            get { return state; }
            set { state = value; }
        }

        public void HighLight()
        {
            state.Highlight();
        }

        public void UnHighlight()
        {
            state.UnHighlight();
        }
    }
}
