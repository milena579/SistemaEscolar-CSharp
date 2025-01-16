
namespace Model;

public class AlunoFakeRepository : IRepository<Aluno>
{
    List<Aluno> alunos = [];

    public AlunoFakeRepository(){
        alunos.Add(new () {Nome =  "Milena", Idade = 19});
    }
    public List<Aluno> All => alunos;

    public void Add(Aluno obj) => this.alunos.Add(obj);

    public string findByID(int findByID)
    {
        for(int i = 0; i < alunos.Count; i++){
            if(findByID == alunos[i].Id ){
                return alunos[i].Nome;
            }
        }   
        return null;
    }
}