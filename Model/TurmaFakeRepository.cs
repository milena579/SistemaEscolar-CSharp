
using Model.Repository;

namespace Model;

public class TurmaFakeRepository : IRepository<Turma>
{
    List<Turma> turmas = [];

    public TurmaFakeRepository(){
        
    }
    public List<Turma> All => turmas;

    public void Add(Turma obj) => this.turmas.Add(obj);
}