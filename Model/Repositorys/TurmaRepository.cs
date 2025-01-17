
using System.ComponentModel;
using Model.Repository;
using DataBase;
namespace Model;

public class TurmaRepository : IRepository<Turma>
{
    DB<Turma> banco = DB<Turma>.App;
    public List<Turma> All => banco.All;

    public void Add(Turma obj) {
        var turma = banco.All;
        turma.Add(obj);
        banco.Save(turma);
    }

    public string findByID(int findByID)
    {
        var turmas = banco.All;

        for(int i = 0; i < turmas.Count; i++){
            if(findByID == turmas[i].Id){
                return turmas[i].Nome;
            }
        }   
        return null;
    }
}