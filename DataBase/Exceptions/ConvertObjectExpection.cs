using System;

namespace DataBase.Exceptions;

public class ConvertObjectExpection : Exception {
    public override string Message => """O arquivo custom não foi definido""";
}

