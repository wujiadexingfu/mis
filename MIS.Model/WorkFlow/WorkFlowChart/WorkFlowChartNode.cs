using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Model.WorkFlow.WorkFlowChart
{
  public  class WorkFlowChartNode
    {
        public string Title { get; set; }

        public Dictionary<string, object> Nodes { get; set; }

        public Dictionary<string, object> Lines { get; set; }

        public WorkFlowChartNode()
        {
            Nodes = new Dictionary<string, object>();
            Lines = new Dictionary<string, object>();
        }
    }
}
