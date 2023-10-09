using API_6._0_4.DBcontext;
using Microsoft.EntityFrameworkCore;

namespace API_6._0_4.Repositories
{
    public class ProvinceRepository : RepositoryInterface<Province>
    {
        private EF_DBcontext _dbcontext;
        public ProvinceRepository(EF_DBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

       

        //HAM LAY TOAN BO DOI TUONG
        public List<Object> getAll() {
            try
            {

                List<Province> rs = _dbcontext.Provinces.ToList();
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
                var rs = _dbcontext.Provinces.FirstOrDefault(t => t.provinceID == id);
                return rs;
            }
            catch (Exception ex) { throw ex; }
        }

        //HAM CREATE
        public void create(Object provincePar)
        {
            try
            {
                Province province = (Province)provincePar;
                _dbcontext.Provinces.Add(province);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }

        //HAM UPDATE
        public void update(Object provincePar)
        {
            try
            {
                Province province = (Province)provincePar;
                _dbcontext.Provinces.Update(province);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }

        //HAM DELETE
        public void delete(Object provincePar)
        {
            try
            {
                Province province = (Province)provincePar;
                _dbcontext.Provinces.Remove(province);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }

        //HAM LAY MAX ID
        public int maxID()
        {
            try
            {
                var maxIDProvince = _dbcontext.Provinces.OrderByDescending(t => t.provinceID).FirstOrDefault();
                if (maxIDProvince == null) return 0;
                return maxIDProvince.provinceID;
            }
            catch(Exception ex) { return 0; }
        }

        //HAM LAY DANH SACH HUYEN
        public List<District> getDistrictByProvinceID(int id)
        {
            var DistrictList = _dbcontext.Districts
                .Where(h => h.provinceID == id)
                .ToList();

            return DistrictList;
        }

        //HAM LAY DANH SACH TINH (khong dung)
        public List<Ward> getWardByDistrictID(int id) => null;
    }
}
