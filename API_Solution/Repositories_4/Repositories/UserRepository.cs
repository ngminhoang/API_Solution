using API_6._0_4.DBcontext;
using API_6._0_4.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_4.Repositories
{
    public class UserRepository: RepositoryInterface<User>
    {
        private EF_DBcontext _dbcontext;
        public UserRepository(EF_DBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //HAM LAY TOAN BO DOI TUONG
        public List<Object> getAll()
        {
            try
            {
                List<User> rs = _dbcontext.Users.ToList();
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
                var rs = _dbcontext.Users.FirstOrDefault(t => t.UserId == id);
                return rs;
            }
            catch (Exception ex) { throw ex; }
        }

        //HAM CREATE
        public void create(Object UserPar)
        {
            try
            {
                User User = (User)UserPar;
                _dbcontext.Users.Add(User);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }
        //HAM UPDATE
        public void update(Object UserPar)
        {
            try
            {
                User User = (User)UserPar;
                _dbcontext.Users.Update(User);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }
        //HAM DELETE
        public void delete(Object UserPar)
        {
            try
            {
                User User = (User)UserPar;
                _dbcontext.Users.Remove(User);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex) { throw ex; }
        }

        //HAM LAY MAX ID
        public int maxID()
        {
            try
            {
                var maxIDUser = _dbcontext.Users.OrderByDescending(t => t.UserId).FirstOrDefault();
                if (maxIDUser == null) return 0;
                return maxIDUser.UserId;
            }
            catch (Exception ex) { return 0; }
        }

        //HAM LAY DANH SACH TINH (khong dung)
        public List<Ward> getWardByDistrictID(int id) => null;

        //HAM LAY DANH SACH HUYEN (khong dung)
        public List<District> getDistrictByProvinceID(int id) => null;
    }
}
