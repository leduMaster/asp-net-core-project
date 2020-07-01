using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Application
{
    public interface ICommand<TRequest> : IUseCase 
    {
        void Execute(TRequest request);
    }
    public interface ICommand<TQuerry, TResult> : IUseCase
    {
        TResult Execute(TQuerry querry);
    }
    public interface IUseCase
    {        
        int Id { get; }
        string Name { get; }
    }
}
