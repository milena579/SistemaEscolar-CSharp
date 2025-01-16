using static System.Console;
using Model;
using Model.Repository;

IRepository<Aluno> alunoRepo = null;
IRepository<Professor> profRepo = null;
IRepository<Disciplina> discRepo = null;
IRepository<Turma> turmaRepo = null;

alunoRepo =  new AlunoFakeRepository();
profRepo =  new ProfessorFakeRepository();
discRepo =  new DisciplinaFakeRepository();
turmaRepo =  new TurmaFakeRepository();


static void verProfs(IRepository<Professor> profRepo)
{
    var profs =  profRepo.All;
    foreach (var prof in profs){
        WriteLine($"""
        {prof.Id} - {prof.Formacao} -  {prof.Nome}
        -------------------------------
    """);
    }
}

static void verAlunos(IRepository<Aluno> alunoRepo)
{
    var alunos =  alunoRepo.All;
    foreach (var alu in alunos){
        WriteLine($"""
        {alu.Nome} -  {alu.Idade}
        -------------------------------
    """);
    }
}

static void verMaterias(IRepository<Disciplina> discRepo)
{
    var materias =  discRepo.All;
    foreach (var materia in materias){
        WriteLine($"""
        {materia.Id} - {materia.Nome}
        -------------------------------
    """);
    }
}

static int tamMaterias(IRepository<Disciplina> discRepo){
    var materias =  discRepo.All;
    int tamanho = 0;
    foreach (var materia in materias){
       tamanho++;
    }
    return tamanho;
}

static int tamAlunos(IRepository<Aluno> alunoRepo){
    var alunos =  alunoRepo.All;
    int tamanho = 0;
    foreach (var aluno in alunos){
       tamanho++;
    }
    return tamanho;
}

static int tamProf(IRepository<Professor> profRepo){
    var profs =  profRepo.All;
    int tamanho = 0;
    foreach (var prof in profs){
       tamanho++;
    }
    return tamanho;
}

while (true){
    try
    {
        Clear();
        WriteLine(""" 
        1 - Cadastrar Professor
        2 - Cadastar Aluno
        3 - Cadastrar Materia
        4 - Cadastrar Turma
        5 - Ver Professores
        6 - Ver Alunos
        7 - Ver Materias
        8 - Ver Turmas
        """);

        int option = int.Parse(ReadLine());

        switch (option){
            case 1:
                Professor professor =  new();

                professor.Id = tamProf(profRepo);

                WriteLine("Insira o nome do professor: ");
                professor.Nome =  ReadLine();

                WriteLine("Insira a formacao do professor: ");
                professor.Formacao =  ReadLine();

                profRepo.Add(professor);

                break;
            case 2:
                Aluno aluno =  new();

                aluno.Id = tamAlunos(alunoRepo);

                WriteLine("Insira o nome do aluno: ");
                aluno.Nome =  ReadLine();

                WriteLine("Insira a idade do aluno: ");
                aluno.Idade =  int.Parse(ReadLine());

                alunoRepo.Add(aluno);

                break;

            case 3:
                Disciplina materia =  new();

                materia.Id = tamMaterias(discRepo);

                WriteLine("Insira o nome da materia: ");
                materia.Nome =  ReadLine();

                verProfs(profRepo);
                WriteLine("Insira o id do professor: ");
                materia.IdProfessor =  int.Parse(ReadLine());

                discRepo.Add(materia);

                break;
            case 4:
                Turma turma =  new();


                WriteLine("Insira o nome da turma: ");
                turma.Nome =  ReadLine();

                verMaterias(discRepo);
                WriteLine("Insira o id da(s) materia(s) separadas por VÍRGULAS: ");

                string entradaMaterias =  Console.ReadLine();
                var materias =  entradaMaterias.Split(',').Select(m => m.Trim()).ToList();
                turma.Materias.AddRange(materias);

                string entardaAlunos =  Console.ReadLine();
                var alunos =  entardaAlunos.Split(',').Select(m => m.Trim()).ToList();
                turma.Alunos.AddRange(alunos);


                turmaRepo.Add(turma);

                break;

            case 5: 
                verProfs(profRepo);
                var profs =  profRepo.All;
                break;
            
            case 6:
               verAlunos(alunoRepo);
                break;
            default:
                break;
        }
    }
    catch 
    {
        WriteLine("Algo deu errado, por favor contate a TI");
   
    }

    WriteLine("Pressione qualquer tecla para continuar");
    ReadKey(true);
}

