using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace VsPostman
{
    public class PostmanToolWindowControlViewModel : ControlBase
    {
        public PostmanToolWindowControlViewModel ()
	    {
            SendRequestCommand = new SimpleCommand(DummyAction);
	    }
        
        public string Url { get; set; } = "Enter your Url here";
        public ICommand SendRequestCommand{get;set;}

        public void DummyAction()
        {

        }
    }
}
