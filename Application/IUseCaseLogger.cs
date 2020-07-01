using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IUseCaseLogger
    {
        public void Log(IUseCase userCase, IApplicationActor actor, object useCaseData);
    }
}
