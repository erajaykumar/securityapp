using AutoMapper;
using Kibana.Rule.Engine.Models;
using Kibana.Rule.Engine.Models.RequestDto;
using Nest;

namespace Rule.Engine.Kibana
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly RuleDbContext _context;
      
        public DataAccessProvider(RuleDbContext context, IMapper mapper)
        {
            _context = context;
         
        }

        void IDataAccessProvider.CreateRules(Rules rules)
        {
           
            _context.Rules_Table.Add(rules);
            _context.SaveChanges();
        }

       
        void IDataAccessProvider.DeleteRule(int id)
        {
            var entity = _context.Rules_Table.FirstOrDefault(t => t.RuleId ==id);
            _context.Rules_Table.Remove(entity);
            _context.SaveChanges();
        }

        Rules IDataAccessProvider.GetRule(int id)
        {
            return _context.Rules_Table.FirstOrDefault(t => t.RuleId == id);
        }

        List<Rules> IDataAccessProvider.GetRules()
        {
            return _context.Rules_Table.ToList();
        }

        void IDataAccessProvider.UpdateRule(Rules rules)
        {
            
            _context.Rules_Table.Update(rules);
            _context.SaveChanges();
        }
    }
}
