
using System.Threading.Tasks;

namespace Rule.Create.Service
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
