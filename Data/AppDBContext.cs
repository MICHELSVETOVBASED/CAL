using Microsoft.EntityFrameworkCore;

namespace CALCLACLACLACLACL.Data;

public class AppDBContext : DbContext{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options){
        
    }
}