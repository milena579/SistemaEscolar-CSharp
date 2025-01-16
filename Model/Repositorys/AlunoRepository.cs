
namespace Model;

using System.ComponentModel;
using DataBase;
public class AlunoRepository : IRepository<Aluno>
{
    
    DB<Aluno> banco = DB<Aluno>.App;

    public List<Aluno> All => banco.All;

    public void Add(Aluno obj) {
        var aluno = banco.All;
        aluno.Add(obj);
        banco.Save(aluno);
    }
    public string findByID(int findByID)
    {
        var alunos =  banco.All;
        
        for(int i = 0; i < alunos.Count; i++){
            if(findByID == alunos[i].Id ){
                return alunos[i].Nome;
            }
        }   
        return null;
    }
}