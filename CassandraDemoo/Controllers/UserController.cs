using Cassandra;
using Cassandra.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CassandraAzure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private ICluster _cluster;
        private ISession _session;
        public UserController()
        {
            _cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            _session = _cluster.Connect("tutorialspoint");
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            IMapper mapper = new Mapper(_session);
            var users = mapper.Fetch<User>("Select * from users;").ToList();
            return users;
        }
    }
}
