using API_6._0_4.DBcontext;

namespace API_6._0_4.Repositories
{
    public interface RepositoryInterface<T> where T : class
    {
        List<Object> getAll();
        Object select(int id);
        void create(Object entity);
        void update(Object entity);
        void delete(Object entity);
        int maxID();
        List<District> getDistrictByProvinceID(int provinceID);
        List<Ward> getWardByDistrictID(int districtID);
    }
 }
