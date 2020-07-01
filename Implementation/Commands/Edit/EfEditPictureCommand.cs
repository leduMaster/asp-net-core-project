using Application.Commands;
using Application.DataTransfer;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Implementation.Validators;
using FluentValidation;
using Application.Exceptions;

namespace Implementation.Commands
{
    public class EfEditPictureCommand : EfBaseCommand, IEditPictureCommand
    {
        private readonly AddPictureValidator _validator;
        public EfEditPictureCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 8;

        public string Name => "Edit Picture";

        public void Execute(AddPicture request)
        {
            _validator.ValidateAndThrow(request);

            var picDto = Context.Pictures.Find(request);
            if (picDto != null)
            {
                try
                {
                    picDto.alt = request.Alt;
                    picDto.src = request.Src;
                    picDto.IsDeleted = false;
                    picDto.ModifidedAt =DateTime.Now;
                    Context.SaveChanges();
                }
                catch (Exception)
                {

                    throw new Exception();
                }
            }
            else
            {
                throw new EntityNotFoundException(picDto.Id, typeof(AddPicture));
            }

        }
    }
}
