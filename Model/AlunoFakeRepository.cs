
namespace Model;

public class AlunoFakeRepository : IRepository<Aluno>
{
    List<Aluno> alunos = [];

    public AlunoFakeRepository(){
        alunos.Add(new () {Nome =  "Milena", Idade = 19});
    }
    public List<Aluno> All => alunos;

    public void Add(Aluno obj) => this.alunos.Add(obj);
    
}