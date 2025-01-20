
using DataBase;
using Model;

public class AlunoDBRepository : IRepository<Aluno>
{
    protected DBSqlServer<Aluno> db;
    public AlunoDBRepository(){
         
        db =  new DBSqlServer<Aluno>(
            "CA-C-0064V/SQLEXPRESS",
            "SistemaEscolar"
        );
        
    }
    public List<Aluno> All => db.All;
    public void Add(Aluno obj)
    {
        db.Save(obj);
    }

    public string findByID(int findByID)
    {
        throw new NotImplementedException();
    }
}