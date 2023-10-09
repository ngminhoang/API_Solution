using API_6._0_4.DBcontext;

namespace API_6._0_4.Repositories
{
    public class DistrictRepository : RepositoryInterface<District>
    {
        private EF_DBcontext _dbcontext;
        public DistrictRepository(EF_DBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //HAM LAY TOAN BO DOI TUONG
        public List<Object> getAll()
        {
            try
            {
                List<District> rs = _dbcontext.Districts.ToList();
                List<Object> list = rs.ConvertAll(x => (object)x); 
                return list;
            }
            catch (Exception ex) { throw ex; }
        }

        //HAM READ
        public Object select(int id)
        {
            try
            {
                var rs = _dbcontext.Districts.FirstOrDefault(t => t.districtID == id);
                return rs;
            }
            catch (Exception ex) { throw ex; }
        }

        //HAM CREATE
        public void create(Object districtPar)
        {
            try
            {
                
                District district = (District) districtPar;
                _dbcontext.Districts.Add(district);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }

        //HAM UPDATE
        public void update(Object districtPar)
        {
            try
            {
                District district = (District)districtPar;
                _dbcontext.Districts.Update(district);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }

        //HAM DELETE
        public void delete(Object districtPar)
        {
            try
            {
                District district = (District)districtPar;
                _dbcontext.Districts.Remove(district);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }

        //HAM LAY MAX ID
        public int maxID()
        {
            try
            {
                var maxIDDistrict = _dbcontext.Districts.OrderByDescending(t => t.districtID).FirstOrDefault();
                if (maxIDDistrict == null) return 0;
                return maxIDDistrict.districtID;
            }
            catch (Exception ex) { return 0; }
        }

        //HAM LAY DANH SACH Ward 
        public List<Ward> getWardByDistrictID(int districtID)
        {
            var WardList = _dbcontext.Wards
                .Where(h => h.districtID == districtID)
                .ToList();

            return WardList;
        }

        //HAM LAY DANH SACH HUYEN (khong dung)
        public List<District> getDistrictByProvinceID(int id) => null;
    }
}
