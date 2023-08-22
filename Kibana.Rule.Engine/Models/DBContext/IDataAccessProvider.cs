
using Kibana.Rule.Engine.Models;
using Kibana.Rule.Engine.Models.RequestDto;
using Nest;
using System.Threading.Tasks;

namespace Rule.Engine.Kibana
{
    public interface IDataAccessProvider
    {
        void CreateRules(Rules rules);
        void UpdateRule(Rules rules);
        void DeleteRule(int id);
       Rules GetRule(int id);
        List<Rules> GetRules();
    }
}
