using System;

namespace DataBase.Exceptions;

public class CustomNotDefineException : Exception {
    public override string Message => """O arquivo custom não foi definido""";
}