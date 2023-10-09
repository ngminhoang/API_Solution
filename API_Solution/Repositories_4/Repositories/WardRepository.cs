using API_6._0_4.DBcontext;

namespace API_6._0_4.Repositories
{
    public class WardRepository: RepositoryInterface<Ward>
    {
        private EF_DBcontext _dbcontext;
        public WardRepository(EF_DBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        
        //HAM LAY TOAN BO DOI TUONG
        public List<Object> getAll()
        {
            try
            {
                List<Ward > rs = _dbcontext.Wards.ToList();
                List<Object> list = rs.ConvertAll(x => (object)x);
                return list;
            }
            catch (Exception ex) { throw ex; }
        }

        //HAM READ
        public Object  select(int id)
        {
            try
            {
                var rs = _dbcontext.Wards.FirstOrDefault(t => t.wardID == id);
                return rs;
            }
            catch (Exception ex) { throw ex; }
        }

        //HAM CREATE
        public void create(Object wardPar)
        {
            try
            {
                Ward ward = (Ward)wardPar;
                _dbcontext.Wards.Add(ward);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }
        //HAM UPDATE
        public void update(Object wardPar)
        {
            try
            {
                Ward ward = (Ward)wardPar;
                _dbcontext.Wards.Update(ward);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }
        //HAM DELETE
        public void delete(Object wardPar)
        {
            try
            {
                Ward ward = (Ward)wardPar;
                _dbcontext.Wards.Remove(ward);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }

        //HAM LAY MAX ID
        public int maxID()
        {
            try { 
            var maxIDWard = _dbcontext.Wards.OrderByDescending(t => t.wardID).FirstOrDefault();
                if (maxIDWard == null) return 0;
                return maxIDWard.wardID; }
            catch (Exception ex) { return 0; }
        }

        //HAM LAY DANH SACH TINH (khong dung)
        public List<Ward> getWardByDistrictID(int id)=> null;

        //HAM LAY DANH SACH HUYEN (khong dung)
        public List<District> getDistrictByProvinceID(int id)=> null;
    }
}
