using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class UserDto : BaseDto
    {
       
        public string FirstName { get; set; }
   
        public string LastName { get; set; }
       
        public string UserName { get; set; }
    
        public bool IsDeleted { get; set; }
    
        public string Email { get; set; }
        public IEnumerable<UserUseCaseDto> UserUseCase { get; set; }

        public string Password { get; set; }
    }
}
