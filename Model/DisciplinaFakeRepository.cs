
using Model.Repository;

namespace Model;

public class DisciplinaFakeRepository : IRepository<Disciplina>
{
    List<Disciplina> disciplinas = [];

    public DisciplinaFakeRepository(){
        
    }
    public List<Disciplina> All => disciplinas;

    public void Add(Disciplina obj) => this.disciplinas.Add(obj);
}