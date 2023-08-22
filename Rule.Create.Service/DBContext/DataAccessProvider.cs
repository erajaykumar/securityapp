


namespace Rule.Create.Service
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly RuleDbContext _context;
      
        public DataAccessProvider(RuleDbContext context)
        {
            _context = context;
         
        }

        void IDataAccessProvider.CreateRules(Rules rules)
        {
           
            _context.Rules.Add(rules);
            _context.SaveChanges();
        }

       
        void IDataAccessProvider.DeleteRule(int id)
        {
            var entity = _context.Rules.FirstOrDefault(t => t.RuleId ==id);
            _context.Rules.Remove(entity);
            _context.SaveChanges();
        }

        Rules IDataAccessProvider.GetRule(int id)
        {
            return _context.Rules.FirstOrDefault(t => t.RuleId == id);
        }

        List<Rules> IDataAccessProvider.GetRules()
        {
            return _context.Rules.ToList();
        }

        void IDataAccessProvider.UpdateRule(Rules rules)
        {
            
            _context.Rules.Update(rules);
            _context.SaveChanges();
        }
    }
}
